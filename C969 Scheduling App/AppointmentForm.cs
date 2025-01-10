using C969_Scheduling_App.Manage_Appointments;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static C969_Scheduling_App.loginForm;

namespace C969_Scheduling_App
{
    public partial class AppointmentForm : Form
    {
        private int userId;
        private List<Appointment> appointments;
        private List<User> users;

        private string CurrentQuery { get; set; }

        public AppointmentForm(int userId)
        {
            InitializeComponent();
            this.Load += new EventHandler(AppointmentForm_Load);
            this.monthCalendar.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar_DateChanged);
            this.userId = userId;
        }


        private void LoadAppointments(string query)
        {
            
            try
            {
                using (MySqlConnection conn = SqlConnection.GetConnection())
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        foreach (DataRow row in dataTable.Rows)
                        {
                            DateTime utcStart = Convert.ToDateTime(row["start"]);
                            DateTime utcEnd = Convert.ToDateTime(row["end"]);

                            row["start"] = TimeZoneHelper.ConvertToLocalTime(utcStart);
                            row["end"] = TimeZoneHelper.ConvertToLocalTime(utcEnd);
                            
                        }
                        
                        // Format the DataGridView
                        apptGridView.DataSource = dataTable;
                        apptGridView.AutoGenerateColumns = true;
                        apptGridView.Columns["appointmentId"].Visible = false;
                        apptGridView.Columns["start"].DefaultCellStyle.Format = "MM/dd/yyyy hh:mm tt";
                        apptGridView.Columns["start"].Width = 125;
                        apptGridView.Columns["end"].DefaultCellStyle.Format = "MM/dd/yyyy hh:mm tt";
                        apptGridView.Columns["end"].Width = 125;
                        apptGridView.Columns["description"].Width = 350;
                        apptGridView.Refresh();

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading appointments: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Console.WriteLine("LoadAppointments() called.");
        }


        private void AppointmentForm_Load(object sender, EventArgs e)
        {
            CurrentQuery = @"
                SELECT appointmentId, title, type, description, start, end 
                FROM appointment;";

            LoadAppointments(CurrentQuery);
            InitializeReportGenerator();
        }


        private void manageCustBtn_Click(object sender, EventArgs e)
        {
            ManageCustomer manageCustomer = new ManageCustomer();
            manageCustomer.ShowDialog();
            this.Show();
        }


        private void closeBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {

                this.Close();
                return;
            }
        }


        private void signOutBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to signout?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                loginForm loginForm = new loginForm();
                loginForm.Show();
                this.Close();
            }
        }


        private void addApptBtn_Click(object sender, EventArgs e)
        {
            using (AddAppointment addAppointment = new AddAppointment(userId))
            {
                if (addAppointment.ShowDialog() == DialogResult.OK)
                {
                    // Refresh the DataGridView
                    LoadAppointments(CurrentQuery);
                }
            }
        }


        private void editApptBtn_Click(object sender, EventArgs e)
        {
            if (apptGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an appointment to edit.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int appointmentId = Convert.ToInt32(apptGridView.SelectedRows[0].Cells["appointmentId"].Value);

            using (EditAppointment editAppointmentForm = new EditAppointment(appointmentId))
            {
                if (editAppointmentForm.ShowDialog() == DialogResult.OK)
                {  
                    LoadAppointments(CurrentQuery);
                }
            }
        }


        private void deleteApptBtn_Click(object sender, EventArgs e)
        {
            if (apptGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an appointment to delete.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int appointmentId = Convert.ToInt32(apptGridView.SelectedRows[0].Cells["appointmentId"].Value);
            string appointmentType = apptGridView.SelectedRows[0].Cells["type"].Value.ToString(); // Optional: Get additional details

            var confirmResult = MessageBox.Show(
                $"Are you sure you want to delete the selected appointment of type '{appointmentType}'?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirmResult != DialogResult.Yes)
            {
                return;
            }

            string query = "DELETE FROM appointment WHERE appointmentId = @AppointmentId";

            try
            {
                using (MySqlConnection conn = SqlConnection.GetConnection())
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@AppointmentId", appointmentId);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Appointment deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadAppointments(CurrentQuery);
                        }
                        else
                        {
                            MessageBox.Show("Unable to delete the appointment. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting appointment: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void allApptBtn_Click(object sender, EventArgs e)
        {
            string query = @"
                SELECT appointmentId, title, type, description, start, end 
                FROM appointment;";

            LoadAppointments(query);
        }


        private void currentMonthBtn_Click(object sender, EventArgs e)
        {
            string query = @"
                SELECT appointmentId, title, type, description, start, end 
                FROM appointment
                WHERE YEAR(start) = YEAR(CURDATE()) AND MONTH(start) = MONTH(CURDATE());";

            LoadAppointments(query);
        }


        private void currentWeekBtn_Click(object sender, EventArgs e)
        {
            string query = @"
                SELECT appointmentId, title, type, description, start, end 
                FROM appointment
                WHERE YEARWEEK(start, 1) = YEARWEEK(CURDATE(), 1);";

            LoadAppointments(query);
        }


        private void monthCalendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            DateTime selectedDate = e.Start;
            LoadAppointmentsForDate(selectedDate);
        }

        private void LoadAppointmentsForDate(DateTime date)
        {
            string query = @"
        SELECT * 
        FROM appointment 
        WHERE DATE(start) = @SelectedDate";

            try
            {
                using (MySqlConnection conn = SqlConnection.GetConnection())
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@SelectedDate", date.ToString("yyyy-MM-dd"));

                        MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        apptGridView.DataSource = dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading appointments: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void submitBtn_Click(object sender, EventArgs e)
        {

            string filePath = "Report.txt"; 
            StringBuilder reportData = new StringBuilder();

            if (checkBoxTypes.Checked)
            {
                var typesByMonth = reportGenerator.GetAppointmentTypesByMonth();
                typesByMonth.ToList().ForEach(month =>
                {
                    reportData.AppendLine($"Appointment Types by Month: {month.Key}");
                    month.Value.ToList().ForEach(type =>
                    {
                        reportData.AppendLine($"  {type.Key}: {type.Value}");
                    });
                    reportData.AppendLine(new string('-', 50));
                });
            }

            if (checkBoxSchedule.Checked)
            {
                var scheduleForUsers = reportGenerator.GetScheduleForEachUser();
                scheduleForUsers.ToList().ForEach(userSchedule =>
                {
                    reportData.AppendLine($"Schedule for User: {userSchedule.Key}");
                    userSchedule.Value.ForEach(appt =>
                    {
                        reportData.AppendLine($"  {appt.Type} at {appt.Start:MM/dd/yyyy hh:mm tt}");
                    });
                    reportData.AppendLine(new string('-', 50));
                });
            }

            if (checkBoxCustomer.Checked)
            {
                var appointmentsByCustomer = reportGenerator.GetAppointmentsByCustomer();
                appointmentsByCustomer.ToList().ForEach(customer =>
                {
                    reportData.AppendLine($"Appointments for Customer: {customer.Key}");
                    customer.Value.ForEach(appt =>
                    {
                        reportData.AppendLine($"  {appt.Type} at {appt.Start:MM/dd/yyyy hh:mm tt}");
                    });
                    reportData.AppendLine(new string('-', 50));
                });
            }

            if (reportData.Length > 0)
            {
                WriteReportToTextFile(filePath, reportData.ToString());

                MessageBox.Show($"Report successfully generated at: {filePath}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //Automatically opens the .txt file
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = filePath,
                    UseShellExecute = true
                });
            }
            else
            {
                MessageBox.Show("No reports were selected. Please select at least one report to generate.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }


        private void WriteReportToTextFile(string filePath, string reportData)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath, false))
                {
                    writer.WriteLine(reportData);
                    writer.WriteLine(new string('-', 50));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error generating report: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private List<Appointment> LoadAppointments()
        {
            List<Appointment> appointments = new List<Appointment>();

            string query = @"
                SELECT 
                    a.appointmentId, 
                    a.type, 
                    a.start, 
                    a.end, 
                    a.userId, 
                    c.customerName 
                FROM 
                    appointment a
                JOIN 
                    customer c ON a.customerId = c.customerId";

            using (MySqlConnection conn = SqlConnection.GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            appointments.Add(new Appointment
                            {
                                Id = Convert.ToInt32(reader["appointmentId"]),
                                Type = reader["type"].ToString(),
                                Start = Convert.ToDateTime(reader["start"]),
                                End = Convert.ToDateTime(reader["end"]),
                                UserId = Convert.ToInt32(reader["userId"]),
                                CustomerName = reader["customerName"].ToString()
                            });
                        }
                    }
                }
            }
            return appointments;
        }


        private List<User> LoadUsers()
        {
            List<User> users = new List<User>();

            string query = "SELECT userId, userName FROM user";

            using (MySqlConnection conn = SqlConnection.GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            users.Add(new User
                            {
                                Id = Convert.ToInt32(reader["userId"]),
                                Name = reader["userName"].ToString()
                            });
                        }
                    }
                }
            }
            return users;
        }


        private ReportGenerator reportGenerator;

        private void InitializeReportGenerator()
        {
            List<Appointment> appointments = LoadAppointments();
            List<User> users = LoadUsers();

            reportGenerator = new ReportGenerator(appointments, users);
        }
    }
}

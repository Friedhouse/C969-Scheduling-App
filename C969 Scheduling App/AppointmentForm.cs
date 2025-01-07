using C969_Scheduling_App.Manage_Appointments;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        private string CurrentQuery { get; set; }

        public AppointmentForm(int userId)
        {
            InitializeComponent();
            Console.WriteLine($"Logged-in User ID: {LoggedInUser.UserId}");
            Console.WriteLine($"Logged-in Username: {LoggedInUser.Username}");
            this.Load += new EventHandler(AppointmentForm_Load);
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
                        

                        Console.WriteLine("Columns in DataTable:");
                        foreach (DataColumn column in dataTable.Columns)
                        {
                            Console.WriteLine(column.ColumnName);
                        }

                        Console.WriteLine("Rows in DataTable:");
                        foreach (DataRow row in dataTable.Rows)
                        {
                            Console.WriteLine(string.Join(", ", row.ItemArray));
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

                        // Debugging: Verify DataGridView columns
                        Console.WriteLine("Columns in DataGridView:");
                        foreach (DataGridViewColumn column in apptGridView.Columns)
                        {
                            Console.WriteLine(column.Name + " - " + column.DataPropertyName);
                        }
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
                FROM appointment
                WHERE YEAR(start) = YEAR(CURDATE()) AND MONTH(start) = MONTH(CURDATE());";

            LoadAppointments(CurrentQuery);
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
                    // Refresh the DataGridView
                    LoadAppointments(CurrentQuery);
                }
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

        
    }
}

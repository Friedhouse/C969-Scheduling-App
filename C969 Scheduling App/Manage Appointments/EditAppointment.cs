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
    public partial class EditAppointment : Form
    {

        private int appointmentId;

        public EditAppointment(int appointmentId)
        {
            InitializeComponent();
            this.appointmentId = appointmentId;

            LoadCustomers();
            LoadAppointmentData();           
            AddAppointmentForm_Load();
        }


        private void LoadAppointmentData()
        {
            string query = @"
                SELECT title, description, type, start, end, customerId 
                FROM appointment 
                WHERE appointmentId = @AppointmentId";

            try
            {
                using (MySqlConnection conn = SqlConnection.GetConnection())
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@AppointmentId", appointmentId);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                textBoxTitle.Text = reader["title"].ToString();
                                textBoxDescription.Text = reader["description"].ToString();
                                textBoxType.Text = reader["type"].ToString();

                                if (reader["start"] != DBNull.Value && reader["end"] != DBNull.Value)
                                {
                                    DateTime utcStart = Convert.ToDateTime(reader["start"]);
                                    DateTime utcEnd = Convert.ToDateTime(reader["end"]);

                                    dateTimePickerStart.Value = TimeZoneHelper.ConvertToLocalTime(utcStart);
                                    dateTimePickerEnd.Value = TimeZoneHelper.ConvertToLocalTime(utcEnd);

                                    dateTimePickerStart.Value = TimeZoneHelper.ConvertToLocalTime(utcStart);
                                    dateTimePickerEnd.Value = TimeZoneHelper.ConvertToLocalTime(utcEnd);

                                    dateTimePickerStart.Refresh();
                                    dateTimePickerEnd.Refresh();
                                }
                                else
                                {
                                    MessageBox.Show("The appointment times are missing or invalid in the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }

                                if (reader["customerId"] != DBNull.Value)
                                {
                                    int customerId = Convert.ToInt32(reader["customerId"]);
                                    foreach (var item in comboCustBox.Items)
                                    {
                                        if (item is Customer customer && customer.Id == customerId)
                                        {
                                            comboCustBox.SelectedItem = item;
                                            break;
                                        }
                                    }
                                }
                                
                                foreach (var item in comboCustBox.Items)
                                {
                                    if (item is Customer customer)
                                    {
                                        Console.WriteLine($"CustomerId: {customer.Id}, CustomerName: {customer.Name}");
                                    }
                                }

                                Console.WriteLine($"Selected CustomerId: {reader["customerId"]}");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading appointment data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void saveApptBtn_Click(object sender, EventArgs e)
        {
            {
                if (!ValidateInputs())
                {
                    return;
                }

                if (comboCustBox.SelectedItem == null)
                {
                    MessageBox.Show("Please select a customer.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int customerId = ((Customer)comboCustBox.SelectedItem).Id;

                string query = @"
                UPDATE appointment
                SET title = @Title, description = @Description, type = @Type, start = @Start, end = @End, 
                    customerId = @CustomerId, userId = @UserId, location = @Location, contact = @Contact, 
                    url = @Url, lastUpdate = NOW(), lastUpdateBy = @LastUpdateBy
                WHERE appointmentId = @AppointmentId";

                try
                {
                    using (MySqlConnection conn = SqlConnection.GetConnection())
                    {
                        conn.Open();
                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            
                            cmd.Parameters.AddWithValue("@Title", textBoxTitle.Text.Trim());
                            cmd.Parameters.AddWithValue("@Description", textBoxDescription.Text.Trim());
                            cmd.Parameters.AddWithValue("@Type", textBoxType.Text.Trim());
                            cmd.Parameters.AddWithValue("@Start", TimeZoneHelper.ConvertToUtc(dateTimePickerStart.Value));
                            cmd.Parameters.AddWithValue("@End", TimeZoneHelper.ConvertToUtc(dateTimePickerEnd.Value));
                            cmd.Parameters.AddWithValue("@CustomerId", customerId);
                            cmd.Parameters.AddWithValue("@UserId", LoggedInUser.UserId);
                            cmd.Parameters.AddWithValue("@Location", ""); 
                            cmd.Parameters.AddWithValue("@Contact", ""); 
                            cmd.Parameters.AddWithValue("@Url", "");     
                            cmd.Parameters.AddWithValue("@LastUpdateBy", LoggedInUser.Username);
                            cmd.Parameters.AddWithValue("@AppointmentId", appointmentId);

                            cmd.ExecuteNonQuery();

                            MessageBox.Show("Appointment updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error saving appointment: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cancelApptBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }


        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(textBoxTitle.Text) ||
                string.IsNullOrWhiteSpace(textBoxType.Text) ||
                comboCustBox.SelectedItem == null)
            {
                MessageBox.Show("All fields are required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (dateTimePickerEnd.Value <= dateTimePickerStart.Value)
            {
                MessageBox.Show("End time must be after the start time.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!ValidateBusinessHours(dateTimePickerStart.Value, dateTimePickerEnd.Value))
            {
                return false;
            }

            int customerId = Convert.ToInt32(comboCustBox.SelectedValue);
            if (!ValidateNoOverlap(customerId, dateTimePickerStart.Value, dateTimePickerEnd.Value))
            {
                return false;
            }

            return true;
        }

        private bool ValidateBusinessHours(DateTime start, DateTime end)
        {
            TimeZoneInfo estTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
            DateTime startEST = TimeZoneInfo.ConvertTime(start, estTimeZone);
            DateTime endEST = TimeZoneInfo.ConvertTime(end, estTimeZone);

            if (startEST.Hour < 9 || endEST.Hour >= 17 || startEST.DayOfWeek == DayOfWeek.Saturday || startEST.DayOfWeek == DayOfWeek.Sunday)
            {
                MessageBox.Show("Appointments must be scheduled during business hours: 9 AM to 5 PM EST, Monday-Friday.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }


        private bool ValidateNoOverlap(int customerId, DateTime start, DateTime end)
        {
            string query = @"
                SELECT * 
                FROM appointment
                WHERE customerId = @CustomerId
                AND ((@Start < end AND @End > start));";

            try
            {
                using (MySqlConnection conn = SqlConnection.GetConnection())
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@CustomerId", customerId);
                        cmd.Parameters.AddWithValue("@Start", start);
                        cmd.Parameters.AddWithValue("@End", end);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                MessageBox.Show("The appointment overlaps with an existing appointment.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return false;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error validating overlap: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }


        private void LoadCustomers()
        {
            string query = "SELECT customerId, customerName FROM customer;";

            try
            {
                using (MySqlConnection conn = SqlConnection.GetConnection())
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                comboCustBox.Items.Add(new Customer
                                {
                                    Id = Convert.ToInt32(reader["customerId"]),
                                    Name = reader["customerName"].ToString()
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading customers: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            comboCustBox.DisplayMember = "Name";
        }
        private void AddAppointmentForm_Load()
        {
            // Configure Start DateTimePicker
            dateTimePickerStart.Format = DateTimePickerFormat.Custom;
            dateTimePickerStart.CustomFormat = "MM/dd/yyyy hh:mm tt";
            dateTimePickerStart.ShowUpDown = true;

            // Configure End DateTimePicker
            dateTimePickerEnd.Format = DateTimePickerFormat.Custom;
            dateTimePickerEnd.CustomFormat = "MM/dd/yyyy hh:mm tt";
            dateTimePickerEnd.ShowUpDown = true;
        }


        public class Customer
        {
            public int Id { get; set; }
            public string Name { get; set; }

            public override string ToString()
            {
                return Name; // Display the name in the ComboBox
            }
        }
    }
}

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

namespace C969_Scheduling_App.Manage_Appointments
{
    public partial class AddAppointment : Form
    {
        private int userId;
        public AddAppointment(int userId)
        {
            InitializeComponent();
            this.userId = userId;
            LoadCustomers();
            AddAppointmentForm_Load();
        }

        private void cancelApptBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void saveApptBtn_Click(object sender, EventArgs e)
        {
            string title = textBoxTitle.Text.Trim();
            string type = textBoxType.Text.Trim();
            DateTime start = dateTimePickerStart.Value;
            DateTime end = dateTimePickerEnd.Value;
            string description = textBoxDescription.Text.Trim();
            int customerId = (comboCustBox.SelectedItem as dynamic)?.Id ?? 0;

            // Validation
            if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(type) || customerId == 0)
            {
                MessageBox.Show("All fields are required, and a customer must be selected.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateBusinessHours(start, end) || !ValidateNoOverlap(customerId, start, end))
            {
                return;
            }

            if (end <= start)
            {
                MessageBox.Show("The end time must be after the start time.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Insert into the database
            string query = @"
                INSERT INTO appointment (customerId, userId, title, description, location, contact, type, url, start, end, createDate, createdBy, lastUpdate, lastUpdateBy)
                VALUES (@CustomerId, @UserId, @Title, @Description, @Location, @Contact, @Type, @Url, @Start, @End, NOW(), @CreatedBy, NOW(), @LastUpdateBy);";

            try
            {
                using (MySqlConnection conn = SqlConnection.GetConnection())
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@CustomerId", customerId);
                        cmd.Parameters.AddWithValue("@UserId", userId);
                        cmd.Parameters.AddWithValue("@Title", title);
                        cmd.Parameters.AddWithValue("@Description", description);
                        cmd.Parameters.AddWithValue("@Location", "");
                        cmd.Parameters.AddWithValue("@Contact", "");
                        cmd.Parameters.AddWithValue("@Type", type);
                        cmd.Parameters.AddWithValue("@Url", "");
                        cmd.Parameters.AddWithValue("@Start", start);
                        cmd.Parameters.AddWithValue("@End", end);
                        cmd.Parameters.AddWithValue("@CreatedBy", Environment.UserName);
                        cmd.Parameters.AddWithValue("@LastUpdateBy", Environment.UserName);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Appointment added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                                // Customer name is added with ID as value
                                comboCustBox.Items.Add(new
                                {
                                    Name = reader["customerName"].ToString(),
                                    Id = reader["customerId"]
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


        private void AddAppointmentForm_Load()
        {
            // Configure Start DateTimePicker
            dateTimePickerStart.Format = DateTimePickerFormat.Custom;
            dateTimePickerStart.CustomFormat = "MM/dd/yyyy hh:mm tt"; // 12-hour format with AM/PM
            dateTimePickerStart.ShowUpDown = true;

            // Configure End DateTimePicker
            dateTimePickerEnd.Format = DateTimePickerFormat.Custom;
            dateTimePickerEnd.CustomFormat = "MM/dd/yyyy hh:mm tt"; // 12-hour format with AM/PM
            dateTimePickerEnd.ShowUpDown = true;

            // Set default values
            dateTimePickerStart.Value = DateTime.Now;
            dateTimePickerEnd.Value = DateTime.Now.AddHours(1);
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Drawing.Text;

namespace C969_Scheduling_App
{
    public partial class loginForm : Form
    {

        private Dictionary<string, string> translations;

        public loginForm()
        {
            InitializeComponent();
            SetLocaliazation();
        }

        private void signInBtn_Click_1(object sender, EventArgs e)
        {
            string username = textBoxUsername.Text;
            string password = textBoxPassword.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter both username and password.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (VerifyCredentials(username, password))
            {
                int userId = GetUserId(username, password);
                if (userId > 0)
                {
                    this.Hide();
                    using (AppointmentForm appointmentForm = new AppointmentForm(userId))
                    {
                        appointmentForm.ShowDialog();
                    }
                    this.Show(); // Show the login form again if needed
                }
                else
                {
                    MessageBox.Show("Unable to retrieve user information. Login failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Invalid username or password.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private bool VerifyCredentials(string username, string password) 
        {
            bool isValid = false;

            try
            {
                using (MySqlConnection conn = SqlConnection.GetConnection())
                {
                    conn.Open();

                    string query = "SELECT * FROM user WHERE username=@username AND password=@password";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isValid = true;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database connection error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return isValid;
        }


        private void SetLocaliazation()
        {
            //Determine's user's current culture info
            CultureInfo currentCulture = CultureInfo.CurrentUICulture;
            string currentLanguage = currentCulture.Name;

            translations = new Dictionary<string, string>();

            if (currentLanguage == "fr") //French localization example
            {
                translations["username_label"] = "Nom d' utilisateur";
                translations["password_label"] = "Mot de passe";
                translations["signin_button"] = "S'identifier";
                translations["error_invalid_credentials"] = "Le nom d'utilisateur et le mot de passe ne correspondent pas.";
            }
            else // Default to English
            {
                translations["username_label"] = "Username";
                translations["password_label"] = "Password";
                translations["signin_button"] = "Sign in";
                translations["error_invalid_credentials"] = "The username and password do not match.";
            }

            // Apply translations to controls
            usernameLabel.Text = translations["username_label"];
            passwordLabel.Text = translations["password_label"];
            signInBtn.Text = translations["signin_button"];
        }


        private int GetUserId(string username, string password)
        {
            string query = "SELECT userId FROM user WHERE username = @username AND password = @password";

            try
            {
                using (MySqlConnection conn = SqlConnection.GetConnection())
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password);

                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            return Convert.ToInt32(result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving user ID: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return -1; // Return an invalid userId if login fails
        }
    }
}

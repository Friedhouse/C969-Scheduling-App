using System;
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

            if (VerifyCredentials(username, password))
            {
                MessageBox.Show("Sign in successful!");

                AppointmentForm appointmentForm = new AppointmentForm();
                appointmentForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show(translations["error_invalid_credentials"], "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); 
            }  
        }

        private bool VerifyCredentials(string username, string password) 
        {
            string connectionString = "server=127.0.0.1;user=sqlUser;database=client_schedule;port=3306;password=Passw0rd!";
            bool isValid = false;

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
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
    }
}

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

namespace C969_Scheduling_App
{
    public partial class EditCustomer : Form
    {
        private int customerId;
        public EditCustomer(int customerId, string name, string address, string address2, string phone, string postalCode, string city, string country)
        {
            InitializeComponent();

            this.customerId = customerId;

            // Prepopulate textboxes
            textBoxName.Text = name;
            textBoxAddress.Text = address;
            textBoxAddress2.Text = address2;
            textBoxPhone.Text = phone;
            textBoxPostalCode.Text = postalCode;
            textBoxCity.Text = city;
            textBoxCountry.Text = country;
        }

        private void saveCustBtn_Click(object sender, EventArgs e)
        {
            string name = textBoxName.Text.Trim();
            string address = textBoxAddress.Text.Trim();
            string address2 = textBoxAddress2.Text.Trim();
            string phone = textBoxPhone.Text.Trim();
            string postalCode = textBoxPostalCode.Text.Trim();
            string city = textBoxCity.Text.Trim();
            string country = textBoxCountry.Text.Trim();
            string currentUser = Environment.UserName;

            //Validate all fields are filled out
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(address) || string.IsNullOrWhiteSpace(phone))
            {
                MessageBox.Show("All fields are required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //Validate phone number contain numbers only
            if (!IsValidPhoneNumber(phone))
            {
                MessageBox.Show("Phone number must contain only numbers and formatted as XXX-XXXX", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                MySqlConnection conn = SqlConnection.GetConnection();

                string query = @"
                UPDATE customer c
                JOIN address a ON c.addressId = a.addressId
                JOIN city ct ON a.cityId = ct.cityId
                JOIN country co ON ct.countryId = co.countryId
                SET 
                    c.CustomerName = @CustomerName,
                    a.address = @Address,
                    a.address2 = @Address2,
                    a.phone = @Phone,
                    a.postalCode = @PostalCode,
                    ct.city = @City,
                    co.country = @Country,
                    c.lastUpdate = NOW(),
                    c.lastUpdateBy = @LastUpdateBy
                WHERE c.CustomerId = @CustomerId;
            ";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {

                    cmd.Parameters.AddWithValue("@CustomerName", name);
                    cmd.Parameters.AddWithValue("@Address", address);
                    cmd.Parameters.AddWithValue("@Address2", address2);
                    cmd.Parameters.AddWithValue("@Phone", phone);
                    cmd.Parameters.AddWithValue("@PostalCode", postalCode);
                    cmd.Parameters.AddWithValue("@City", city);
                    cmd.Parameters.AddWithValue("@Country", country);
                    cmd.Parameters.AddWithValue("@LastUpdateBy", currentUser);

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Customer updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating customer: {ex.Message}\n{ex.StackTrace}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool IsValidPhoneNumber(string phone)
        {
            if (phone.Length != 8)
            {
                return false;
            }

            if (phone[3] != '-') //4th character needs to be a dash
            {
                return false;
            }

            for (int i = 0; i < phone.Length; i++)
            {
                if (i == 3) continue;
                if (!char.IsDigit(phone[i])) return false;
            }
            return true;
        }

        private void cancelCustBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}

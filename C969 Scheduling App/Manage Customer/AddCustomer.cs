using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C969_Scheduling_App
{
    public partial class AddCustomer : Form
    {
        public AddCustomer()
        {
            InitializeComponent();
        }

        private void cancelCustBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void saveCustBtn_Click(object sender, EventArgs e)
        {
            string name = textBoxName.Text.Trim();
            string address = textBoxAddress.Text.Trim();
            string address2 = textBoxAddress.Text.Trim();
            string postalCode = textBoxPostalCode.Text.Trim();
            string phone = textBoxPhone.Text.Trim();
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

                conn.Open();

                //Insert or find the country
                string getCountryIDQuery = @"
                    INSERT INTO country (country, createDate, createdBy, lastUpdate, lastUpdateBy)
                    VALUES (@Country, NOW(), @CreatedBy, NOW(), @LastUpdateBy)
                    ON DUPLICATE KEY UPDATE 
                        lastUpdate = NOW(),
                        lastUpdateBy = @LastUpdateBy,
                        countryId = LAST_INSERT_ID(countryId);
                    SELECT LAST_INSERT_ID();
                ";

                int countryID;
                using (MySqlCommand cmd = new MySqlCommand(getCountryIDQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@Country", country);
                    cmd.Parameters.AddWithValue("@CreatedBy", currentUser);
                    cmd.Parameters.AddWithValue("@LastUpdateBy", currentUser);
                    countryID = Convert.ToInt32(cmd.ExecuteScalar());
                }

                //Insert or find the city
                string getCityIDQuery = @"
                    INSERT INTO city (city, countryId, createDate, createdBy, lastUpdate, lastUpdateBy)
                    VALUES (@City, @CountryId, NOW(), @CreatedBy, NOW(), @LastUpdateBy)
                    ON DUPLICATE KEY UPDATE 
                        lastUpdate = NOW(),
                        lastUpdateBy = @LastUpdateBy,
                        cityId = LAST_INSERT_ID(cityId);
                    SELECT LAST_INSERT_ID();
                ";

                int cityID;
                using (MySqlCommand cmd = new MySqlCommand(getCityIDQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@City", city);
                    cmd.Parameters.AddWithValue("@CountryId", countryID);
                    cmd.Parameters.AddWithValue("@CreatedBy", currentUser);
                    cmd.Parameters.AddWithValue("@LastUpdateBy", currentUser);
                    cityID = Convert.ToInt32(cmd.ExecuteScalar());
                }

                //Insert or find the address
                string getAddressIDQuery = @"
                    INSERT INTO address (address, address2, cityId, postalCode, phone, createDate, createdBy, lastUpdate, lastUpdateBy)
                    VALUES (@Address, @Address2, @CityId, @postalCode, @Phone, NOW(), @CreatedBy, NOW(), @LastUpdateBy)
                    ON DUPLICATE KEY UPDATE 
                        lastUpdate = NOW(),
                        lastUpdateBy = @LastUpdateBy,
                        addressID = LAST_INSERT_ID(addressId);
                    SELECT LAST_INSERT_ID();
                ";

                int addressID;
                using (MySqlCommand cmd = new MySqlCommand(getAddressIDQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@Address", address);
                    cmd.Parameters.AddWithValue("@Address2", string.IsNullOrWhiteSpace(textBoxAddress2.Text) ? (object)DBNull.Value : textBoxAddress2.Text);
                    cmd.Parameters.AddWithValue("@CityId", cityID);
                    cmd.Parameters.AddWithValue("@PostalCode", postalCode);
                    cmd.Parameters.AddWithValue("@Phone", phone);
                    cmd.Parameters.AddWithValue("@CreatedBy", currentUser);
                    cmd.Parameters.AddWithValue("@LastUpdateBy", currentUser);
                    addressID = Convert.ToInt32(cmd.ExecuteScalar());
                }

                //Insert the customer
                string insertCustomerQuery = @"
                    INSERT INTO customer (CustomerName, AddressID, active, createDate, createdBy, lastUpdate, lastUpdateBy)
                    VALUES (@CustomerName, @AddressID, 1, NOW(), @CreatedBy, NOW(), @LastUpdateBy);
                ";

                using (MySqlCommand cmd = new MySqlCommand(insertCustomerQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@CustomerName", name);
                    cmd.Parameters.AddWithValue("@AddressId", addressID);
                    cmd.Parameters.AddWithValue("@CreatedBy", currentUser);
                    cmd.Parameters.AddWithValue("@LastUpdateBy", currentUser);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Customer added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding customer: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool IsValidPhoneNumber(string phone)
        {
            if(phone.Length != 8)
            {
                return false;
            }

            if (phone[3] != '-') //4th character needs to be a dash
            {
                return false;
            }

            for (int i=0; i < phone.Length; i++)
            {
                if (i == 3) continue;
                if (!char.IsDigit(phone[i])) return false;  
            }
            return true;
        }

    }
}

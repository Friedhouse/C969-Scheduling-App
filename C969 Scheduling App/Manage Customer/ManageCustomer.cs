﻿using MySql.Data.MySqlClient;
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
    public partial class ManageCustomer : Form
    {
        public ManageCustomer()
        {
            InitializeComponent();
            LoadCustomerData(); 
        }

        private void addCustBtn_Click(object sender, EventArgs e)
        {
            using (AddCustomer addCustomer = new AddCustomer())
            {
                if (addCustomer.ShowDialog() == DialogResult.OK)
                {
                    LoadCustomerData();
                }
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void LoadCustomerData()
        {
            string query = @"
                SELECT
                    c.CustomerId,
                    c.CustomerName AS Name,
                    a.address AS StreetAddress,
                    a.address2 AS AddressLine2,
                    a.postalCode AS PostalCode,
                    ct.city AS city,
                    co.country AS Country,
                    CONCAT(a.address, IFNULL(CONCAT(', ', a.address2), ''), ', ', ct.city, ', ', co.country) AS Address,
                    a.phone AS PhoneNumber
                FROM
                    customer c
                    JOIN address a ON c.addressId = a.addressId
                    JOIN city ct ON a.cityId = ct.cityId
                    JOIN country co ON ct.countryId = co.countryId;
            ";

            //Try catch statement was used to prevent application termination incase of an unhandled error.
            //Logging the error message will help with potential debugging in the future allowing you to view specific errors related to SQL syntax or column names.
            
            try
            {
                MySqlConnection conn = SqlConnection.GetConnection();

                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {                   
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();

                    //Fills data table w/ query results and binds them to the grid.
                    adapter.Fill(dataTable);
                    dataGridCustomer.DataSource = dataTable;

                    dataGridCustomer.Columns["StreetAddress"].Visible = false;
                    dataGridCustomer.Columns["AddressLine2"].Visible = false;
                    dataGridCustomer.Columns["PostalCode"].Visible = false;
                    dataGridCustomer.Columns["City"].Visible = false;
                    dataGridCustomer.Columns["Country"].Visible = false;

                    //Custom column width
                    dataGridCustomer.Columns["Name"].Width = 120;
                    dataGridCustomer.Columns["Address"].Width = 220;
                    dataGridCustomer.Columns["PostalCode"].Width = 100;
                    dataGridCustomer.Columns["PhoneNumber"].Width = 120;

                    //Setting columns to readonly
                    dataGridCustomer.Columns["Name"].ReadOnly = true;
                    dataGridCustomer.Columns["Address"].ReadOnly = true;
                    dataGridCustomer.Columns["PostalCode"].ReadOnly = true;
                    dataGridCustomer.Columns["PhoneNumber"].ReadOnly = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading customer data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Console.WriteLine("LoadCustomerData() called.");
        }

        private void editCustBtn_Click(object sender, EventArgs e)
        {
            if (dataGridCustomer.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a customer to edit.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow selectedRow = dataGridCustomer.SelectedRows[0];

            int customerId = Convert.ToInt32(selectedRow.Cells["CustomerId"].Value);
            string name = selectedRow.Cells["Name"].Value.ToString();
            string address = selectedRow.Cells["StreetAddress"].Value.ToString();
            string address2 = selectedRow.Cells["AddressLine2"].Value.ToString();
            string phone = selectedRow.Cells["PhoneNumber"].Value.ToString();
            string postalCode = selectedRow.Cells["PostalCode"].Value.ToString();
            string city = selectedRow.Cells["City"].Value.ToString();
            string country = selectedRow.Cells["Country"].Value.ToString();

            using (EditCustomer editCustomer = new EditCustomer(customerId, name, address, address2, phone, postalCode, city, country))
            {
                if (editCustomer.ShowDialog() == DialogResult.OK)
                {
                    LoadCustomerData();
                }
            }
        }

        private void deleteCustBtn_Click(object sender, EventArgs e)
        {
            {
                if (dataGridCustomer.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a customer to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DataGridViewRow selectedRow = dataGridCustomer.SelectedRows[0];
                int customerId = Convert.ToInt32(selectedRow.Cells["CustomerID"].Value);

                var result = MessageBox.Show("Are you sure you want to delete this customer?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result != DialogResult.Yes)
                {
                    return;
                }

                try
                {
                    using (MySqlConnection conn = SqlConnection.GetConnection())
                    {
                        conn.Open();
                        // Used a transaction here to ensure all related data is deleted
                        using (MySqlTransaction transaction = conn.BeginTransaction())
                        {
                            try
                            {
                                string deleteCustomerQuery = "DELETE FROM customer WHERE customerID = @CustomerID;";
                                using (MySqlCommand cmd = new MySqlCommand(deleteCustomerQuery, conn, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@CustomerID", customerId);
                                    cmd.ExecuteNonQuery();
                                }

                                string deleteAddressQuery = @"
                                    DELETE FROM address
                                    WHERE addressID IN (
                                    SELECT addressID FROM customer WHERE customerID = @CustomerID
                                    );";

                                using (MySqlCommand cmd = new MySqlCommand(deleteAddressQuery, conn, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@CustomerID", customerId);
                                    cmd.ExecuteNonQuery();
                                }

                                transaction.Commit();

                                MessageBox.Show("Customer deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (Exception ex)
                            {
                                transaction.Rollback();
                                MessageBox.Show($"Error deleting customer: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }

                    Console.WriteLine("Reloading customer data...");
                    dataGridCustomer.DataSource = null;
                    LoadCustomerData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Database error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}

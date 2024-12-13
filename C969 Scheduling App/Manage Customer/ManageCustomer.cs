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
    public partial class ManageCustomer : Form
    {
        public ManageCustomer()
        {
            InitializeComponent();
            LoadCustomerData(); 
        }

        private void addCustBtn_Click(object sender, EventArgs e)
        {
            AddCustomer addCustomer = new AddCustomer();
            addCustomer.ShowDialog();
            this.Show();
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
                    c.CustomerName AS Name,
                    CONCAT(a.address, ', ', ct.city, ', ', co.country) AS Address,
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

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();

                    //Fills data table w/ query results and binds them to the grid.
                    adapter.Fill(dataTable);
                    dataGridCustomer.DataSource = dataTable;

                    //Custom column width
                    dataGridCustomer.Columns["Name"].Width = 140;
                    dataGridCustomer.Columns["Address"].Width = 280;
                    dataGridCustomer.Columns["PhoneNumber"].Width = 140;

                    //Setting columns to readonly
                    dataGridCustomer.Columns["Name"].ReadOnly = true;
                    dataGridCustomer.Columns["Address"].ReadOnly = true;
                    dataGridCustomer.Columns["PhoneNumber"].ReadOnly = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading customer data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

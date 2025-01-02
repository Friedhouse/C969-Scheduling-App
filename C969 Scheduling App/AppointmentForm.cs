using C969_Scheduling_App.Manage_Appointments;
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
    public partial class AppointmentForm : Form
    {
        private int userId;

        public AppointmentForm(int userId)
        {
            InitializeComponent();
            this.userId = userId;
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
                    return;
                }
            }
        }
    }
}

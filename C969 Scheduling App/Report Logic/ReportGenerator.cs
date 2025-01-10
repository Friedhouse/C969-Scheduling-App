using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C969_Scheduling_App
{
    public class ReportGenerator
    {
        private List<Appointment> appointments;
        private List<User> users;

        public ReportGenerator(List<Appointment> appointments, List<User> users)
        {
            this.appointments = appointments;
            this.users = users;
        }

        
        // Generates the number of appointment types by month.        
        //A dictionary with month-year as key and another dictionary with appointment type as key and count as value.
        public Dictionary<string, Dictionary<string, int>> GetAppointmentTypesByMonth()
        {
            return appointments
                .GroupBy(appt => new { Month = appt.Start.ToString("MMMM yyyy"), appt.Type })
                .GroupBy(g => g.Key.Month)
                .ToDictionary(
                    monthGroup => monthGroup.Key,
                    monthGroup => monthGroup.ToDictionary(
                        typeGroup => typeGroup.Key.Type,
                        typeGroup => typeGroup.Count()
                    )
                );
        }

        
        // Generates the schedule for each user.
        // A dictionary with user names as keys and a list of appointments as values.
        public Dictionary<string, List<Appointment>> GetScheduleForEachUser()
        {
            return appointments
                .GroupBy(appt => appt.UserId)
                .ToDictionary(
                    userGroup => users.FirstOrDefault(user => user.Id == userGroup.Key)?.Name ?? "Unknown User",
                    userGroup => userGroup.ToList()
                );
        }

        // Generates a report of appointments by customer.
        // A dictionary with customer names as keys and a list of appointments as values.
        public Dictionary<string, List<Appointment>> GetAppointmentsByCustomer()
        {
            return appointments
                .GroupBy(appt => appt.CustomerName)
                .ToDictionary(
                    customerGroup => customerGroup.Key,
                    customerGroup => customerGroup.ToList()
                );
        }
    }
}

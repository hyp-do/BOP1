using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C969___BOP1
{
    class AppointmentTimeException : ApplicationException
    {
        public void businessHoursException()
        {
            MessageBox.Show("An exception has occurred, appointments should be schedueld during normal business hours.");
        }

        public void overlappingAppointmentException()
        {
            MessageBox.Show("An exception has occurred, this appointment's scheduled time conflicts with a previously scheduled appointment.");
        }
    }
}

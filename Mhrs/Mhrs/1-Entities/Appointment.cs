using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
   public class Appointment
    {
        public int ID { get; set; }
        public Doctor Doctor { get; set; }
        public Poorly Poorly { get; set; }
        public DateTime DateOfAppointment { get; set; }
        public bool Status { get; set; }
        public Appointment()
        {
            Doctor = new Doctor();
            Poorly = new Poorly();
            DateOfAppointment = new DateTime();
        }
    }
}

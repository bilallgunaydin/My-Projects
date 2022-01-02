using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
   public class SafetyInformation
    {
        public int PatientID { get; set; }
        public string Password { get; set; }
        public SecurityQuestion SecurityQuestion { get; set; }
        public string Answer { get; set; }
        public SafetyInformation()
        {
            SecurityQuestion = new SecurityQuestion();
        }
       
    }
}
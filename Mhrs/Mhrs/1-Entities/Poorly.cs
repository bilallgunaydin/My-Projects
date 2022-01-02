using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
     public class Poorly
    {
        public PersonalInformation Personel { get; set; }
        public ContactInformation Contact { get; set; }
        public SafetyInformation Safety { get; set; }
        public Poorly()
        {
            Personel = new PersonalInformation();
            Contact = new ContactInformation();
            Safety = new SafetyInformation();
        }
    }
}

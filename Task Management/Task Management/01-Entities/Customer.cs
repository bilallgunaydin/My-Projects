using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Entities
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string ContactName { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string LogoURL { get; set; }
        public string GSM { get; set; }

        public bool isPassive { get; set; }
    }
}

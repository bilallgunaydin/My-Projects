using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class AccountType
    {
        public AccountType()
        {
          
            this.isPassive = false;
        }
        public int ID { get; set; }
        public string Name { get; set; }
        public bool isPassive { get; set; }
        
    }
}

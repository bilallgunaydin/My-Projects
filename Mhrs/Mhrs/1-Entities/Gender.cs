using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Gender
    {
        public int GenderID { get; set; }
        public string GenderName { get; set; }
        public override string ToString()
        {
            return GenderName;
        }
    }
}

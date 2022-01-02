using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class SecurityQuestion
    {
        public int ID { get; set; }
        public string Question { get; set; }
        public override string ToString()
        {
            return Question;
        }
    }
}

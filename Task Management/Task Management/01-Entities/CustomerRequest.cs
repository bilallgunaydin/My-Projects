using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Entities
{
   public class CustomerRequest
    {
       public int CustomerRequestID { get; set; }
        public int ProjectID { get; set; }
        public virtual Project Project { get; set; }
        public string Description { get; set; }
        //Yeni mi yoksa revize bir talep mi?
        public bool RequestType { get; set; }
        public DateTime RequestDate { get; set; }
    }
}

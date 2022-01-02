using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
   public class County
    {
        public int ID { get; set; }
        public string CountyName { get; set; }
        public City CityID { get; set; }
        public County()
        {
            CityID = new City();
        }
    }
}

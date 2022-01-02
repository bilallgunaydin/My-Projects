using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
  public  class Hospital
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public City City { get; set; }

        public County County { get; set; }

        public Hospital()
        {
            City = new City();
            County = new County();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Entities;

namespace BusinessLayer
{
    public class CountyBLL:IBusiness<Entities.County,Int32>
    {
        CountyDLL _county;
        public CountyBLL()
        {
            _county = new CountyDLL();
        }
        public bool Insert(County item)
        {
            throw new NotImplementedException();
        }

        public bool Update(County item)
        {
            throw new NotImplementedException();
        }

        public bool Delete(County item)
        {
            throw new NotImplementedException();
        }

        public List<County> GetAll()
        {
            List<County> countyList = _county.GetAll();
            return countyList;
        }

        public County Get(int id)
        {
            County county = _county.Get(id);
            return county;
        }

        public List<County> GetAll(County county)
        {
            List<County> countyList = _county.GetAll(county);
            return countyList;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Entities;

namespace BusinessLayer
{
    public class CityBLL:IBusiness<Entities.City,Int32>
    {
        CityDLL _city;
        public CityBLL()
        {
            _city = new CityDLL();
        }
        public bool Insert(City item)
        {
            throw new NotImplementedException();
        }

        public bool Update(City item)
        {
            throw new NotImplementedException();
        }

        public bool Delete(City item)
        {
            throw new NotImplementedException();
        }

        public List<City> GetAll()
        {
            List<City> cityList = _city.GetAll();
            return cityList;
        }

        public City Get(int id)
        {
            City city = _city.Get(id);
            return city;
        }
    }
}

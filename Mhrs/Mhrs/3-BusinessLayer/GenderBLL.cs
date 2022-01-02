using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Entities;

namespace BusinessLayer
{
   public class GenderBLL:IBusiness<Entities.Gender,Int32>
    {
        GenderDLL _genderDLL = new GenderDLL();
        public bool Insert(Entities.Gender item)
        {
            throw new NotImplementedException();
        }

        public bool Update(Entities.Gender item)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Entities.Gender item)
        {
            throw new NotImplementedException();
        }

        public List<Gender> GetAll()
        {
            List<Gender> genderList = _genderDLL.GetAll();
            return genderList;
        }

        public Entities.Gender Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}

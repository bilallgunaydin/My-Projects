using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Entities;

namespace BusinessLayer
{
    public class ClinicBLL: IBusiness<Entities.Clinic,Int32>
    {
        ClinicDLL _clinic;
        public ClinicBLL()
        {
            _clinic = new ClinicDLL();
        }

        public bool Insert(Clinic item)
        {
            throw new NotImplementedException();
        }

        public bool Update(Clinic item)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Clinic item)
        {
            throw new NotImplementedException();
        }

        public List<Clinic> GetAll()
        {
            List<Clinic> clinicList = _clinic.GetAll();
            return clinicList;
        }

        public Clinic Get(int id)
        {
            Clinic clinic = _clinic.Get(id);
            return clinic;
        }

        public object GetAll(HospitalClinicExaminationPlace clinic)
        {
            List<Clinic> clinicList = _clinic.GetAll(clinic);
            return clinicList;
        }
    }
}

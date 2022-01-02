using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Entities;

namespace BusinessLayer
{
    public class HospitalBLL:IBusiness<Entities.Hospital,Int32>
    {
        HospitalDLL _hospital;
        public HospitalBLL()
        {
            _hospital = new HospitalDLL();
        }

        public bool Insert(Hospital item)
        {
            throw new NotImplementedException();
        }

        public bool Update(Hospital item)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Hospital item)
        {
            throw new NotImplementedException();
        }

        public List<Hospital> GetAll()
        {
            List<Hospital> hospitalList = _hospital.GetAll();
            return hospitalList;
        }

        public Hospital Get(int id)
        {
            Hospital hospital = _hospital.Get(id);
            return hospital;
        }

        public object GetAll(HospitalClinicExaminationPlace clinic)
        {
            List<Hospital> hospitalList = _hospital.GetAll(clinic);
            return hospitalList;
        }

        public object GetAll(Hospital hospital,Clinic clinic)
        {
            List<Hospital> hospitalList = _hospital.GetAll(hospital, clinic);
            return hospitalList;
        }
    }
}

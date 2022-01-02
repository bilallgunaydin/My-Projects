using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Entities;

namespace BusinessLayer
{
    public class DoctorBLL:IBusiness<Entities.Doctor,Int32>
    {
        DoctorDLL _doctorDLL;
        public DoctorBLL()
        {
            _doctorDLL = new DoctorDLL();
        }

        public bool Insert(Doctor item)
        {
            throw new NotImplementedException();
        }

        public bool Update(Doctor item)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Doctor item)
        {
            throw new NotImplementedException();
        }

        public List<Doctor> GetAll()
        {
            throw new NotImplementedException();
        }
        public object GetAll(HospitalClinicExaminationPlace doc)
        {
            List<Doctor> doctorList = _doctorDLL.GetAll(doc);
            return doctorList;
        }

        public Doctor Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Doctor> GetAll(Hospital hospital, Clinic clinic)
        {
            List<Doctor> doctor = _doctorDLL.GetAll(hospital, clinic);
            return doctor;
        }

        public object GetAll(ExaminationPlace examinationPlace)
        {
            List<Doctor> doctor = _doctorDLL.GetAll(examinationPlace);
            return doctor;
        }
    }
}

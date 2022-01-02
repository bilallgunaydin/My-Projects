using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Entities;

namespace BusinessLayer
{
    public class AppointmentBLL : IBusiness<Appointment, Int32>
    {
        AppointmentDLL _appointment;

        public AppointmentBLL()
        {
            _appointment = new AppointmentDLL();
        }


        public bool Insert(Appointment item)
        {
            int affectedRows = 0;
            if (item.Doctor.DoctorID > 0 && item.Poorly.Personel.PatientID > 0 && item.DateOfAppointment != null &&
                item.Status == true)
            {

                affectedRows = _appointment.insert(item);
                return affectedRows > 0;
            }
            else
            {
                return false;
            }
        }

        public bool Update(Entities.Appointment item)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Entities.Appointment item)
        {
            throw new NotImplementedException();
        }

        public List<Entities.Appointment> GetAll()
        {
            throw new NotImplementedException();
        }

        public Entities.Appointment Get(int id)
        {
            throw new NotImplementedException();
        }

        //public bool search(Appointment item)
        //{
        //    int affectedRows = 0;
        //    if (item.Doctor.DoctorID > 0 && item.Poorly.Personel.PatientID > 0 && item.DateOfAppointment != null &&
        //        item.Status == true)
        //    {
        //        affectedRows = _appointment.search(item.Doctor.DoctorID, item.Poorly.Personel.PatientID);
        //        return affectedRows;
        //    }
        //}
    }
}

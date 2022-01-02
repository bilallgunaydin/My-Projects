using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
  public  class Doctor
    {
        public int DoctorID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
        public HospitalClinicExaminationPlace HospitalClinicExaminationPlaceID { get; set; }

        public Doctor()
        {
            HospitalClinicExaminationPlaceID = new HospitalClinicExaminationPlace();
        }
    }
}

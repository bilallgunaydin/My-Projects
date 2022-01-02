using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class HospitalClinicExaminationPlace
    {
        public int ID { get; set; }
        public Clinic ClinicID { get; set; }
        public Hospital HospitalID { get; set; }
        public ExaminationPlace ExaminationPlaceID { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public HospitalClinicExaminationPlace()
        {
            ClinicID = new Clinic();
            HospitalID = new Hospital();
            ExaminationPlaceID = new ExaminationPlace();
            StartTime = new DateTime();
            EndTime = new DateTime();
        }
    }
}

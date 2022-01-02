using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Entities;

namespace BusinessLayer
{
    public class ExaminationPlaceBLL:IBusiness<Entities.ExaminationPlace,Int32>
    {
        ExaminationPlaceDLL _exa;

        public ExaminationPlaceBLL()
        {
            _exa = new ExaminationPlaceDLL();
        }

        public bool Insert(ExaminationPlace item)
        {
            throw new NotImplementedException();
        }

        public bool Update(ExaminationPlace item)
        {
            throw new NotImplementedException();
        }

        public bool Delete(ExaminationPlace item)
        {
            throw new NotImplementedException();
        }

        public List<ExaminationPlace> GetAll()
        {
            throw new NotImplementedException();
        }

        public ExaminationPlace Get(int id)
        {
            throw new NotImplementedException();
        }
        public object GetAll(HospitalClinicExaminationPlace exam)
        {
            List<ExaminationPlace> examList = _exa.GetAll(exam);
            return examList;
        }

        public object GetAll(Hospital hospital,Clinic clinic)
        {
            List<ExaminationPlace> examList = _exa.GetAll(hospital,clinic);
            return examList;
        }
    }
}

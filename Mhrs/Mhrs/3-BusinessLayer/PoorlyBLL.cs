using System;
using System.Collections.Generic;
using Entities;
using Entities;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class PoorlBLL : IBusiness<Entities.Poorly, Int32>
    {
        PoorlyDLL _poorly;
        public PoorlBLL()
        {
            _poorly = new  PoorlyDLL();
        }
        public bool Insert(Poorly item)
        {
            if (string.IsNullOrWhiteSpace (item.Personel.FirstName ) && string.IsNullOrWhiteSpace(item.Personel.LastName) && item.Personel.Gender == null  && string.IsNullOrWhiteSpace(item.Personel.TCNumber) && DateTime.Now.Year- item.Personel.BirthDate.Year>15 && (item.Contact.MobilePhone==null || item.Contact.LandPhone==null) && string.IsNullOrWhiteSpace(item.Contact.Email) && string.IsNullOrWhiteSpace(item.Safety.Password) && string.IsNullOrWhiteSpace(item.Safety.SecurityQuestion.Question) && string.IsNullOrWhiteSpace(item.Safety.Answer))
            {
                return false;
            }
            int affectedRows = 0;
            affectedRows = _poorly.insert(item);

            return affectedRows > 0;

        }
        public bool MailControl(Poorly item , out Poorly outPoorly)
        {
            outPoorly = new Poorly();
            if(string.IsNullOrWhiteSpace(item.Contact.Email) && string.IsNullOrWhiteSpace(item.Personel.TCNumber))
                return false;
            int affectedRows = 0;
            affectedRows = _poorly.MailControl(item, out outPoorly);
            return affectedRows > 0;
        }

        public bool Update( Poorly item)
        {
            if (string.IsNullOrWhiteSpace(item.Personel.FirstName) && string.IsNullOrWhiteSpace(item.Personel.LastName) && item.Personel.Gender == null && string.IsNullOrWhiteSpace(item.Personel.TCNumber) && item.Personel.PatientID == null)
            {
                return false;
            }
            int affectedRows = 0;
            affectedRows = _poorly.update(item);

            return affectedRows > 0;
        }

        public bool Get(Poorly poorly, out int affectedRows)
        {
             affectedRows = _poorly.Get(poorly);
            return affectedRows > 0;
        }

        public bool Delete( Poorly item)
        {
            int affectedRows = _poorly.delete(item);
            return affectedRows > 0;
        }

        public List<Poorly> GetAll()
        {
            List<Poorly> poorlyList = _poorly.GetAll();
            return poorlyList;
        }

        public Poorly Get(int id)
        {
            Poorly poorly = _poorly.Get(id);
            return poorly;
        }
    }
}

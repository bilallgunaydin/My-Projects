using DataAccessLayer;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;


namespace BusinessLayer
{
    public class ManagerBLL : IBusiness<Manager>
    {
        UnitOfWork _uow;
        Manager _manager;
        public ManagerBLL()
        {
            _uow = new UnitOfWork();
            _manager = new Manager();

        }
        /// <summary>
        /// Manager eklemek için kullanılır.
        /// </summary>
        /// <param name="item">Manager tipinde parametre alır.</param>
        /// <returns></returns>
        public bool Add(Manager item)
        {
            if (!string.IsNullOrWhiteSpace(item.FirstName) && !string.IsNullOrWhiteSpace(item.LastName))
            {
                item.Mail = item.FirstName.Substring(0, 3) + "." + item.LastName.Substring(0, 3) + "@ELessonSelection.com";
                item.Password = item.FirstName.Substring(0, 3) + item.LastName.Substring(0, 3);
                item.isPassive = false;
                _uow.ManagerRepository.Add(item);
                return _uow.ApplyChanges();
            }
            return false;
        }


        /// <summary>
        /// Manager silmek için kullanılır.Normalde remove metodu kullanılması gerekir. Ancak veri tabanı ile işlem yapılıyorsa silmek yerine onu pasif hale getirmek veri kaybına ve tablolar arasındaki ilişkiye zarar vermez.
        /// </summary>
        /// <param name="item">Manager tipinde parametre alır.</param>
        /// <returns></returns>
        public bool Remove(Manager item)
        {
            if (item != null)
            {
                item.isPassive = true;
                _uow.ManagerRepository.Update(item);
                return _uow.ApplyChanges();
            }
            return false;
        }


        /// <summary>
        /// Var olan Manager'ları güncellemek için kullanılır.
        /// </summary>
        /// <param name="item">Manager tipinde parametre alır.</param>
        /// <returns></returns>
        public bool Update(Manager item)
        {
            if (!string.IsNullOrWhiteSpace(item.FirstName) && !string.IsNullOrWhiteSpace(item.LastName) && !string.IsNullOrWhiteSpace(item.Password))
            {
                item.AccountTypeID = 3;
                _uow.ManagerRepository.Update(item);
                return _uow.ApplyChanges();
            }
            return false;
        }
        /// <summary>
        /// id'si ile eşleşen Manager tipini döndürür.
        /// </summary>
        /// <param name="id">int id</param>
        /// <returns></returns>
        public Manager Get(int id)
        {
            return _uow.ManagerRepository.Get(id);
        }

        /// <summary>
        /// Pasif olmayan tüm Lesson tiplerini liste olarak döndürür.
        /// </summary>
        /// <returns></returns>
        public List<Manager> GetAll()
        {
            return _uow.ManagerRepository.GetAll().Where(m => m.isPassive == false).ToList();
        }
        /// <summary>
        /// Kullanıcı girişi için gerekli olan mail adresi ve parolayı kontrol eder. 
        /// </summary>
        /// <param name="mail">string mail</param>
        /// <param name="password">string password</param>
        /// <returns></returns>
        //public Manager CheckLogin(string mail, string password)
        //{
        //    _manager = _uow.ManagerRepository.GetAll().Where(m => m.Mail == mail && m.Password == password && m.isPassive == false).First();
        //    return _manager;

        //}

        /// <summary>
        /// Kullanıcının sayfa yönetimiyle iletişim kurmasını sağlar.
        /// </summary>
        /// <param name="email">string email</param>
        /// <param name="password">string password</param>
        /// <param name="subject">string subject</param>
        /// <param name="content">string content</param>
        /// <returns></returns>
        public bool Contact(string email,string password,string subject, string content)
        {
            _manager = _uow.ManagerRepository.GetAll().Where(m => m.Mail == email && m.Password == password && m.isPassive == false).FirstOrDefault();
            try
            {
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                MailMessage mesaj = new MailMessage();
                mesaj.To.Add("bilallgunaydin@gmail.com");
                mesaj.From = new MailAddress("bilallgunaydin@gmail.com");
                mesaj.Subject = subject;
                mesaj.Body = string.Format(_manager.FullName + " adlı kullanıcının mesajı: " + content);
                NetworkCredential guvenlik = new NetworkCredential("elessonselection@gmail.com", "ELesson__");
                client.Credentials = guvenlik;
                client.EnableSsl = true;
                client.Send(mesaj);
            }
                
            catch (Exception)
            {

                return false;
            }
            return true;
        }
        /// <summary>
        /// Kullanıcının şifresini kontrol eder ve kullancının parolasını mail olarak kendisine gönderir.
        /// </summary>
        /// <param name="email">string email</param>
        /// <returns></returns>
        public bool GetPassword(string email)
        {
            _manager = _uow.ManagerRepository.GetAll().Where(m => m.Mail == email && m.isPassive == false).FirstOrDefault();
            try
            {
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                MailMessage mesaj = new MailMessage();
                mesaj.To.Add(_manager.Mail);
                mesaj.From = new MailAddress(_manager.Mail);
                mesaj.Subject = "Parola Hatırlatma";
                mesaj.Body = string.Format("Kullanıcı şifreniz : " + _manager.Password);
                NetworkCredential guvenlik = new NetworkCredential("elessonselection@gmail.com", "ELesson__");
                client.Credentials = guvenlik;
                client.EnableSsl = true;
                client.Send(mesaj);
            }
            catch (Exception)
            {

                return false;
            }
            return true;
        }
        
    }
}

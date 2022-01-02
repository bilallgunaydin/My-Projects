using DataAccessLayer;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class TeacherBLL : IBusiness<Teacher>
    {
        UnitOfWork _uow;
        Teacher _teacher;

        public TeacherBLL()
        {
            _uow = new UnitOfWork();
            _teacher = new Teacher();

        }
        /// <summary>
        /// Teacher eklemek için kullanılır.
        /// </summary>
        /// <param name="item">Teacher tipinde parametre alır.</param>
        /// <returns></returns>
        public bool Add(Teacher item)
        {

            if (!string.IsNullOrWhiteSpace(item.FirstName) && !string.IsNullOrWhiteSpace(item.LastName))
            {
                item.Mail = item.FirstName.Substring(0, 3) + "." + item.LastName.Substring(0, 3) + "@ELessonSelection.com";
                item.Password = item.FirstName.Substring(0, 3) + item.LastName.Substring(0, 3);
                item.isPassive = false;
                item.AccountTypeID = 2;
                _uow.TeacherRepository.Add(item);
                return _uow.ApplyChanges();

            }

            return false;
        }

        /// <summary>
        /// Teacher silmek için kullanılır.Normalde remove metodu kullanılması gerekir. Ancak veri tabanı ile işlem yapılıyorsa silmek yerine onu pasif hale getirmek veri kaybına ve tablolar arasındaki ilişkiye zarar vermez.
        /// </summary>
        /// <param name="item">Teacher tipinde parametre alır.</param>
        /// <returns></returns>
        public bool Remove(Teacher item)
        {
            if (item != null)
            {
                item.isPassive = true;
                _uow.TeacherRepository.Update(item);
                return _uow.ApplyChanges();
            }
            else
            {
                return false;
            }

        }
        /// <summary>
        /// Var olan Teacher'ları güncellemek için kullanılır.
        /// </summary>
        /// <param name="item">Teacher tipinde parametre alır.</param>
        /// <returns></returns>
        public bool Update(Teacher item)
        {
            if (!string.IsNullOrWhiteSpace(item.FirstName) && !string.IsNullOrWhiteSpace(item.LastName) && !string.IsNullOrWhiteSpace(item.Password))
            {
                _uow.TeacherRepository.Update(item);
                return _uow.ApplyChanges();
            }
            return false;
        }
        /// <summary>
        /// id'si ile eşleşen Teacher tipini döndürür.
        /// </summary>
        /// <param name="id">int id</param>
        /// <returns></returns>
        public Teacher Get(int id)
        {
            return _uow.TeacherRepository.Get(id);
        }

        /// <summary>
        /// Pasif olmayan tüm Teacher tiplerini liste olarak döndürür.
        /// </summary>
        /// <returns></returns>
        public List<Teacher> GetAll()
        {
            return _uow.TeacherRepository.GetAll().Where(t => t.isPassive == false).ToList();
        }

        /// <summary>
        /// Kullanıcı girişi için gerekli olan mail adresi ve parolayı kontrol eder. 
        /// </summary>
        /// <param name="mail">string mail</param>
        /// <param name="password">string password</param>
        /// <returns></returns>
        public Teacher CheckLogin(string mail, string password)
        {
            _teacher = _uow.TeacherRepository.GetAll().Where(t => t.Mail == mail && t.Password == password && t.isPassive == false).FirstOrDefault();
            return _teacher;
        }

        /// <summary>
        /// Kullanıcının sayfa yönetimiyle iletişim kurmasını sağlar.
        /// </summary>
        /// <param name="email">string email</param>
        /// <param name="password">string password</param>
        /// <param name="subject">string subject</param>
        /// <param name="content">string content</param>
        /// <returns></returns>
        public bool Contact(string email, string password, string subject, string content)
        {
            _teacher = _uow.TeacherRepository.GetAll().Where(m => m.Mail == email && m.Password == password && m.isPassive == false).FirstOrDefault();
            try
            {
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                MailMessage mesaj = new MailMessage();
                mesaj.To.Add("bilallgunaydin@gmail.com");
                mesaj.From = new MailAddress("bilallgunaydin@gmail.com");
                mesaj.Subject = subject;
                mesaj.Body = string.Format(_teacher.FullName + " adlı kullanıcının mesajı: " + content);
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
        /// 
        public bool GetPassword(string email)
        {
            _teacher = _uow.TeacherRepository.GetAll().Where(m => m.Mail == email && m.isPassive == false).FirstOrDefault();
            try
            {
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                MailMessage mesaj = new MailMessage();
                mesaj.To.Add(_teacher.Mail);
                mesaj.From = new MailAddress(_teacher.Mail);
                mesaj.Subject = "Parola Hatırlatma";
                mesaj.Body = string.Format("Kullanıcı şifreniz : " + _teacher.Password);
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

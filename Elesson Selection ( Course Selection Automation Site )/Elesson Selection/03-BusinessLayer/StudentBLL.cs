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
    public class StudentBLL:IBusiness<Student>
    {
        UnitOfWork _uow;
        Student _student;
        public StudentBLL()
        {
            _uow = new UnitOfWork();
            _student = new Student();
        }
        /// <summary>
        /// Student eklemek için kullanılır.
        /// </summary>
        /// <param name="item">Student tipinde parametre alır.</param>
        /// <returns></returns>
        public bool Add(Student item)
        {
            if (!string.IsNullOrWhiteSpace(item.FirstName) && !string.IsNullOrWhiteSpace(item.LastName))
            {
                item.Mail = item.FirstName.Substring(0, 3) + "." + item.LastName.Substring(0, 3) + "@ELessonSelection.com";
                item.Password = item.FirstName.Substring(0, 3) + item.LastName.Substring(0, 3);
                item.isPassive = false;
                item.AccountTypeID = 1;
                _uow.StudentRepository.Add(item);
                return _uow.ApplyChanges();
            }
            return false;
        }

        /// <summary>
        /// Student silmek için kullanılır.Normalde remove metodu kullanılması gerekir. Ancak veri tabanı ile işlem yapılıyorsa silmek yerine onu pasif hale getirmek veri kaybına ve tablolar arasındaki ilişkiye zarar vermez.
        /// </summary>
        /// <param name="item">Student tipinde parametre alır.</param>
        /// <returns></returns>
        public bool Remove(Student item)
        {
            if (item != null)
            {
                item.isPassive = true;
                _uow.StudentRepository.Update(item);
                return _uow.ApplyChanges();
            }
            return false;
        }
        /// <summary>
        /// Var olan Student'ları güncellemek için kullanılır.
        /// </summary>
        /// <param name="item">Student tipinde parametre alır.</param>
        /// <returns></returns>
        public bool Update(Student item)
        {
            if (!string.IsNullOrWhiteSpace(item.FirstName) && !string.IsNullOrWhiteSpace(item.LastName) && !string.IsNullOrWhiteSpace(item.Password))
            {
                _uow.StudentRepository.Update(item);
                return _uow.ApplyChanges();
            }
            return false;
        }
        /// <summary>
        /// id'si ile eşleşen Student tipini döndürür.
        /// </summary>
        /// <param name="id">int id</param>
        /// <returns></returns>
        public Student Get(int id)
        {
            return _uow.StudentRepository.Get(id);
        }

        /// <summary>
        /// Pasif olmayan tüm Student tiplerini liste olarak döndürür.
        /// </summary>
        /// <returns></returns>
        public List<Student> GetAll()
        {
            return _uow.StudentRepository.GetAll().Where(s => s.isPassive == false).ToList();
        }
        /// <summary>
        /// Kullanıcı girişi için gerekli olan mail adresi ve parolayı kontrol eder. 
        /// </summary>
        /// <param name="mail">string mail</param>
        /// <param name="password">string password</param>
        /// <returns></returns>
        public Student CheckLogin(string mail, string password)
        {
            _student = _uow.StudentRepository.GetAll().Where(s => s.Mail == mail && s.Password == password && s.isPassive==false).FirstOrDefault();
            return _student;
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
            _student = _uow.StudentRepository.GetAll().Where(m => m.Mail == email && m.Password == password && m.isPassive == false).FirstOrDefault();
            try
            {
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                MailMessage mesaj = new MailMessage();
                mesaj.To.Add("bilallgunaydin@gmail.com");
                mesaj.From = new MailAddress("bilallgunaydin@gmail.com");
                mesaj.Subject = subject;
                mesaj.Body = string.Format(_student.FullName + " adlı kullanıcının mesajı: " + content);
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
            _student = _uow.StudentRepository.GetAll().Where(m => m.Mail == email && m.isPassive==false).FirstOrDefault();
            try
            {
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                MailMessage mesaj = new MailMessage();
                mesaj.To.Add(_student.Mail);
                mesaj.From = new MailAddress(_student.Mail);
                mesaj.Subject = "Parola Hatırlatma";
                mesaj.Body = string.Format("Kullanıcı şifreniz : " + _student.Password);
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
        /// Belirli bir derse ait tüm öğrencileri getirir.
        /// </summary>
        /// <param name="id">Dersin ID'si</param>
        /// <returns></returns>
        public List<Student> GetALL(int id)
        {
            List<Student> Students = _uow.StudentRepository.GetAll().Where(s => s.Lessons.Any(l => l.ID == id)).ToList();
            return Students;
        }
        public bool AddLesson(Student item, Lesson lesson)
        {
            if (item != null && lesson != null)
            {
                
                if (item.LessonCredit <= 20)
                {
                    item.LessonCredit = item.LessonCredit + lesson.Credit;
                    item.Lessons.Add(lesson);
                    _uow.StudentRepository.Update(item);
                    return _uow.ApplyChanges();
                }

                return false;
            }
            return false;
        }
    }
}

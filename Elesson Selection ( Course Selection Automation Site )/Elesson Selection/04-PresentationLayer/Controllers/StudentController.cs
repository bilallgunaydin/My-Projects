using BusinessLayer;
using Entities;
using PresentationLayer.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PresentationLayer.Controllers
{
    public class StudentController : Controller
    {
        StudentBLL _studentBLL;
        LessonBLL _lessonBLL;


        public StudentController()
        {
            _studentBLL = new StudentBLL();
            _lessonBLL = new LessonBLL();

        }
        public ActionResult Index()
        {
            int loginStudentId = Convert.ToInt32(Session["PersonId"]);
            Student loginStudent = _studentBLL.Get(loginStudentId);
            object LoginStudentName = loginStudent.FullName;
            return View(LoginStudentName);
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string userId, string password)
        {
            LoginHelper helper = new LoginHelper();
            bool loginSuccess = helper.LoginUser(userId, password, System.Web.HttpContext.Current);
            if (loginSuccess)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.ErrorMessage = "Kullanıcı adı ve şifre kombinasyonu hatalı";
                return View();
            }
        }
        //public ActionResult LoginUser()
        //{
        //    int loginStudentId = Convert.ToInt32(Session["PersonId"]);
        //    Student loginStudent = _studentBLL.Get(loginStudentId);
        //    return PartialView(loginStudent);
        //}
        public ActionResult LogOut()
        {
            Session["PersonId"] = null;
            Response.Cookies["mail"].Expires = DateTime.Now.AddYears(-1);
            Response.Cookies["Password"].Expires = DateTime.Now.AddYears(-1);

            return RedirectToAction("Login", "Student");
        }
        public ActionResult ForgetPassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ForgetPassword(string forgetEmail)
        {
            bool Result = _studentBLL.GetPassword(forgetEmail);
            if (Result)
            {
                TempData["Message"] = "Kullanıcı bilgileriniz başarıyla mail adresinize gönderildi.";

            }
            else
            {
                TempData["ErrorMessage"] = "Girdiğiniz mail adresi yanlış veya sistemde böyle bir mail adresi mevcut değil.";

            }
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Contact(string subject, string content)
        {
            int loginManagerId = Convert.ToInt32(Session["PersonId"]);
            Student loginMan = _studentBLL.Get(loginManagerId);
            bool result = _studentBLL.Contact(loginMan.Mail, loginMan.Password, subject, content);
            if (result)
            {
                TempData["Message"] = "Mesajınız başarıyla iletilmiştir.";
                return RedirectToAction("Contact", "Student");
            }
            else
            {
                TempData["ErrorMessage"] = "Mesajınız iletilirken bir hata oluştu. Lütfen daha sonra tekrar deneyin.";
                return RedirectToAction("Contact", "Student");
            }

        }
        public ActionResult UpdateInformation()
        {
            int loginStudentId = Convert.ToInt32(Session["PersonId"]);
            Student loginStudent = _studentBLL.Get(loginStudentId);

            return View(loginStudent);
        }
        public ActionResult Update(string firstName, string lastName, string password, int id)
        {
            Student student = _studentBLL.Get(id);
            student.FirstName = firstName;
            student.LastName = lastName;
            student.Password = password;
            bool success = _studentBLL.Update(student);
            if (success)
            {
                TempData["Message"] = "Kullanıcı bilgileriniz başarıyla güncellenmiştir.";
                return RedirectToAction("UpdateInformation", "Student");
            }
            else
            {
                TempData["ErrorMessage"] = "Kullanıcı bilgileriniz güncellenirken bir hata oluştu, lütfen tekrar deneyin";
                return RedirectToAction("UpdateInformation", "Student");
            }
        }
        public ActionResult LessonInformation()
        {
            int loginStudentId = Convert.ToInt32(Session["PersonId"]);
            Student loginstudent = _studentBLL.Get(loginStudentId);
            List<Lesson> lesson = _lessonBLL.GetALL(loginstudent.ID);
            ViewBag.LessonCredit = loginstudent.LessonCredit;
            return View(lesson);
        }
        public ActionResult LessonSelection()
        {
            int loginStudentId = Convert.ToInt32(Session["PersonId"]);
            Student loginStudent = _studentBLL.Get(loginStudentId);
            List<Lesson> Lessons = _lessonBLL.LessonSelection(loginStudent.ID);
            return View(Lessons);
        }

        [HttpPost]
        public ActionResult LessonSelection(int[] LessonChecked)
        {
            int loginStudentId = Convert.ToInt32(Session["PersonId"]);
            Student loginStudent = _studentBLL.Get(loginStudentId);

            for (int i = 0; i < LessonChecked.Length; i++)
            {
                Lesson lesson = _lessonBLL.Get(LessonChecked[i]);
                bool success = _studentBLL.AddLesson(loginStudent, lesson);
                if (success)
                {
                    _lessonBLL.AddStudent(lesson, loginStudent);
                    TempData["Message"] = "Seçtiğiniz ders başarıyla eklenmiştir.";
                    
                }
                else
                {
                    TempData["ErrorMessage"] = "Seçtiğiniz ders toplam kredi sınırını aşıyor. Lütfen mevcut ders listenizi kontrol edin.";
                }

            }
            return RedirectToAction("LessonSelection", "Student");
        }
    }
}
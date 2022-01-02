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
    public class TeacherController : Controller
    {
        TeacherBLL _teacherBLL;
        StudentBLL _studentBLL;
        public TeacherController()
        {
            _teacherBLL = new TeacherBLL();
            _studentBLL = new StudentBLL();
        }
        public ActionResult Index()
        {
            int loginTeacherId = Convert.ToInt32(Session["PersonId"]);
            Teacher loginTeacher = _teacherBLL.Get(loginTeacherId);
            object loginTeacherName = loginTeacher.FullName;
            return View(loginTeacherName);
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
        //    int loginTeacherId = Convert.ToInt32(Session["PersonId"]);
        //    Teacher loginTeacher = _teacherBLL.Get(loginTeacherId);
        //    return PartialView(loginTeacher);
        //}
        public ActionResult LogOut()
        {
            Session["PersonId"] = null;
            Response.Cookies["mail"].Expires = DateTime.Now.AddYears(-1);
            Response.Cookies["Password"].Expires = DateTime.Now.AddYears(-1);

            return RedirectToAction("Login", "Teacher");
        }
        public ActionResult ForgetPassword()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ForgetPassword(string forgetEmail)
        {
            bool Result = _teacherBLL.GetPassword(forgetEmail);
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
            Teacher loginMan = _teacherBLL.Get(loginManagerId);
            bool result = _teacherBLL.Contact(loginMan.Mail, loginMan.Password, subject, content);
            if (result)
            {
                TempData["Message"] = "Mesajınız başarıyla iletilmiştir.";
                return RedirectToAction("Contact", "Teacher");
            }
            else
            {
                TempData["ErrorMessage"] = "Mesajınız iletilirken bir hata oluştu. Lütfen daha sonra tekrar deneyin.";
                return RedirectToAction("Contact", "Teacher");
            }

        }
        public ActionResult UpdateInformation()
        {
            int loginTeacherId = Convert.ToInt32(Session["PersonId"]);
            Teacher loginStudent = _teacherBLL.Get(loginTeacherId);
            return View(loginStudent);
        }
        public ActionResult Update(string firstName, string lastName, string password, int id)
        {
            Teacher teacher = _teacherBLL.Get(id);
            teacher.FirstName = firstName;
            teacher.LastName = lastName;
            teacher.Password = password;
            bool success = _teacherBLL.Update(teacher);
            if (success)
            {
                TempData["Message"] = "Kullanıcı bilgileriniz başarıyla güncellenmiştir.";
                return RedirectToAction("UpdateInformation", "Teacher");
            }
            else
            {
                TempData["ErrorMessage"] = "Kullanıcı bilgileriniz güncellenirken bir hata oluştu, lütfen tekrar deneyin";
                return RedirectToAction("UpdateInformation", "Teacher");
            }
        }
        public ActionResult LessonInformation()
        {
            int loginTeacherID = Convert.ToInt32(Session["PersonId"]);
            Teacher loginTeacher = _teacherBLL.Get(loginTeacherID);
            List<Student> StudentList = _studentBLL.GetALL(loginTeacher.LessonID);
            ViewBag.LessonName = loginTeacher.Lesson.Name;
            return View(StudentList);
        }
	}
}
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
    public class ManagerController : Controller
    {
        ManagerBLL _managerBLL;
        TeacherBLL _teacherBLL;
        StudentBLL _studentBLL;
        LessonBLL _lessonBLL;
        Student student;
        Lesson lesson;


        public ManagerController()
        {
            _managerBLL = new ManagerBLL();
            _teacherBLL = new TeacherBLL();
            _studentBLL = new StudentBLL();
            _lessonBLL = new LessonBLL();

        }
        public ActionResult Index()
        {
            int loginManagerId = Convert.ToInt32(Session["PersonId"]);
            Manager loginMan = _managerBLL.Get(loginManagerId);
            object LoginManagerName = loginMan.FullName;

            return View(LoginManagerName);
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
        //    int loginManagerId = Convert.ToInt32(Session["PersonId"]);
        //    Manager loginMan = _managerBLL.Get(loginManagerId);
        //    return PartialView(loginMan);
        //}
        public ActionResult LogOut()
        {
            Session["PersonId"] = null;
            Response.Cookies["mail"].Expires = DateTime.Now.AddYears(-1);
            Response.Cookies["Password"].Expires = DateTime.Now.AddYears(-1);

            return RedirectToAction("Login", "Manager");
        }
        public ActionResult ForgetPassword()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ForgetPassword(string forgetEmail)
        {
            bool Result = _managerBLL.GetPassword(forgetEmail);
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
            Manager loginMan = _managerBLL.Get(loginManagerId);
            bool result = _managerBLL.Contact(loginMan.Mail, loginMan.Password, subject, content);
            if (result)
            {
                TempData["Message"] = "Mesajınız başarıyla iletilmiştir.";
                return RedirectToAction("Contact", "Manager");
            }
            else
            {
                TempData["ErrorMessage"] = "Mesajınız iletilirken bir hata oluştu. Lütfen daha sonra tekrar deneyin.";
                return RedirectToAction("Contact", "Manager");
            }
           
        }

        public ActionResult UpdateInformation()
        {
            int loginManagerId = Convert.ToInt32(Session["PersonId"]);
            Manager loginMan = _managerBLL.Get(loginManagerId);

            return View(loginMan);
        }
        public ActionResult Update(string firstName, string lastName, string password, int Id)
        {
            Manager manager = _managerBLL.Get(Id);
            manager.FirstName = firstName;
            manager.LastName = lastName;
            manager.Password = password;
            bool success = _managerBLL.Update(manager);
            if (success)
            {
                TempData["Message"] = "Kullanıcı bilgileriniz başarıyla güncellenmiştir.";
                return RedirectToAction("UpdateInformation", "Manager");
            }
            else
            {
                TempData["ErrorMessage"] = "Kullanıcı bilgileriniz güncellenirken bir hata oluştu, lütfen tekrar deneyin";
                return RedirectToAction("UpdateInformation", "Manager");
            }
        }

        public ActionResult AddTeacher()
        {
            List<Lesson> lessonList = _lessonBLL.GetAll();
            SelectList LessonSelectList = new SelectList(lessonList, "ID", "Name");
            ViewBag.Lessons = LessonSelectList;
            return View();
        }

        [HttpPost]
        public ActionResult AddTeacherr(Teacher teacher)
        {

            bool Success = _teacherBLL.Add(teacher);
            if (Success)
            {
                Lesson selectLesson = _lessonBLL.Get(teacher.LessonID);

                selectLesson.TeacherID = teacher.ID;
                _lessonBLL.Update(selectLesson);
                TempData["Message"] = "Başarıyla öğretmen eklediniz.";
                return RedirectToAction("AddTeacher", "Manager");


            }
            else
            {
                TempData["ErrorMessage"] = "Öğretmen eklerken bir hata oluştu, lütfen tekrar deneyin";
                return RedirectToAction("AddTeacher", "Manager");
            }

        }
        public ActionResult UpdateTeacher()
        {
            List<Teacher> model = _teacherBLL.GetAll();
            return View(model);
        }
        public ActionResult UpdateTeacherr(int id)
        {
            Teacher deleteTeacher = _teacherBLL.Get(id);
            Lesson deleteLessonTeacher = _lessonBLL.Get(deleteTeacher.LessonID);
            if (deleteTeacher != null && deleteLessonTeacher != null)
            {
                
                bool Success = _teacherBLL.Remove(deleteTeacher);
                if (Success)
                {
                    deleteLessonTeacher.TeacherID = null;
                    bool lessonSuccess = _lessonBLL.Update(deleteLessonTeacher);
                    if(lessonSuccess)
                    TempData["Message"] = "Silme işlemi başarıyla gerçekleşti.";
                    return RedirectToAction("UpdateTeacher", "Manager");
                }

                else
                {
                    TempData["ErrorMessage"] = "Silme işlemi yapılırken bir hata oluştu, lütfen tekrar deneyin";
                    return RedirectToAction("UpdateTeacher", "Manager");
                }
            }
            else
            {
                return RedirectToAction("UpdateTeacher", "Manager");
            }
        }
        public ActionResult AddStudent()
        {
            return View();
        }
        public ActionResult AddStudentt(string firstName, string lastName)
        {
            student = new Student();
            student.FirstName = firstName;
            student.LastName = lastName;
            bool Success = _studentBLL.Add(student);
            if (Success)
            {
                TempData["Message"] = "Başarıyla öğrenci eklediniz.";
                return RedirectToAction("AddStudent", "Manager");
            }
            else
            {
                TempData["ErrorMessage"] = "Öğrenci eklerken bir hata oluştu, lütfen tekrar deneyin";
                return RedirectToAction("AddStudent", "Manager");
            }
        }
        public ActionResult UpdateStudent()
        {
            List<Student> model = _studentBLL.GetAll();
            return View(model);
        }
        public ActionResult UpdateStudentt(int id)
        {
            Student deleteStudetn = _studentBLL.Get(id);
            if (deleteStudetn != null)
            {
                bool Success = _studentBLL.Remove(deleteStudetn);
                if (Success)
                {
                    TempData["Message"] = "Silme işlemi başarıyla gerçekleşti.";
                    return RedirectToAction("UpdateStudent", "Manager");

                }
                else
                {
                    TempData["ErrorMessage"] = "Silme işlemi yapılırken bir hata oluştu, lütfen tekrar deneyin";
                    return RedirectToAction("UpdateStudent", "Manager");
                }

            }
            else
            {
                return RedirectToAction("UpdateStudent", "Manager");
            }
        }
        public ActionResult AddLesson()
        {
            return View();
        }
        public ActionResult AddLessonn(string lessonName, int lessonCredit)
        {
            lesson = new Lesson();
            lesson.Name = lessonName;
            lesson.Credit = lessonCredit;
            bool Success = _lessonBLL.Add(lesson);
            if (Success)
            {
                TempData["Message"] = "Başarıyla ders eklediniz.";
                return RedirectToAction("AddLesson", "Manager");
            }
            else
            {
                TempData["ErrorMessage"] = "Ders eklerken bir hata oluştu, lütfen tekrar deneyin";
                return RedirectToAction("AddLesson", "Manager");
            }


        }
        public ActionResult UpdateLesson()
        {
            List<Lesson> model = _lessonBLL.GetAllLesson();

            return View(model);
        }
        public ActionResult UpdateLessonn(int id)
        {
            Lesson deleteless = _lessonBLL.Get(id);
            if (deleteless != null)
            {
                bool Success = _lessonBLL.Remove(deleteless);
                if (Success)
                {
                    TempData["Message"] = "Silme işlemi başarıyla gerçekleşti.";
                    return RedirectToAction("UpdateLesson", "Manager");

                }
                else
                {
                    TempData["ErrorMessage"] = "Silme işlemi yapılırken bir hata oluştu, lütfen tekrar deneyin";
                    return RedirectToAction("UpdateLesson", "Manager");
                }

            }
            else
            {
                return RedirectToAction("UpdateLesson", "Manager");
            }
        }
    }
}
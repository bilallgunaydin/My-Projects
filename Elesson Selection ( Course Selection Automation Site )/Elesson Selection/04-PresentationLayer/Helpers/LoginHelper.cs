using BusinessLayer;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PresentationLayer.Helpers
{
    public class LoginHelper
    {
        ManagerBLL _managerBLL;
        TeacherBLL _teacherBLL;
        StudentBLL _studentBLL;
        
        public LoginHelper()
        {
            _managerBLL = new ManagerBLL();
            _teacherBLL = new TeacherBLL();
            _studentBLL = new StudentBLL();
            
        }
        internal bool LoginUser(string mail, string password, HttpContext httpContext)
        {
            //Manager manager = _managerBLL.CheckLogin(mail, password);
            Student student = _studentBLL.CheckLogin(mail, password);
            Teacher teacher = _teacherBLL.CheckLogin(mail, password);
            //if(manager!=null){
            //    httpContext.Session["PersonId"] = manager.ID;
                
            //    httpContext.Response.Cookies["mail"].Value = mail;
            //    httpContext.Response.Cookies["mail"].Expires = DateTime.Now.AddYears(1);

            //    httpContext.Response.Cookies["Password"].Value = password;
            //    httpContext.Response.Cookies["Password"].Expires = DateTime.Now.AddYears(1);
            //    return true;
            //}
            //else if (student != null)
             if (student != null)
            {
                httpContext.Session["PersonId"] = student.ID;

                httpContext.Response.Cookies["mail"].Value = mail;
                httpContext.Response.Cookies["mail"].Expires = DateTime.Now.AddYears(1);

                httpContext.Response.Cookies["Password"].Value = password;
                httpContext.Response.Cookies["Password"].Expires = DateTime.Now.AddYears(1);
                return true;
            }
            else if (teacher != null)
            {
                httpContext.Session["PersonId"] = teacher.ID;

                httpContext.Response.Cookies["mail"].Value = mail;
                httpContext.Response.Cookies["mail"].Expires = DateTime.Now.AddYears(1);

                httpContext.Response.Cookies["Password"].Value = password;
                httpContext.Response.Cookies["Password"].Expires = DateTime.Now.AddYears(1);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
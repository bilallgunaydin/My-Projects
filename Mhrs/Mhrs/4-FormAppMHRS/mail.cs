using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;

namespace FormAppMHRS
{
    class mail
    {
        internal static bool SentMail(Poorly poorly,string subject,string body)
        {
            if (poorly == null)
                return false;
            MailMessage ePosta = new MailMessage();
            ePosta.From = new MailAddress("adonetwhiteteam@gmail.com");
            ePosta.To.Add(poorly.Contact.Email);
            ePosta.Subject = subject;
            ePosta.Body = body;
            SmtpClient smtp = new SmtpClient();
            smtp.Credentials = new System.Net.NetworkCredential("adonetwhiteteam@gmail.com", "FrabRet2");
            smtp.Port = 587;
            smtp.Host = "smtp.gmail.com";
            smtp.EnableSsl = true;
            smtp.Send(ePosta);
            return true;
        }
    }
}

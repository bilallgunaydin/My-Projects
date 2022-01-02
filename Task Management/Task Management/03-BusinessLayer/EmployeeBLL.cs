using _01_Entities;
using _02_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace _03_BusinessLayer
{
    public class EmployeeBLL : IBusiness<Employees>
    {
        UnitOfWork _uow;
        Employees _employee;
        public EmployeeBLL()
        {
            _uow = new UnitOfWork();
            _employee = new Employees();
        }
        public bool Add(Employees item)
        {
            if (!string.IsNullOrWhiteSpace(item.Email) && !string.IsNullOrWhiteSpace(item.Password) && !string.IsNullOrWhiteSpace(item.FirstName) && !string.IsNullOrWhiteSpace(item.LastName) && !string.IsNullOrWhiteSpace(item.GSM))
            {
                _uow.EmployeeRepository.Add(item);
                return _uow.ApplyChanges();
            }
            return false;
        }

        public bool Remove(Employees item)
        {
            _uow.EmployeeRepository.Remove(item);
            return _uow.ApplyChanges();
        }

        public bool Update(Employees item)
        {
            if (!string.IsNullOrWhiteSpace(item.Email) && !string.IsNullOrWhiteSpace(item.Password) && !string.IsNullOrWhiteSpace(item.FirstName) && !string.IsNullOrWhiteSpace(item.LastName) && !string.IsNullOrWhiteSpace(item.GSM))
            {
                _uow.EmployeeRepository.Update(item);
                return _uow.ApplyChanges();
            }
            return false;

        }

        public Employees Get(int id)
        {
            return _uow.EmployeeRepository.Get(id);
        }

        public List<Employees> GetAll()
        {
            return _uow.EmployeeRepository.GetAll();
        }
        public int GetLogin(string email, string password)
        {
            _employee = _uow.EmployeeRepository.Get(email, password);
            return _employee.EmployeeID;

        }
        public bool GetPassword(string email)
        {
            _employee = _uow.EmployeeRepository.GetAll().Where(x => x.Email == email).FirstOrDefault();
            try
            {
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                MailMessage mesaj = new MailMessage();
                mesaj.To.Add(_employee.Email);
                mesaj.From = new MailAddress(_employee.Email);
                mesaj.Subject = "Parola Hatırlatma";
                mesaj.Body = string.Format("Kullanıcı şifreniz : " + _employee.Password);
                NetworkCredential guvenlik = new NetworkCredential("redtaskmanagement@gmail.com", "RedTask_");
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

        public List<Employees> GetAllSelectType(int id)
        {
            return _uow.EmployeeRepository.GetAll().Where(x => x.AccountTypeID == id).ToList();
        }
        public int GetAllNameControl(string item)
        {
            return _uow.EmployeeRepository.GetAll().Where(x => x.FullName.Contains(item.ToString())).Select(x => x.EmployeeID).FirstOrDefault();
        }
        public List<Employees> GetAllAccountType()
        {
            return _uow.EmployeeRepository.GetAll().Where(x => x.AccountTypeID != 1 && x.AccountTypeID != 2).ToList();
        }
        public object GetAllSelect()
        {
            return _uow.EmployeeRepository.GetAll().Select(x => new
            {
                x.EmployeeID,
                FullName = x.FirstName + " " + x.LastName,
                x.GSM,
                x.Email,
                ÇalışanPozisyonu = x.AccountType.Name
            }
                ).ToList();
        }
        public object GetMissionEmployee()
        {
            return _uow.EmployeeRepository.GetAll().Where(x => x.AccountTypeID == 4 || x.AccountTypeID == 5).ToList();
        }


    }
}




using _01_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_DataAccessLayer.Repository
{
    public class EmployeeRepository : BaseRepository<Employees>
    {
        TaskManagementContext _context;
        internal EmployeeRepository(TaskManagementContext context)
            : base(context)
        {
            _context = context;

        }
        public Employees Get(string Email, string Password)
        {  
            if (Email != null && Password != null)
            {
                return _context.Set<Employees>().Where(e => e.Email == Email && e.Password == Password).FirstOrDefault();
            }
            else
            {
                
                return null;
            }
        }
        
       
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Teacher
    {
        public Teacher()
        {
            this.isPassive = false;
        }
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get { return FirstName + " " + LastName; } }
        public string Mail { get; set; }
        public string Password { get; set; }
        public bool isPassive { get; set; }
        public int AccountTypeID { get; set; }
        public int LessonID { get; set; }

        //Navigation Property
        public virtual Lesson Lesson { get; set; }
        public virtual AccountType AccountType { get; set; }
    }
}

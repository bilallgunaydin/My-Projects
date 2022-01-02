using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    public class Student
    {
        public Student()
        {
            this.isPassive = false;
            Lessons = new HashSet<Lesson>();
        }
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get { return FirstName + " " + LastName; } }
        public string Mail { get; set; }
        public string Password { get; set; }
        public Nullable<int> LessonCredit { get; set; }
        public bool isPassive { get; set; }
        public int AccountTypeID { get; set; }
        
        //Navigation Property
        
        public virtual AccountType AccountType { get; set; }
        public virtual ICollection<Lesson> Lessons { get; set; }
    }
}

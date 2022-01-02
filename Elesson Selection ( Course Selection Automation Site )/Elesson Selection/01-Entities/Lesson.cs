using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Lesson
    {
        public Lesson()
        {
            Students = new HashSet<Student>();
            this.isPassive = false;
        }
        public int ID { get; set; }
        public string Name { get; set; }
        public int Credit { get; set; }
        public bool isPassive { get; set; }
        public Nullable<int> TeacherID { get; set; }

        //Navigation Property
        public virtual Teacher Teacher { get; set; }
        public virtual ICollection<Student> Students { get; set; }
        
    }
}

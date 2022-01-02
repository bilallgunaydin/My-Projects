using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Entities
{
    public class Tasks
    {
        public int TaskID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ProjectID { get; set; }
        public virtual  Project Project { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int SituaitionID { get; set; }
        public virtual Situaition Situaition { get; set; }
        public int ManagerID { get; set; }
        public virtual Employees Manager { get; set; }
        public int? EmployeeID { get; set; }
        public virtual Employees Employee { get; set; }
        public bool isFinish { get; set; }
    }
}

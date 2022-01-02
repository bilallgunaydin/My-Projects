using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Entities
{
    public class Project
    {
        public int ProjectID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int EmployeeID { get; set; }
        public virtual Employees Employee { get; set; }
        public int CustomerID { get; set; }
        public virtual Customer Customer { get; set; }
        public int TeamLeadID { get; set; }
        public virtual Employees TeamLead { get; set; }
        public DateTime GenerateDate { get; set; }
        public DateTime DeadLine { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsCancel { get; set; }
        public bool IsFinish { get; set; }
    }
}

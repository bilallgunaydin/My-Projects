using _01_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_DataAccessLayer.Repository
{
    public class TaskRepository:BaseRepository<Tasks>
    {        
        TaskManagementContext _taskContext;
        internal TaskRepository(TaskManagementContext context):base(context)
        {
            _taskContext = context;
            
        }
        public object GetALL(int id)
        {
            
            return _taskContext.Set<Tasks>().Join(_taskContext.Set<Project>(), task => task.ProjectID, pro => pro.ProjectID, (task, pro) => new { task, pro })
                .Join(_taskContext.Set<ProjectEmployee>(), taskpro => taskpro.pro.ProjectID, emp => emp.ProjectID, (taskpro, emp) => new { taskpro, emp })
                
                .Select(x => new
                {
                    x.taskpro.task.TaskID,
                    x.taskpro.task.Name,
                    x.taskpro.task.Description,
                    x.taskpro.task.ProjectID,
                    x.taskpro.task.StartDate,
                    x.taskpro.task.EndDate,
                    x.taskpro.task.SituaitionID,
                    x.taskpro.task.ManagerID,
                    x.taskpro.task.EmployeeID,
                    x.taskpro.task.isFinish
                }).Where(x=>x.SituaitionID==2 && x.isFinish==false && (x.EmployeeID==id || (x.EmployeeID==null)) ).Distinct().ToList();
        }
        public object GetALL()
        {

            return _taskContext.Set<Tasks>().Join(_taskContext.Set<Project>(), task => task.ProjectID, pro => pro.ProjectID, (task, pro) => new { task, pro })
                .Join(_taskContext.Set<ProjectEmployee>(), taskpro => taskpro.pro.ProjectID, emp => emp.ProjectID, (taskpro, emp) => new { taskpro, emp })

                .Select(x => new
                {
                    x.taskpro.task.TaskID,
                    x.taskpro.task.Name,
                    x.taskpro.task.Description,
                    x.taskpro.task.ProjectID,
                    x.taskpro.task.StartDate,
                    x.taskpro.task.EndDate,
                    x.taskpro.task.SituaitionID,
                    x.taskpro.task.ManagerID,
                    x.taskpro.task.EmployeeID,
                    x.taskpro.task.isFinish
                }).Where(x => x.SituaitionID == 3 && x.isFinish==false).Distinct().ToList();
        }
    }
}

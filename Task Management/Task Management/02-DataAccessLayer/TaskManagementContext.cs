using _01_Entities;
using _02_DataAccessLayer.Mapping;
using _02_DataAccessLayer.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_DataAccessLayer
{
    public class TaskManagementContext:DbContext
    {
        public TaskManagementContext()
            : base("Task")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<TaskManagementContext, Configuration>());
        }

        internal DbSet<AccountType> AccountType { get; set; }
        internal DbSet<Customer> Customer { get; set; }
        internal DbSet<CustomerRequest> CustomerRequest { get; set; }
        internal DbSet<Employees> Employee { get; set; }
        internal DbSet<Project> Project { get; set; }
        internal DbSet<Situaition> Situaition { get; set; }
        internal DbSet<Tasks> Tasks { get; set; }
        internal DbSet<ProjectEmployee> ProjectEmployee { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AccountTypeMap());
            modelBuilder.Configurations.Add(new CustomerMap());
            modelBuilder.Configurations.Add(new CustomerRequestMap());
            modelBuilder.Configurations.Add(new EmployeeMap());
            modelBuilder.Configurations.Add(new ProjectMap());
            modelBuilder.Configurations.Add(new SituaitionMap());
            modelBuilder.Configurations.Add(new TaskMap());
            modelBuilder.Configurations.Add(new ProjectEmployeeMap());

            base.OnModelCreating(modelBuilder);
        }
        public void EntityleriSerbestBırak()
        {
            // Database üzerinden çektiğimiz veriler Çektiğimiz zaman Ram'da bulunur. Durum böyle olunca biz serbest bırakmazsak hata aldığımız zaman sanal tablomuz üzerinde değişiklik olurken gerçek tabloda o değişiklik olmaz.
            foreach (var item in ChangeTracker.Entries().ToList())
            {
                item.State = EntityState.Detached;
            }
        }
    }
}

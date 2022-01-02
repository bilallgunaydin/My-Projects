using DataAccessLayer.Mapping;
using DataAccessLayer.Migrations;
using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class ELessonSelectionContext : DbContext
    {
        private static ELessonSelectionContext _context { get; set; }

        public static ELessonSelectionContext ContextOlustur()
        {
            if (_context == null)
            {
                _context = new ELessonSelectionContext();
            }
            return _context;
        }

        public ELessonSelectionContext()
            : base("ELesson")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ELessonSelectionContext, Configuration>());
        }

        internal DbSet<Lesson> Lesson { get; set; }
        internal DbSet<Manager> Manager { get; set; }
        internal DbSet<AccountType> AccountType { get; set; }
        internal DbSet<Student> Student { get; set; }
        internal DbSet<Teacher> Teacher { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AccountTypeMap());
            modelBuilder.Configurations.Add(new LessonMap());
            modelBuilder.Configurations.Add(new ManagerMap());
            modelBuilder.Configurations.Add(new StudentMap());
            modelBuilder.Configurations.Add(new TeacherMap());
            modelBuilder.Entity<Student>()
                .HasMany<Lesson>(s => s.Lessons)
                .WithMany(l => l.Students)
                .Map(ls =>
                {
                    ls.MapLeftKey("StudentID");
                    ls.MapRightKey("LessonID");
                    ls.ToTable("StudentLesson");
                });
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }

}

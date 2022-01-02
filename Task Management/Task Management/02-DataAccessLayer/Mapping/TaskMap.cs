using _01_Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_DataAccessLayer.Mapping
{
    class TaskMap:EntityTypeConfiguration<Tasks>
    {
        public TaskMap()
        {
            HasKey(t => t.TaskID);

            Property(t => t.TaskID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(t => t.Name)
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired();

            Property(t => t.Description)
                .IsRequired();

            Property(t => t.StartDate)
                .HasColumnType("date")
                .IsOptional();

            Property(t => t.EndDate)
                .HasColumnType("date")
                .IsRequired();
            Property(t => t.isFinish)
                .HasColumnType("bit")
                .IsRequired();
            //HasRequired(t => t.Employee)
            //    .WithMany()
            //    .HasForeignKey(t => t.EmployeeID)
            //    .WillCascadeOnDelete(false);
            HasOptional(t => t.Employee)
                .WithMany()
                .HasForeignKey(t => t.EmployeeID)
                .WillCascadeOnDelete(false);

            HasRequired(t => t.Manager)
                .WithMany()
                .HasForeignKey(t => t.ManagerID);

            HasRequired(t => t.Project)
                .WithMany()
                .HasForeignKey(t => t.ProjectID)
                .WillCascadeOnDelete(false); 

            HasRequired(t => t.Situaition)
                .WithMany()
                .HasForeignKey(t => t.SituaitionID);

        }
    }
}

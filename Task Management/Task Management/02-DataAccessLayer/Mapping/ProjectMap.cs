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
    class ProjectMap:EntityTypeConfiguration<Project>
    {
        public ProjectMap()
        {
            HasKey(p => p.ProjectID);

            Property(p => p.ProjectID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(p => p.ProjectID)
                .HasColumnType("int")
                .IsRequired();

            Property(p => p.Name)
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired();

            Property(p => p.Description)
                .IsRequired();

            HasRequired(p => p.Employee)
                .WithMany()
                .HasForeignKey(p => p.EmployeeID)
                .WillCascadeOnDelete(false);

            HasRequired(p => p.Customer)
                .WithMany()
                .HasForeignKey(p => p.CustomerID);

            Property(p => p.GenerateDate)
                .HasColumnType("Date")
                .IsRequired();

            Property(p => p.DeadLine)
                .HasColumnType("Date")
                .IsRequired();

            Property(p => p.StartDate)
                .HasColumnType("Date")
                .IsOptional();

            Property(p => p.EndDate)
                .HasColumnType("Date")
                .IsOptional();

            HasRequired(P => P.TeamLead)
                .WithMany()
                .HasForeignKey(p => p.TeamLeadID)
                .WillCascadeOnDelete(false);

        }
    }
}

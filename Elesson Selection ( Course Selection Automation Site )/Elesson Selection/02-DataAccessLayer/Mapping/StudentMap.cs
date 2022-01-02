using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Mapping
{
    class StudentMap:EntityTypeConfiguration<Student>
    {
        public StudentMap()
        {
            HasKey(s => s.ID).Property(s => s.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(s => s.FirstName)
                .HasColumnType("varchar")
                .IsRequired()
                .HasMaxLength(50);
            Property(s => s.LastName)
                .HasColumnType("varchar")
                .IsRequired()
                .HasMaxLength(50);
            Property(s => s.Mail)
                .HasColumnType("nvarchar")
                .IsRequired()
                .HasMaxLength(100);
            Property(s => s.Password)
                .HasColumnType("nvarchar")
                .IsRequired()
                .HasMaxLength(12);
            Property(s => s.LessonCredit)
                .HasColumnType("int")
                .IsOptional();
            Property(s => s.isPassive)
                .HasColumnType("bit")
                .IsRequired();

            //Relationship
            HasRequired(s => s.AccountType)
                .WithMany()
                .HasForeignKey(s => s.AccountTypeID)
                .WillCascadeOnDelete(false);
        }

        
    }
}

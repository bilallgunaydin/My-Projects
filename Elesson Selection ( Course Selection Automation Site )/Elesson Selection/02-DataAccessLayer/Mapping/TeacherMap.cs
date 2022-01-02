using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Mapping
{
    class TeacherMap:EntityTypeConfiguration<Teacher>
    {
        public TeacherMap()
        {
            HasKey(t => t.ID).Property(t => t.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(t => t.FirstName)
                .HasColumnType("varchar")
                .IsRequired()
                .HasMaxLength(50);
            Property(t => t.LastName)
                .HasColumnType("varchar")
                .IsRequired()
                .HasMaxLength(50);
            Property(t => t.Mail)
                .HasColumnType("nvarchar")
                .IsRequired()
                .HasMaxLength(100);
            Property(t => t.Password)
                .HasColumnType("nvarchar")
                .IsRequired()
                .HasMaxLength(12);
            Property(t => t.isPassive)
                .HasColumnType("bit")
                .IsRequired();

            //Relationship
            HasRequired(t => t.AccountType)
                .WithMany()
                .HasForeignKey(t => t.AccountTypeID)
                .WillCascadeOnDelete(false);
            HasRequired(t => t.Lesson)
                .WithMany()
                .HasForeignKey(t => t.LessonID)
                .WillCascadeOnDelete(false);


                
        }
    }
}

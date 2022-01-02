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
    class LessonMap:EntityTypeConfiguration<Lesson>
    {
        public LessonMap()
        {
            HasKey(l => l.ID).Property(l => l.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            
            Property(l => l.Name)
               .HasColumnType("varchar")
               .HasMaxLength(50)
               .IsRequired();
            Property(l => l.Credit)
                .HasColumnType("int")
                .IsRequired();
            Property(l => l.isPassive)
                .IsRequired()
                .HasColumnType("bit");


            HasOptional(l => l.Teacher)
                .WithMany()
                .HasForeignKey(l => l.TeacherID)
                .WillCascadeOnDelete(false);
            

        }
    }
}

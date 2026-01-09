using Mapping.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapping.Configurations
{
    public class MonthExamConfig : IEntityTypeConfiguration<MonthExam>
    {
        public void Configure(EntityTypeBuilder<MonthExam> builder)
        {
            builder.HasKey(x => x.ExamId);
            builder.Property(x => x.ExamId).ValueGeneratedOnAdd();


            builder.HasOne(ME => ME.Subject)
                .WithMany(S => S.MonthExams)
                .HasForeignKey(S => S.SubjectId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}

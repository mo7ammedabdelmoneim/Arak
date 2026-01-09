using Arak.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Arak.Configurations
{
    public class MonthExamConfig : IEntityTypeConfiguration<MonthExam>
    {
        public void Configure(EntityTypeBuilder<MonthExam> builder)
        {
            builder.HasKey(x => x.ExamId);
            builder.Property(x => x.ExamId).ValueGeneratedOnAdd();


            builder.HasOne(ME=> ME.Subject)
                .WithMany(S=> S.MonthExams)
                .HasForeignKey(S=>S.SubjectId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}

using Arak.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Arak.Configurations
{
    public class SubjectConfig : IEntityTypeConfiguration<Subject>
    {
        public void Configure(EntityTypeBuilder<Subject> builder)
        {
            builder.HasKey(x => x.SubjectId);
            builder.Property(x => x.SubjectId).ValueGeneratedOnAdd();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);

            builder.HasOne(S=> S.Teacher)
                .WithMany(T=> T.Subjects)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}

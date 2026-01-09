using Arak.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Arak.Configurations
{
    public class GradeConfig : IEntityTypeConfiguration<Grade>
    {
        public void Configure(EntityTypeBuilder<Grade> builder)
        {
            builder.HasKey( x => x.GradeID);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
        }
    }
}

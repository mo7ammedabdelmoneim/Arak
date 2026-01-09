using Arak.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Arak.Configurations
{
    public class LevelConfig : IEntityTypeConfiguration<Level>
    {
        public void Configure(EntityTypeBuilder<Level> builder)
        {
            builder.HasKey( x => x.LevelID);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
        }
    }
}

using Arak.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Arak.Configurations
{
    public class SessionAttendanceConfig : IEntityTypeConfiguration<SessionAttendance>
    {
        public void Configure(EntityTypeBuilder<SessionAttendance> builder)
        {
            builder.HasKey(s=> s.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.HasOne(ST => ST.Student)
                .WithMany(S=> S.SessionAttendances)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}

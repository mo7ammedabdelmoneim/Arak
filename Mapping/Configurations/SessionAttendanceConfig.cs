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
    public class SessionAttendanceConfig : IEntityTypeConfiguration<SessionAttendance>
    {
        public void Configure(EntityTypeBuilder<SessionAttendance> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.HasOne(ST => ST.Student)
                .WithMany(S => S.SessionAttendances)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}

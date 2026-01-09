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
    public class BrailleCourseSessionConfig : IEntityTypeConfiguration<BrailleCourseSession>
    {
        public void Configure(EntityTypeBuilder<BrailleCourseSession> builder)
        {
            builder.ToTable("BrailleCourseSessions", "BrailleCourse");

            builder.HasKey(s => s.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
        }
    }
}

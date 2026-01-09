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
    public class BrailleCourseConfig : IEntityTypeConfiguration<BrailleCourse>
    {
        public void Configure(EntityTypeBuilder<BrailleCourse> builder)
        {
            builder.ToTable("BrailleCourses", "BrailleCourse");

            builder.HasKey(s => s.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x=> x.State).HasDefaultValue("In Progress");
        }
    }
}

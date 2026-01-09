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
    public class TeacherConfig : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.HasKey(x => x.TeacherId);
            builder.Property(x => x.TeacherId).ValueGeneratedOnAdd();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Address).HasMaxLength(300);
            builder.Property(x => x.Age);
            builder.Property(x => x.Phone).HasMaxLength(15);
            builder.Property(x => x.Faculty).HasMaxLength(100);


        }
    }
}

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
    public class StudentConfig : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(x => x.StudentId);
            builder.Property(x => x.StudentId).ValueGeneratedOnAdd();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Address).HasMaxLength(300);
            builder.Property(x => x.Age).IsRequired();
            builder.Property(x => x.Phone).HasMaxLength(15);

            // Parent Config
            builder.Property(x => x.ParentName).IsRequired().HasMaxLength(100);
            builder.Property(x => x.ParentPhone).HasMaxLength(15);
        }
    }
}

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
    public class BrailleSessionConfig : IEntityTypeConfiguration<Braille_Session>
    {
        public void Configure(EntityTypeBuilder<Braille_Session> builder)
        {
            builder.ToTable("BrailleSession");
            builder.HasKey(s => s.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
        }
    }
}

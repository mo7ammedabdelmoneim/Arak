using Arak.Configurations;
using Arak.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

namespace Arak
{
    public class AppContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            var configration = new ConfigurationBuilder()
                             .AddJsonFile("appSettings.json").Build();
            var constr = configration.GetSection("ConStr").Value;

            optionsBuilder.UseSqlServer(constr);


        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof( StudentConfig).Assembly);
        }

        public virtual DbSet<Student> Students { get; set; } 
        public virtual DbSet<Level> Levels { get; set; }
        public virtual DbSet<Grade> Grades { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }
        public virtual DbSet<Session> Sessions { get; set; }
        public virtual DbSet<SessionAttendance> SessionAttendances { get; set; }
        public virtual DbSet<MonthExam> MonthExams { get; set; }
    }
}

using Mapping.Configurations;
using Mapping.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection.Emit;

namespace Mapping
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

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(StudentConfig).Assembly);
        }

        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Level> Levels { get; set; }
        public virtual DbSet<Grade> Grades { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }
        public virtual DbSet<Session> Sessions { get; set; }
        public virtual DbSet<SessionAttendance> SessionAttendances { get; set; }
        public virtual DbSet<PrivateBrailleStudents> PrivateBrailleStudents { get; set; }
        public virtual DbSet<Braille_Session> BrailleSessions { get; set; }
        public virtual DbSet<MonthExam> MonthExams { get; set; }

        public virtual DbSet<BrailleCourse> BrailleCourses { get; set; }
        public virtual DbSet<Instructor> Instructors { get; set; }
        public virtual DbSet<BrailleCourseSession> BrailleCourseSessions { get; set; }


    }
}


using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arak.Entities
{
    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public byte? Age { get; set; }
        public string Address {  get; set; }
        public string Phone { get; set; }
        
        // Parent Info
        public string ParentName { get; set; }
        public byte? ParentAge { get; set; }
        public string? ParentPhone { get; set; }


        public byte GradeID { get; set; }

        [ForeignKey("GradeID")]
        public virtual Grade Grade { get; set; }  /// Navigate

        public virtual ICollection<MonthExam>? MonthExams { get; set; } = new HashSet<MonthExam>();
        public virtual ICollection<SessionAttendance>? SessionAttendances { get; set; } = new HashSet<SessionAttendance>();
        

    }
}

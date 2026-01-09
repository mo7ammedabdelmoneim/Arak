using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapping.Entities
{
    public class Subject
    {
        public byte SubjectId { get; set; }
        public string Name { get; set; }

        public byte? TeacherId { get; set; }
        public byte GradeId { get; set; }


        [ForeignKey("GradeId")]
        public virtual Grade Grade { get; set; }  // One to many (many)

        [ForeignKey("TeacherId")]
        public virtual Teacher Teacher { get; set; }  // One to many (many) 

        public virtual ICollection<Session>? Sessions { get; set; } = new HashSet<Session>();
        public virtual ICollection<Braille_Session>? BrailleSessions { get; set; } = new HashSet<Braille_Session>();
        public virtual ICollection<MonthExam>? MonthExams { get; set; } = new HashSet<MonthExam>();
    }
}

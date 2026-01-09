using System.ComponentModel.DataAnnotations.Schema;

namespace Arak.Entities
{
    public class Grade
    {
        public byte GradeID { get; set; }
        public string Name { get; set; }
        public byte LevelID { get; set; }



        [ForeignKey("LevelID")]
        public virtual Level Level { get; set; }  // One to many (many) 

        public virtual ICollection<Student>? Students { get; set; } = new HashSet<Student>();  // One to many (one) 
        public virtual ICollection<Subject>? Subjects { get; set; } = new HashSet<Subject>(); // One to many (one) 
        public virtual ICollection<Session>? Sessions { get; set; } = new HashSet<Session>();
    }
}

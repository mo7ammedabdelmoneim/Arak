using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapping.Entities
{
    public class BrailleCourse
    {
        public int Id { get; set; }

        public string? LearnerName { get; set; }
        public byte? InstrutorId { get; set; }
        public string? State { get; set; }

        
        [ForeignKey("InstrutorId")]
        public virtual Instructor? Instructor { get; set; }     /// Navigate

        public virtual ICollection<BrailleCourseSession>? BrailleCourseSessions { get; set; } = new HashSet<BrailleCourseSession>();
    }
}

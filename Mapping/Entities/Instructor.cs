using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapping.Entities
{
    public class Instructor
    {
        public byte Id { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<BrailleCourse>? BrailleCourses { get; set; } = new HashSet<BrailleCourse>();

    }
}

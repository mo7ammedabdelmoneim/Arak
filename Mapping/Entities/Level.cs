using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapping.Entities
{
    public class Level
    {
        public byte LevelID { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Grade>? Grades { get; set; } = new HashSet<Grade>();
    }
}

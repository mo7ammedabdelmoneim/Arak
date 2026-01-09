using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapping.Entities
{
    public class BrailleCourseSession
    {
        public long Id { get; set; }
        public DateTime Date { get; set; }

        public int? BrailleCourseId { get; set; }
        
        [ForeignKey("BrailleCourseId")]
        public virtual BrailleCourse? BrailleCourse { get; set; }  /// Navigate
    }
}

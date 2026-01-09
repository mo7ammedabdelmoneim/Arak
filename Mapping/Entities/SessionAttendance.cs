using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapping.Entities
{
    public class SessionAttendance
    {
        public long Id { get; set; }

        public long SessionID { get; set; }
        public int StudentId { get; set; }


        [ForeignKey("SessionID")]
        public virtual Session Session { get; set; }  /// Navigate

        [ForeignKey("StudentId")]
        public virtual Student Student { get; set; }  /// Navigate
    }
}

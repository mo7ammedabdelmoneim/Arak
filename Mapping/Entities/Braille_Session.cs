using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapping.Entities
{
    public class Braille_Session
    {
        public long Id { get; set; }
        public DateTime Date { get; set; }

        public byte TeacherId { get; set; }
        public string? SubjectName { get; set; }
        public string? StudentName { get; set; }


        [ForeignKey("TeacherId")]
        public virtual Teacher Teacher { get; set; }  /// Navigate
    }
}

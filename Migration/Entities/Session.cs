using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arak.Entities
{
    public class Session
    {
        public long Id { get; set; }
        public DateTime Date{ get; set; }

        public byte TeacherId { get; set; }
        public byte GradeID { get; set; }
        public byte SubjectId { get; set; }


        [ForeignKey("TeacherId")]
        public virtual Teacher Teacher { get; set; }  /// Navigate
        
        [ForeignKey("GradeID")]
        public virtual Grade Grade { get; set; }  /// Navigate
        
        [ForeignKey("SubjectId")]
        public virtual Subject Subject { get; set; }  /// Navigate
  
    }
    
}

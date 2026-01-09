using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapping.Entities
{
    public class MonthExam
    {
        public int ExamId { get; set; }
        public int StudentId { get; set; }
        public byte SubjectId { get; set; }
        public byte MonthNumber { get; set; }
        public decimal mark { get; set; }


        [ForeignKey("StudentId")]
        public virtual Student Student { get; set; }  // One to many (many)

        [ForeignKey("SubjectId")]
        public virtual Subject Subject { get; set; }  // One to many (many) 


    }
}

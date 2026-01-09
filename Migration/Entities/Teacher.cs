using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arak.Entities
{
    public class Teacher
    {
        public byte TeacherId { get; set; }
        public string Name { get; set; }
        public byte? Age { get; set; }
        public string Address {  get; set; }
        public string Phone { get; set; }
        public string Faculty { get; set; }


        public virtual ICollection<Subject>? Subjects { get; set; } = new HashSet<Subject>();
        public virtual ICollection<Session>? Sessions { get; set; } = new HashSet<Session>();
    }
}

using System;
using System.Collections.Generic;

namespace AsrAngular.Models
{
    public partial class Student
    {
        public Student()
        {
            AspNetUsers = new HashSet<AspNetUsers>();
            Slot = new HashSet<Slot>();
        }

        public string StudentId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public virtual ICollection<AspNetUsers> AspNetUsers { get; set; }
        public virtual ICollection<Slot> Slot { get; set; }
    }
}

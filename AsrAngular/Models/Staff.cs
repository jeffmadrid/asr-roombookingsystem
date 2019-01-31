using System;
using System.Collections.Generic;

namespace AsrAngular.Models
{
    public partial class Staff
    {
        public Staff()
        {
            AspNetUsers = new HashSet<AspNetUsers>();
            Slot = new HashSet<Slot>();
        }

        public string StaffId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public virtual ICollection<AspNetUsers> AspNetUsers { get; set; }
        public virtual ICollection<Slot> Slot { get; set; }
    }
}

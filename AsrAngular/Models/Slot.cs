using System;
using System.Collections.Generic;

namespace AsrAngular.Models
{
    public partial class Slot
    {
        public string RoomId { get; set; }
        public DateTime StartTime { get; set; }
        public string StaffId { get; set; }
        public string StudentId { get; set; }

        public virtual Room Room { get; set; }
        public virtual Staff Staff { get; set; }
        public virtual Student Student { get; set; }
    }
}

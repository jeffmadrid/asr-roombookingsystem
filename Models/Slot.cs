using System;
using System.ComponentModel.DataAnnotations;

namespace Asr.Models
{
    public class Slot
    {
        [Required]
        public string RoomID { get; set; }
        public virtual Room Room { get; set; }

        [Required]  
        [CheckDate(ErrorMessage ="You cannot create slot in the past")]
        public DateTime StartTime { get; set; }

        [Required]

        public string StaffID { get; set; }
        public virtual Staff Staff { get; set; }

        public string StudentID { get; set; }
        [Display(Name = "Booked Student")]
        public virtual Student Student { get; set; }
    }
}

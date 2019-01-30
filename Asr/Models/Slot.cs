using System;
using System.ComponentModel.DataAnnotations;

namespace Asr.Models
{
    public class Slot
    {
        [Required]
        [Display(Name = "Room Name")]
        public string RoomID { get; set; }
        public virtual Room Room { get; set; }

        [Required]  
        [CheckDate(ErrorMessage ="You cannot create slot in the past")]
        [Display(Name = "Date and Time")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy h:mm tt}")]
        public DateTime StartTime { get; set; }

        [Required]
        [Display(Name = "Staff")]
        public string StaffID { get; set; }
        public virtual Staff Staff { get; set; }

        [Display(Name = "BookedIn Student")]
        public string StudentID { get; set; }
        public virtual Student Student { get; set; }
    }
}

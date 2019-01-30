using System;
using System.ComponentModel.DataAnnotations;

namespace Asr.Models
{
    public class Staff
    {
        [Key]
        [StringLength(6, MinimumLength = 6)]
        [RegularExpression(@"^e\d{5}$")]
        public string StaffID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [RegularExpression(@"^e\d{5}@rmit\.edu\.au$")]
        public string Email { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations;

namespace Asr.Models
{
    public class Student
    {
        [Key]
        [StringLength(8, MinimumLength = 8)]
        [RegularExpression(@"^s\d{7}$")]
        public string StudentID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [RegularExpression(@"^s\d{7}@student\.rmit\.edu\.au$")]
        public string Email { get; set; }
    }
}

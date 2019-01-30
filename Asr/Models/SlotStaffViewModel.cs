using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Asr.Models
{
    public class SlotStaffViewModel
    {
        public List<Slot> Slots { get; set; }
        public SelectList StaffId { get; set; }
        public DateTime DateStart { get; set; }
    }
}

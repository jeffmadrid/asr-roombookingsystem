using System;
using Asr.Data;

namespace AsrWebAPI.Data.DataManager
{
    public class SlotManager
    {
        private ApplicationDbContext _context;

        public SlotManager(ApplicationDbContext context)
        {
            _context = context;
        }


    }
}

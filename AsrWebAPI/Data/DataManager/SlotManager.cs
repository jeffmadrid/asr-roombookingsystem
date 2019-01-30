using System;
using System.Collections.Generic;
using System.Linq;
using Asr.Data;
using Asr.Models;

namespace AsrWebAPI.Data.DataManager
{
    public class SlotManager
    {
        private ApplicationDbContext _context;

        public SlotManager(ApplicationDbContext context)
        {
            _context = context;
        }

        /*
         * Gets all the slots
         */       
        public IEnumerable<Slot> GetAll()
        {
            return _context.Slot.ToList();
        }

        /*
         * Gets the slot that corresponds to the roomId and datetime parameters       
         */
        public Slot Get(string roomID, DateTime dateTime)
        {
            return _context.Slot.Find(roomID, dateTime);
        }

        /*
         * Adds slot to the database
         */
        public void Add(Slot slot)
        {
            _context.Slot.Add(slot);
            _context.SaveChanges();
        }

        /*
         * Deletes the slot on the database
         */
        public void Delete(Slot slot)
        {
            _context.Slot.Remove(slot);
            _context.SaveChanges();
        }

        /*
         * Updates the database details. should be book/unbooking of student
         */
        public void Update(Slot slot)
        {
            _context.Update(slot);
            _context.SaveChanges();
        }
    }
}

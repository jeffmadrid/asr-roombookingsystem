using System;
using System.Collections.Generic;
using System.Linq;
using Asr.Data;
using Asr.Models;
using Microsoft.EntityFrameworkCore;

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
        public IEnumerable<Slot> GetAllSlots()
        {
            return _context.Slot.ToList();
        }

        /*
         * Gets all the created slots of the staffID parameter
         */
        public IEnumerable<Slot> GetSlotsOf(string id) =>
            id.StartsWith('e') ? _context.Slot.Where(x => x.StaffID == id) :
                _context.Slot.Where(x => x.StudentID == id);

        /*
         * Adds venues roomID {A,B,C,D...} to the system
         */
        public void AddRoom(string roomID)
        {
            _context.Room.Add(new Room { RoomID = roomID });
            _context.SaveChanges();
        }

        /*
         * Deletes the slot on the database
         */
        public void DeleteSlot(string roomID, DateTime dateTime, string staffID)
        {
            _context.Slot.Remove(_context.Slot.First(x => 
                x.RoomID == roomID && x.StaffID == staffID && x.StartTime == dateTime));
            _context.SaveChanges();
        }

        /*
         * Updates the database details. should be book/unbooking of student
         */
        public void CancelBooking(Slot slot)
        {
            
            _context.Update(slot);
            _context.SaveChanges();
        }
    }
}

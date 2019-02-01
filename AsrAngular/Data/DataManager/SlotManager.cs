using System;
using System.Collections.Generic;
using System.Linq;
using AsrAngular.Data;
using AsrAngular.Models;
using Microsoft.EntityFrameworkCore;

namespace AsrAngular.Data.DataManager
{
    public class SlotManager
    {
        private s3707189Context _context = new s3707189Context();

        //public SlotManager(s3707189Context context)
        //{
        //    _context = context;
        //}

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
            id.StartsWith('e') ? _context.Slot.Where(x => x.StaffId == id) :
                _context.Slot.Where(x => x.StudentId == id);

        /*
         * Deletes the slot on the database
         */
        public void DeleteSlot(Slot slot)
        {
            _context.Slot.Remove(_context.Slot.Find(slot));
            _context.SaveChanges();
        }

        /*
         * Adds venues roomID {A,B,C,D...} to the system
         */
        public void AddRoom(string roomID)
        {
            _context.Room.Add(new Room { RoomId = roomID });
            _context.SaveChanges();
        }

        /*
         * Edit the roomIDs/rename? or maybe just delete the room?
         */
        public void EditRoom(string roomID)
        {
            _context.Room.Find(roomID);
        }


        /*
         * Edit the booked in student
         */
        public void EditBookedStudent(Slot slot, string studentId)
        {
            var theSlot = _context.Slot.Find(slot);
            theSlot.StudentId = studentId;
            _context.Update(theSlot);
            _context.SaveChanges();
        }

        /*
         * Removes the booked in student
         */
        public void CancelBooking(Slot slot)
        {
            var theSlot = _context.Slot.Find(slot);
            theSlot.StudentId = null;
            _context.Update(theSlot);
            _context.SaveChanges();
        }
    }
}

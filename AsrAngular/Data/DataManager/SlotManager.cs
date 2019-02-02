using System;
using System.Collections.Generic;
using System.Linq;
using AsrAngular.Data;
using AsrAngular.Models;
using Microsoft.EntityFrameworkCore;

namespace AsrAngular.Data.DataManager
{
    public class WebAPIManager
    {
        private s3707189Context _context = new s3707189Context();

        //public WebAPIManager(s3707189Context context)
        //{
        //    _context = context;
        //}

        /*
         * Gets all the slots and get all rooms
         */
        public IEnumerable<Slot> GetAllSlots() => _context.Slot.ToList();
        public IEnumerable<Room> GetAllRooms() => _context.Room.ToList();

        /*
         * Gets all the created slots of the staffID parameter
         */
        public IEnumerable<Slot> GetSlotsOf(string id) =>
            id.StartsWith('e') ? _context.Slot.Where(x => x.StaffId == id) :
                _context.Slot.Where(x => x.StudentId == id);

        /*
         * Deletes the slot on the database
         */
        public int DeleteSlot(Slot slot)
        {
            _context.Slot.Remove(_context.Slot.Find(slot));
            _context.SaveChanges();
            return 1;
        }

        /*
         * Adds venues roomID {A,B,C,D...} to the system
         */
        public int AddRoom(string roomID)
        {
            _context.Room.Add(new Room { RoomId = roomID });
            _context.SaveChanges();
            return 1;
        }

        /*
         * Edit the roomIDs/rename? or maybe just delete the room?
         */
        public int EditRoom(string roomID,string newID)
        {
            var room = _context.Room.Find(roomID);
            room.RoomId = newID;
            _context.Room.Update(room);

            return 1;
        }


        /*
         * Edit the booked in student
         */
        public int EditBookedStudent(Slot slot, string studentId)
        {
            var theSlot = _context.Slot.Find(slot);
            theSlot.StudentId = studentId;
            _context.Update(theSlot);
            _context.SaveChanges();
            return 1;
        }

        /*
         * Removes the booked in student
         */
        public int CancelBooking(Slot slot)
        {
            var theSlot = _context.Slot.Find(slot);
            theSlot.StudentId = null;
            _context.Update(theSlot);
            _context.SaveChanges();
            return 1;
        }
    }
}

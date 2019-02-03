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

        public Slot GetStudentId(string roomId, string startTime)
        {
            var dateTime = DateTime.Parse(startTime);
            //var staffId = _context.Slot.Find(roomId, dateTime).StudentId;
            //return string.IsNullOrEmpty(staffId) ? "" : staffId;
            return _context.Slot.Find(roomId, dateTime);

        }

        /*
         * Deletes the slot on the database
         */
        public int DeleteSlot(string roomId, string startTime)
        {
            var dateTime = DateTime.Parse(startTime);
            var slot = _context.Slot.Find(roomId, dateTime);
            _context.Slot.Remove(slot);
            _context.SaveChanges();
            return 1;
        }

        /*
         * Adds venues roomID {A,B,C,D...} to the system
         */
        public int AddRoom(Room room)
        {
            if (_context.Room.Any(x => x == room))
                return 0;
            _context.Room.Add(room);
            //_context.Room.Add(new Room { RoomId = roomId });
            _context.SaveChanges();
            return 1;
        }

        /*
         * Edit the roomIDs/rename? or maybe just delete the room?
         */
        public int EditRoom(string roomId,string newId)
        {
            var room = _context.Room.Find(roomId);
            room.RoomId = newId;
            _context.Room.Update(room);
            _context.SaveChanges();

            return 1;
        }


        /*
         * Edit the booked in student/ can also be used for cancel
         */
        //public int UpdateBookedStudent(string roomId, string startTime, string studentId)
        public int UpdateBookedStudent(Slot slot)
        {
            //var dateTime = DateTime.Parse(startTime);
            //var theSlot = _context.Slot.Find(roomId, dateTime);
            //theSlot.StudentId = studentId;
            //_context.Update(theSlot);
            _context.Update(slot);
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

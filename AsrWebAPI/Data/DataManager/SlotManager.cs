﻿using System;
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
            _context.Room.Add(new Room { RoomID = roomID });
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
        public void EditBookedStudent(Slot slot, string studentID)
        {
            var theSlot = _context.Slot.Find(slot);
            theSlot.StudentID = studentID;
            _context.Update(theSlot);
            _context.SaveChanges();
        }

        /*
         * Removes the booked in student
         */
        public void CancelBooking(Slot slot)
        {
            var theSlot = _context.Slot.Find(slot);
            theSlot.StudentID = null;
            _context.Update(theSlot);
            _context.SaveChanges();
        }
    }
}

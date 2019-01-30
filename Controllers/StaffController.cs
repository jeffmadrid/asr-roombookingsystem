using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Asr.Data;
using Asr.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace Asr.Controllers
{
    [Authorize(Roles = Constants.StaffRole)]
    public class StaffController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StaffController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Slot
        public async Task<IActionResult> Index(string staffID)
        {
            var applicationDbContext = _context.Slot.Include(s => s.Room).Include(s => s.Staff).Include(s => s.Student);

            if (!string.IsNullOrEmpty(staffID))
            {
                var staffSlotsQuery = applicationDbContext.Where(x => x.StaffID == staffID);
                return View(await staffSlotsQuery.ToListAsync());
            }

            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Slot/Details/5
        public async Task<IActionResult> Details(string id, DateTime dateTime)
        {
            if (id == null)
            {
                return NotFound();
            }

            var slot = await _context.Slot
                .Include(s => s.Room)
                .Include(s => s.Staff)
                .Include(s => s.Student)
                .FirstOrDefaultAsync(m => m.RoomID == id && m.StartTime == dateTime);
            if (slot == null)
            {
                return NotFound();
            }
            return View(slot);
        }
        // GET: Slot/Create
        public IActionResult Create()
        {
            var loggedInUser = User.Identity.Name;
            ViewData["RoomID"] = new SelectList(_context.Room, "RoomID", "RoomID");
            ViewData["StaffID"] = new SelectList(_context.Staff.Where(x => x.Email == loggedInUser), "StaffID", "StaffID");
            //ViewData["StudentID"] = new SelectList(_context.Student, "StudentID", "StudentID");
            return View();
        }

        // POST: Slot/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RoomID,StartTime,StaffID,StudentID")] Slot slot)
        {

            if (ModelState.IsValid)
            {
                var slots = _context.Slot.Include(s => s.Room).Include(s => s.Staff).Include(s => s.Student);

                if (slots.Any(x => x.RoomID == slot.RoomID && x.StartTime == slot.StartTime))
                    return RedirectToAction(nameof(Index)); //TODO redirect to an error page
                if (slots.Count(x => x.RoomID == slot.RoomID && x.StartTime.Date == slot.StartTime.Date) >= 2)
                    return RedirectToAction(nameof(Index)); //TODO redirect to an error page
                if (slots.Count(x => x.StaffID == slot.StaffID && x.StartTime.Date == slot.StartTime.Date) >= 4)
                    return RedirectToAction(nameof(Index)); //TODO redirect to an error page

                _context.Add(slot);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RoomID"] = new SelectList(_context.Room, "RoomID", "RoomID", slot.RoomID);
            ViewData["StaffID"] = new SelectList(_context.Staff, "StaffID", "StaffID", slot.StaffID);
            return View(slot);
        }

        // GET: Slot/Delete/5
        public async Task<IActionResult> Delete(string id, DateTime dateTime)
        {
            if (id == null)
            {
                return NotFound();
            }

            var slot = await _context.Slot
                .Include(s => s.Room)
                .Include(s => s.Staff)
                .Include(s => s.Student)
                .FirstOrDefaultAsync(m => m.RoomID == id && m.StartTime == dateTime);
            if (slot == null)
            {
                return NotFound();
            }

            return View(slot);
        }

        // POST: Slot/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id, DateTime dateTime)
        {
            var slot = await _context.Slot.FindAsync(id, dateTime);

            //Added precaution needed? - disabling the removal of slot if a student is booked
            if (slot.Student == null)
            {
                _context.Slot.Remove(slot);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool SlotExists(string id)
        {
            return _context.Slot.Any(e => e.RoomID == id);
        }
    }
}

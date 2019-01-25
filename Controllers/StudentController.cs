using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Asr.Data;
using Asr.Models;

namespace Asr.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Student
        public async Task<IActionResult> Index(string staffId,DateTime dateTime)
        {
            var staff = _context.Staff.Select(x => x.StaffID);
            var slot = _context.Slot.Select(x => x);
            if (!string.IsNullOrEmpty(staffId))
                slot = _context.Slot.Where(x => x.StaffID == staffId && x.StudentID ==null);
            return View(new SlotStaffViewModel
            {
                Slots = await slot.OrderBy(x => x.StartTime).ToListAsync(),StaffId = new SelectList(await staff.ToListAsync())
            });
        }

       
       

        // GET: Student/Edit/5
        // GET: Slot/Edit/5
        public async Task<IActionResult> BookSlot(string id, DateTime dateTime)
        {
            if (id == null)
            {
                return NotFound();
            }

            var slot = await _context.Slot.FindAsync(id, dateTime);
            if (slot == null)
            {
                return NotFound();
            }
          
            ViewData["StudentID"] = new SelectList(_context.Student, "StudentID", "StudentID", slot.StudentID);
            return View(slot);
        }

        // POST: Slot/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BookSlot(string id, [Bind("RoomID,StartTime,StaffID,StudentID")] Slot slot)
        {
            if (id != slot.RoomID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(slot);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SlotExists(slot.RoomID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["StudentID"] = new SelectList(_context.Student, "StudentID", "StudentID", slot.StudentID);
            return View(slot);
        }

        public async Task<IActionResult> CanCelSlot(string id, DateTime dateTime)
        {
            if (id == null)
            {
                return NotFound();
            }

            var slot = await _context.Slot.FindAsync(id, dateTime);
            if (slot == null)
            {
                return NotFound();
            }

            ViewData["StudentID"] = new SelectList(_context.Student, "StudentID", "StudentID", slot.StudentID);
            return View(slot);
        }

        // POST: Slot/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>CancelSlot(string id, [Bind("RoomID,StartTime,StaffID,StudentID")] Slot slot)
        {
            if (id != slot.RoomID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(slot);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SlotExists(slot.RoomID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["StudentID"] = new SelectList(_context.Student, "StudentID", "StudentID", slot.StudentID);
            return View(slot);
        }


        private bool SlotExists(string id)
        {
            return _context.Slot.Any(e => e.RoomID == id);
        }
    }
}

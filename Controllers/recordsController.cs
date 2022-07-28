using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentRegestrationSystem.Models;

namespace StudentRegestrationSystem.Controllers
{
    public class recordsController : Controller
    {
        private readonly Databasecontext _context;

        public recordsController(Databasecontext context)
        {
            _context = context;
        }

        // GET: records
        public async Task<IActionResult> Index()
        {
              return _context.records != null ? 
                          View(await _context.records.ToListAsync()) :
                          Problem("Entity set 'Databasecontext.records'  is null.");
        }

        // GET: records/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.records == null)
            {
                return NotFound();
            }

            var @record = await _context.records
                .FirstOrDefaultAsync(m => m.id == id);
            if (@record == null)
            {
                return NotFound();
            }

            return View(@record);
        }

        // GET: records/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: records/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,LastName,FirstMidName,Email,EnrollmentDate")] record @record)
        {
            if (ModelState.IsValid)
            {
                _context.Add(@record);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(@record);
        }

        // GET: records/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.records == null)
            {
                return NotFound();
            }

            var @record = await _context.records.FindAsync(id);
            if (@record == null)
            {
                return NotFound();
            }
            return View(@record);
        }

        // POST: records/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,LastName,FirstMidName,Email,EnrollmentDate")] record @record)
        {
            if (id != @record.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(@record);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!recordExists(@record.id))
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
            return View(@record);
        }

        // GET: records/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.records == null)
            {
                return NotFound();
            }

            var @record = await _context.records
                .FirstOrDefaultAsync(m => m.id == id);
            if (@record == null)
            {
                return NotFound();
            }

            return View(@record);
        }

        // POST: records/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.records == null)
            {
                return Problem("Entity set 'Databasecontext.records'  is null.");
            }
            var @record = await _context.records.FindAsync(id);
            if (@record != null)
            {
                _context.records.Remove(@record);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool recordExists(int id)
        {
          return (_context.records?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}

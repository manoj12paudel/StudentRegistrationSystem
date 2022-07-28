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
    public class paymentController : Controller
    {
        private readonly Databasecontext _context;

        public paymentController(Databasecontext context)
        {
            _context = context;
        }

        // GET: records
        public async Task<IActionResult> Index()
        {
            return _context.payments != null ?
                        View(await _context.payments.ToListAsync()) :
                        Problem("Entity set 'Databasecontext.records'  is null.");
        }


        // GET: records/Create
        public IActionResult Payment()
        {
            return View();
        }

        // POST: records/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Payment([Bind("Paymentid,Studentid,Courseid,PaymentAmount")] payment @payment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(@payment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(@payment);
        }

        
       
        private bool paymentExists(int Paymentid)
        {
            return (_context.payments?.Any(e => e.Paymentid == Paymentid)).GetValueOrDefault();
        }
    }
}

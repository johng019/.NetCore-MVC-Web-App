using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DotNetCoreWeb_App.Data;
using DotNetCoreWeb_App.Models;

namespace DotNetCoreWeb_App.Controllers
{
    public class Crime_chargesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Crime_chargesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Crime_charges
        public async Task<IActionResult> Index()
        {
            return View(await _context.Crime_charges.ToListAsync());
        }

        // GET: Crime_charges/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var crime_charges = await _context.Crime_charges
                .FirstOrDefaultAsync(m => m.charge_id == id);
            if (crime_charges == null)
            {
                return NotFound();
            }

            return View(crime_charges);
        }

        // GET: Crime_charges/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Crime_charges/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("charge_id,crime_id,crime_code,charge_status,fine_amount,court_fee,amount_paid,pay_due_date")] Crime_charges crime_charges)
        {
            if (ModelState.IsValid)
            {
                _context.Add(crime_charges);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(crime_charges);
        }

        // GET: Crime_charges/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var crime_charges = await _context.Crime_charges.FindAsync(id);
            if (crime_charges == null)
            {
                return NotFound();
            }
            return View(crime_charges);
        }

        // POST: Crime_charges/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("charge_id,crime_id,crime_code,charge_status,fine_amount,court_fee,amount_paid,pay_due_date")] Crime_charges crime_charges)
        {
            if (id != crime_charges.charge_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(crime_charges);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Crime_chargesExists(crime_charges.charge_id))
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
            return View(crime_charges);
        }

        // GET: Crime_charges/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var crime_charges = await _context.Crime_charges
                .FirstOrDefaultAsync(m => m.charge_id == id);
            if (crime_charges == null)
            {
                return NotFound();
            }

            return View(crime_charges);
        }

        // POST: Crime_charges/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var crime_charges = await _context.Crime_charges.FindAsync(id);
            _context.Crime_charges.Remove(crime_charges);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Crime_chargesExists(int id)
        {
            return _context.Crime_charges.Any(e => e.charge_id == id);
        }
    }
}

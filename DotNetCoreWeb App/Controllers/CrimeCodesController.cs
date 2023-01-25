using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DotNetCoreWeb_App.Data;
using DotNetCoreWeb_App.Models;
using Microsoft.AspNetCore.Authorization;

namespace DotNetCoreWeb_App.Controllers
{
    [Authorize]
    public class CrimeCodesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CrimeCodesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CrimeCodes
        public async Task<IActionResult> Index()
        {
            return View(await _context.CrimeCodes.ToListAsync());
        }

        // GET: CrimeCodes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var crimeCodes = await _context.CrimeCodes
                .FirstOrDefaultAsync(m => m.crime_code == id);
            if (crimeCodes == null)
            {
                return NotFound();
            }

            return View(crimeCodes);
        }

        // GET: CrimeCodes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CrimeCodes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("crime_code,code_description")] CrimeCodes crimeCodes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(crimeCodes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(crimeCodes);
        }

        // GET: CrimeCodes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var crimeCodes = await _context.CrimeCodes.FindAsync(id);
            if (crimeCodes == null)
            {
                return NotFound();
            }
            return View(crimeCodes);
        }

        // POST: CrimeCodes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("crime_code,code_description")] CrimeCodes crimeCodes)
        {
            if (id != crimeCodes.crime_code)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(crimeCodes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CrimeCodesExists(crimeCodes.crime_code))
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
            return View(crimeCodes);
        }

        // GET: CrimeCodes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var crimeCodes = await _context.CrimeCodes
                .FirstOrDefaultAsync(m => m.crime_code == id);
            if (crimeCodes == null)
            {
                return NotFound();
            }

            return View(crimeCodes);
        }

        // POST: CrimeCodes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var crimeCodes = await _context.CrimeCodes.FindAsync(id);
            _context.CrimeCodes.Remove(crimeCodes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CrimeCodesExists(int id)
        {
            return _context.CrimeCodes.Any(e => e.crime_code == id);
        }
    }
}

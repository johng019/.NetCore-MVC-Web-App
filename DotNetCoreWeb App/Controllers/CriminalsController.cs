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
    public class CriminalsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CriminalsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Criminals
        public async Task<IActionResult> Index()
        {
            return View(await _context.Criminals.ToListAsync());
        }

        // GET: Criminals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var criminals = await _context.Criminals
                .FirstOrDefaultAsync(m => m.criminal_id == id);
            if (criminals == null)
            {
                return NotFound();
            }

            return View(criminals);
        }

        // GET: Criminals/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Criminals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("criminal_id,last,first,street,city,state,zip,phone,v_status,p_status")] Criminals criminals)
        {
            if (ModelState.IsValid)
            {
                _context.Add(criminals);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(criminals);
        }

        // GET: Criminals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var criminals = await _context.Criminals.FindAsync(id);
            if (criminals == null)
            {
                return NotFound();
            }
            return View(criminals);
        }

        // POST: Criminals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("criminal_id,last,first,street,city,state,zip,phone,v_status,p_status")] Criminals criminals)
        {
            if (id != criminals.criminal_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(criminals);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CriminalsExists(criminals.criminal_id))
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
            return View(criminals);
        }

        // GET: Criminals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var criminals = await _context.Criminals
                .FirstOrDefaultAsync(m => m.criminal_id == id);
            if (criminals == null)
            {
                return NotFound();
            }

            return View(criminals);
        }

        // POST: Criminals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var criminals = await _context.Criminals.FindAsync(id);
            _context.Criminals.Remove(criminals);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CriminalsExists(int id)
        {
            return _context.Criminals.Any(e => e.criminal_id == id);
        }
    }
}

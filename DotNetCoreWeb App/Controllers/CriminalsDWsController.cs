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
    public class CriminalsDWsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CriminalsDWsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CriminalsDWs
        public async Task<IActionResult> Index()
        {
            return View(await _context.CriminalsDW.ToListAsync());
        }

        // GET: CriminalsDWs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var criminalsDW = await _context.CriminalsDW
                .FirstOrDefaultAsync(m => m.criminal_id == id);
            if (criminalsDW == null)
            {
                return NotFound();
            }

            return View(criminalsDW);
        }

        // GET: CriminalsDWs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CriminalsDWs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("criminal_id,last,first,street,city,state,zip,phone,v_status,p_status")] CriminalsDW criminalsDW)
        {
            if (ModelState.IsValid)
            {
                _context.Add(criminalsDW);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(criminalsDW);
        }

        // GET: CriminalsDWs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var criminalsDW = await _context.CriminalsDW.FindAsync(id);
            if (criminalsDW == null)
            {
                return NotFound();
            }
            return View(criminalsDW);
        }

        // POST: CriminalsDWs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("criminal_id,last,first,street,city,state,zip,phone,v_status,p_status")] CriminalsDW criminalsDW)
        {
            if (id != criminalsDW.criminal_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(criminalsDW);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CriminalsDWExists(criminalsDW.criminal_id))
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
            return View(criminalsDW);
        }

        // GET: CriminalsDWs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var criminalsDW = await _context.CriminalsDW
                .FirstOrDefaultAsync(m => m.criminal_id == id);
            if (criminalsDW == null)
            {
                return NotFound();
            }

            return View(criminalsDW);
        }

        // POST: CriminalsDWs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var criminalsDW = await _context.CriminalsDW.FindAsync(id);
            _context.CriminalsDW.Remove(criminalsDW);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CriminalsDWExists(int id)
        {
            return _context.CriminalsDW.Any(e => e.criminal_id == id);
        }
    }
}

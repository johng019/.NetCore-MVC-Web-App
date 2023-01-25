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
    public class ProbationOfficersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProbationOfficersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ProbationOfficers
        public async Task<IActionResult> Index()
        {
            return View(await _context.ProbationOfficers.ToListAsync());
        }

        // GET: ProbationOfficers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var probationOfficers = await _context.ProbationOfficers
                .FirstOrDefaultAsync(m => m.prob_id == id);
            if (probationOfficers == null)
            {
                return NotFound();
            }

            return View(probationOfficers);
        }

        // GET: ProbationOfficers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProbationOfficers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("prob_id,last,first,street,city,state,zip,phone,email,status,mgr_id,pager_num")] ProbationOfficers probationOfficers)
        {
            if (ModelState.IsValid)
            {
                _context.Add(probationOfficers);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(probationOfficers);
        }

        // GET: ProbationOfficers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var probationOfficers = await _context.ProbationOfficers.FindAsync(id);
            if (probationOfficers == null)
            {
                return NotFound();
            }
            return View(probationOfficers);
        }

        // POST: ProbationOfficers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("prob_id,last,first,street,city,state,zip,phone,email,status,mgr_id,pager_num")] ProbationOfficers probationOfficers)
        {
            if (id != probationOfficers.prob_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(probationOfficers);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProbationOfficersExists(probationOfficers.prob_id))
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
            return View(probationOfficers);
        }

        // GET: ProbationOfficers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var probationOfficers = await _context.ProbationOfficers
                .FirstOrDefaultAsync(m => m.prob_id == id);
            if (probationOfficers == null)
            {
                return NotFound();
            }

            return View(probationOfficers);
        }

        // POST: ProbationOfficers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var probationOfficers = await _context.ProbationOfficers.FindAsync(id);
            _context.ProbationOfficers.Remove(probationOfficers);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProbationOfficersExists(int id)
        {
            return _context.ProbationOfficers.Any(e => e.prob_id == id);
        }
    }
}

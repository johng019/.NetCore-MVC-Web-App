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
    public class ProbationContactsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProbationContactsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ProbationContacts
        public async Task<IActionResult> Index()
        {
            return View(await _context.ProbationContact.ToListAsync());
        }

        // GET: ProbationContacts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var probationContact = await _context.ProbationContact
                .FirstOrDefaultAsync(m => m.prob_cat == id);
            if (probationContact == null)
            {
                return NotFound();
            }

            return View(probationContact);
        }

        // GET: ProbationContacts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProbationContacts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("prob_cat,low_amt,high_amt,con_freq")] ProbationContact probationContact)
        {
            if (ModelState.IsValid)
            {
                _context.Add(probationContact);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(probationContact);
        }

        // GET: ProbationContacts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var probationContact = await _context.ProbationContact.FindAsync(id);
            if (probationContact == null)
            {
                return NotFound();
            }
            return View(probationContact);
        }

        // POST: ProbationContacts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("prob_cat,low_amt,high_amt,con_freq")] ProbationContact probationContact)
        {
            if (id != probationContact.prob_cat)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(probationContact);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProbationContactExists(probationContact.prob_cat))
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
            return View(probationContact);
        }

        // GET: ProbationContacts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var probationContact = await _context.ProbationContact
                .FirstOrDefaultAsync(m => m.prob_cat == id);
            if (probationContact == null)
            {
                return NotFound();
            }

            return View(probationContact);
        }

        // POST: ProbationContacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var probationContact = await _context.ProbationContact.FindAsync(id);
            _context.ProbationContact.Remove(probationContact);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProbationContactExists(int id)
        {
            return _context.ProbationContact.Any(e => e.prob_cat == id);
        }
    }
}

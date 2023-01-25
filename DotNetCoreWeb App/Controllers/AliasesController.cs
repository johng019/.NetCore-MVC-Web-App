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
    public class AliasesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AliasesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Aliases
        public async Task<IActionResult> Index()
        {
            return View(await _context.Aliases.ToListAsync());
        }

        // GET: Aliases/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aliases = await _context.Aliases
                .FirstOrDefaultAsync(m => m.alias_id == id);
            if (aliases == null)
            {
                return NotFound();
            }

            return View(aliases);
        }

        // GET: Aliases/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Aliases/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("alias_id,criminal_id,alias")] Aliases aliases)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aliases);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aliases);
        }

        // GET: Aliases/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aliases = await _context.Aliases.FindAsync(id);
            if (aliases == null)
            {
                return NotFound();
            }
            return View(aliases);
        }

        // POST: Aliases/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("alias_id,criminal_id,alias")] Aliases aliases)
        {
            if (id != aliases.alias_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aliases);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AliasesExists(aliases.alias_id))
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
            return View(aliases);
        }

        // GET: Aliases/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aliases = await _context.Aliases
                .FirstOrDefaultAsync(m => m.alias_id == id);
            if (aliases == null)
            {
                return NotFound();
            }

            return View(aliases);
        }

        // POST: Aliases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aliases = await _context.Aliases.FindAsync(id);
            _context.Aliases.Remove(aliases);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AliasesExists(int id)
        {
            return _context.Aliases.Any(e => e.alias_id == id);
        }
    }
}

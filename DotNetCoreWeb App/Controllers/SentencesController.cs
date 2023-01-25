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
    public class SentencesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SentencesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Sentences
        public async Task<IActionResult> Index()
        {
            return View(await _context.Sentences.ToListAsync());
        }

        // GET: Sentences/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sentences = await _context.Sentences
                .FirstOrDefaultAsync(m => m.sentence_id == id);
            if (sentences == null)
            {
                return NotFound();
            }

            return View(sentences);
        }

        // GET: Sentences/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sentences/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("sentence_id,criminal_id,type,prob_id,start_date,end_date,violations")] Sentences sentences)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sentences);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sentences);
        }

        // GET: Sentences/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sentences = await _context.Sentences.FindAsync(id);
            if (sentences == null)
            {
                return NotFound();
            }
            return View(sentences);
        }

        // POST: Sentences/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("sentence_id,criminal_id,type,prob_id,start_date,end_date,violations")] Sentences sentences)
        {
            if (id != sentences.sentence_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sentences);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SentencesExists(sentences.sentence_id))
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
            return View(sentences);
        }

        // GET: Sentences/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sentences = await _context.Sentences
                .FirstOrDefaultAsync(m => m.sentence_id == id);
            if (sentences == null)
            {
                return NotFound();
            }

            return View(sentences);
        }

        // POST: Sentences/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sentences = await _context.Sentences.FindAsync(id);
            _context.Sentences.Remove(sentences);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SentencesExists(int id)
        {
            return _context.Sentences.Any(e => e.sentence_id == id);
        }
    }
}

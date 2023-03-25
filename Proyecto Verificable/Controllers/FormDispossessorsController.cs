using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proyecto_Verificable.Models;

namespace Proyecto_Verificable.Controllers
{
    public class FormDispossessorsController : Controller
    {
        private readonly BbddverificableContext _context;

        public FormDispossessorsController(BbddverificableContext context)
        {
            _context = context;
        }

        // GET: FormDispossessors
        public async Task<IActionResult> Index()
        {
            var bbddverificableContext = _context.FormDispossessors.Include(f => f.Form);
            return View(await bbddverificableContext.ToListAsync());
        }

        // GET: FormDispossessors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.FormDispossessors == null)
            {
                return NotFound();
            }

            var formDispossessor = await _context.FormDispossessors
                .Include(f => f.Form)
                .FirstOrDefaultAsync(m => m.FormDispossessorId == id);
            if (formDispossessor == null)
            {
                return NotFound();
            }

            return View(formDispossessor);
        }

        // GET: FormDispossessors/Create
        public IActionResult Create()
        {
            ViewData["FormId"] = new SelectList(_context.Forms, "FormId", "FormId");
            return View();
        }

        // POST: FormDispossessors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FormDispossessorId,FormId,DispossessorRunRut,DispossessorEntitlement,DispossessorPercentNotCredited")] FormDispossessor formDispossessor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(formDispossessor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FormId"] = new SelectList(_context.Forms, "FormId", "FormId", formDispossessor.FormId);
            return View(formDispossessor);
        }

        // GET: FormDispossessors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.FormDispossessors == null)
            {
                return NotFound();
            }

            var formDispossessor = await _context.FormDispossessors.FindAsync(id);
            if (formDispossessor == null)
            {
                return NotFound();
            }
            ViewData["FormId"] = new SelectList(_context.Forms, "FormId", "FormId", formDispossessor.FormId);
            return View(formDispossessor);
        }

        // POST: FormDispossessors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FormDispossessorId,FormId,DispossessorRunRut,DispossessorEntitlement,DispossessorPercentNotCredited")] FormDispossessor formDispossessor)
        {
            if (id != formDispossessor.FormDispossessorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(formDispossessor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FormDispossessorExists(formDispossessor.FormDispossessorId))
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
            ViewData["FormId"] = new SelectList(_context.Forms, "FormId", "FormId", formDispossessor.FormId);
            return View(formDispossessor);
        }

        // GET: FormDispossessors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.FormDispossessors == null)
            {
                return NotFound();
            }

            var formDispossessor = await _context.FormDispossessors
                .Include(f => f.Form)
                .FirstOrDefaultAsync(m => m.FormDispossessorId == id);
            if (formDispossessor == null)
            {
                return NotFound();
            }

            return View(formDispossessor);
        }

        // POST: FormDispossessors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.FormDispossessors == null)
            {
                return Problem("Entity set 'BbddverificableContext.FormDispossessors'  is null.");
            }
            var formDispossessor = await _context.FormDispossessors.FindAsync(id);
            if (formDispossessor != null)
            {
                _context.FormDispossessors.Remove(formDispossessor);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FormDispossessorExists(int id)
        {
          return (_context.FormDispossessors?.Any(e => e.FormDispossessorId == id)).GetValueOrDefault();
        }
    }
}

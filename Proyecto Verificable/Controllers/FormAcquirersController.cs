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
    public class FormAcquirersController : Controller
    {
        private readonly BbddverificableContext _context;

        public FormAcquirersController(BbddverificableContext context)
        {
            _context = context;
        }

        // GET: FormAcquirers
        public async Task<IActionResult> Index()
        {
            var bbddverificableContext = _context.FormAcquirers.Include(f => f.Form);
            return View(await bbddverificableContext.ToListAsync());
        }

        // GET: FormAcquirers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.FormAcquirers == null)
            {
                return NotFound();
            }

            var formAcquirer = await _context.FormAcquirers
                .Include(f => f.Form)
                .FirstOrDefaultAsync(m => m.FormAcquirerId == id);
            if (formAcquirer == null)
            {
                return NotFound();
            }

            return View(formAcquirer);
        }

        // GET: FormAcquirers/Create
        public IActionResult Create()
        {
            ViewData["FormId"] = new SelectList(_context.Forms, "FormId", "FormId");
            return View();
        }

        // POST: FormAcquirers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FormAcquirerId,FormId,AcquirerRunRut,AcquirerEntitlement,AcquirerPercentNotCredited")] FormAcquirer formAcquirer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(formAcquirer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FormId"] = new SelectList(_context.Forms, "FormId", "FormId", formAcquirer.FormId);
            return View(formAcquirer);
        }

        // GET: FormAcquirers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.FormAcquirers == null)
            {
                return NotFound();
            }

            var formAcquirer = await _context.FormAcquirers.FindAsync(id);
            if (formAcquirer == null)
            {
                return NotFound();
            }
            ViewData["FormId"] = new SelectList(_context.Forms, "FormId", "FormId", formAcquirer.FormId);
            return View(formAcquirer);
        }

        // POST: FormAcquirers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FormAcquirerId,FormId,AcquirerRunRut,AcquirerEntitlement,AcquirerPercentNotCredited")] FormAcquirer formAcquirer)
        {
            if (id != formAcquirer.FormAcquirerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(formAcquirer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FormAcquirerExists(formAcquirer.FormAcquirerId))
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
            ViewData["FormId"] = new SelectList(_context.Forms, "FormId", "FormId", formAcquirer.FormId);
            return View(formAcquirer);
        }

        // GET: FormAcquirers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.FormAcquirers == null)
            {
                return NotFound();
            }

            var formAcquirer = await _context.FormAcquirers
                .Include(f => f.Form)
                .FirstOrDefaultAsync(m => m.FormAcquirerId == id);
            if (formAcquirer == null)
            {
                return NotFound();
            }

            return View(formAcquirer);
        }

        // POST: FormAcquirers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.FormAcquirers == null)
            {
                return Problem("Entity set 'BbddverificableContext.FormAcquirers'  is null.");
            }
            var formAcquirer = await _context.FormAcquirers.FindAsync(id);
            if (formAcquirer != null)
            {
                _context.FormAcquirers.Remove(formAcquirer);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FormAcquirerExists(int id)
        {
          return (_context.FormAcquirers?.Any(e => e.FormAcquirerId == id)).GetValueOrDefault();
        }
    }
}

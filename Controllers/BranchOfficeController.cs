using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BOOKSTORE00.Data;
using BOOKSTORE00.Models;

namespace BOOKSTORE00.Controllers
{
    public class BranchOfficeController : Controller
    {
        private readonly BookContext _context;

        public BranchOfficeController(BookContext context)
        {
            _context = context;
        }

        // GET: BranchOffice
        public async Task<IActionResult> Index()
        {
            var bookContext = _context.BranchOffice.Include(b => b.Books);
            return View(await bookContext.ToListAsync());
        }

        // GET: BranchOffice/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.BranchOffice == null)
            {
                return NotFound();
            }

            var branchOffice = await _context.BranchOffice
                .Include(b => b.Books)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (branchOffice == null)
            {
                return NotFound();
            }

            return View(branchOffice);
        }

        // GET: BranchOffice/Create
        public IActionResult Create()
        {
            ViewData["BookId"] = new SelectList(_context.Book, "Id", "Id");
            return View();
        }

        // POST: BranchOffice/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Adress,Mail,Phone")] BranchOffice branchOffice)
        {   
            ModelState.Remove("Book");

            if (ModelState.IsValid)
            {
                _context.Add(branchOffice);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            
            return View(branchOffice);
        }

        // GET: BranchOffice/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.BranchOffice == null)
            {
                return NotFound();
            }

            var branchOffice = await _context.BranchOffice.FindAsync(id);
            if (branchOffice == null)
            {
                return NotFound();
            }
           
            return View(branchOffice);
        }

        // POST: BranchOffice/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Adress,Mail,Phone")] BranchOffice branchOffice)
        {
            if (id != branchOffice.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(branchOffice);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BranchOfficeExists(branchOffice.Id))
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
            
            return View(branchOffice);
        }

        // GET: BranchOffice/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.BranchOffice == null)
            {
                return NotFound();
            }

            var branchOffice = await _context.BranchOffice
                .Include(b => b.Books)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (branchOffice == null)
            {
                return NotFound();
            }

            return View(branchOffice);
        }

        // POST: BranchOffice/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.BranchOffice == null)
            {
                return Problem("Entity set 'BookContext.BranchOffice'  is null.");
            }
            var branchOffice = await _context.BranchOffice.FindAsync(id);
            if (branchOffice != null)
            {
                _context.BranchOffice.Remove(branchOffice);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BranchOfficeExists(int id)
        {
          return (_context.BranchOffice?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

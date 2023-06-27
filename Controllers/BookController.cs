using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BOOKSTORE00.Data;
using BOOKSTORE00.Models;
using BOOKSTORE00.ViewModels;

namespace BOOKSTORE00.Controllers
{
    public class BookController : Controller
    {
        private readonly BookContext _context;

        public BookController(BookContext context)
        {
            _context = context;
        }

         public async Task<IActionResult> Index(string NameFilter) 
        {
            var query = from book in _context.Book select book; 

            if (!string.IsNullOrEmpty(NameFilter)) 
            {
                query = query.Where(x => x.Name.ToLower().Contains(NameFilter.ToLower())
                || x.Price.ToString().Contains(NameFilter.ToLower()));
                
            } 
            
        
            var viewmodel = new BookViewModel();
            viewmodel.Books = await query.ToListAsync(); 
            
            return _context.Book != null ?  
                        View(viewmodel) : 
                        
                        Problem("Entity set 'BookContext.Book'  is null.");
        }


        // GET: Book/Details/5
        public async Task<IActionResult> Details(int? id) // viene con llamada get (url)
        {
            if (id == null || _context.Book == null)
            {
                return NotFound();
            }
            //Incluíme la relación .Traeme los datos de la relacion
            
            var book = await _context.Book.FirstOrDefaultAsync(m => m.Id == id); // Trae el primero que coincida con el id que recibe por parametro.
            if (book == null) 
            {
                return NotFound();
            }

            return View(book);
            
        }
        

        // GET: Book/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Book/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Autor,Editorial,Price,Condition,withcdordvd")] BookCreateViewModel bookview)
        {
        
            if (ModelState.IsValid)
            {
                
                var book = new Book {
                    Name = bookview.Name,
                    Autor = bookview.Autor,
                    Editorial = bookview.Editorial,
                    Price = bookview.Price,
                    Condition = bookview.Condition,
                    withcdordvd = bookview.withcdordvd,
                };
                
                _context.Add(book);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bookview);
        }

        // GET: Book/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Book == null)
            {
                return NotFound();
            }

            var book = await _context.Book.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        // POST: Book/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Autor,Editorial,Price,Condition,withcdordvd")] Book book)
        {
            if (id != book.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(book);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookExists(book.Id))
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
            return View(book);
        }

        // GET: Book/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Book == null)
            {
                return NotFound();
            }

            var book = await _context.Book
                .FirstOrDefaultAsync(m => m.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: Book/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Book == null)
            {
                return Problem("Entity set 'BookContext.Book'  is null.");
            }
            var book = await _context.Book.FindAsync(id);
            if (book != null)
            {
                _context.Book.Remove(book);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookExists(int id)
        {
            return (_context.Book?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

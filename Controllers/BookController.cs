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



        //  public async Task<IActionResult> Index1 (string name) 
        //  {
        //          var query = from book in  _context.Book select book;

        //        if (!string.IsNullOrEmpty(name)) 
        //        {
        //              query = query.Where(x => x.Name.Contains(name));
        //        }
        //        return _context.Book != null ? 
        //                    View(await query.ToListAsync()) :
        //                    Problem("Entity set 'BookContext.Book'  is null.");
        //  } 

        // GET: Book
        // FILTRO PARA BUSCAR POR NOMBRE.
        public async Task<IActionResult> Index(string NameFilter) // va a recibir un nombre // Se listan todos los elementos de la tabla Libro.
        {
            var query = from book in _context.Book select book; // sentencia solo crea una query y la tengo en esta variable.
            // Pone una query en la variable query/define una query (query)
            //Arma query pero no la ejecuta.

            if (!string.IsNullOrEmpty(NameFilter)) // Si el nombre no es nulo o vacio lo niega.
            {// Si tiene un valor entra aca.
                query = query.Where(x => x.Name.Contains(NameFilter)); //CADA ELEMENTO EN LA PROPIEDAD NOMBRE QUE CONTENGA POR PARAMETRO SE TRAE.
            }
            //Filtrame todos los elementos que en la propiedad name contenga lo que me venga en el filtro.
            var model = new BookViewModel();
             // ejecutar una query y devolver una lista.
            model.Books = await query.ToListAsync();

            return _context.Book != null ? // Lo convierte en lista.
                        View(model) :
                         // ejecutar una query y devolver una lista.
                        Problem("Entity set 'BookContext.Book'  is null.");// Luego la lista recupera una lista de elementos que tiene todos los elementos de la tabla.
        }



        // GET: Book/Details/5
        public async Task<IActionResult> Details(int? id)
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
        public async Task<IActionResult> Create([Bind("Id,Name,Autor,Editorial,Price,Condition,withcdordvd")] Book book)
        {
            if (ModelState.IsValid)
            {
                _context.Add(book);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(book);
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
        public async Task<IActionResult> Edit(int id, [Bind("Id,Autor,Name,Editorial,Price,Condition,withcdordvd")] Book book)
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

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
using BOOKSTORE00.Services;
using Microsoft.AspNetCore.Authorization;

namespace BOOKSTORE00.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        public IActionResult Index(string NameFilter)
        {
            var model = new BookViewModel();
            model.Books = _bookService.GetAll(NameFilter);
            return View(model);
        }

        [Authorize(Roles = "Principal Administrator, Administrator , Bookseller")]
        // GET: Book/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = _bookService.GetById(id.Value);
            if (book == null)
            {
                return NotFound();
            }

            var viewmodel = new BookDetailViewModel();
            viewmodel.Name = book.Name;
            viewmodel.Autor = book.Autor;
            viewmodel.Editorial = book.Editorial;
            viewmodel.Price = book.Price;
            viewmodel.Condition = book.Condition;
            viewmodel.withcdordvd = book.withcdordvd;
            //viewmodel.Branches = book.Branches != null? book.Branches : new List<BranchOffice>();
            

            return View(viewmodel);
        }

        [Authorize(Roles = "Principal Administrator, Administrator , Bookseller")]
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
        [Authorize(Roles = "Principal Administrator, Administrator , Bookseller")]
        public IActionResult Create([Bind("Id,Name,Autor,Editorial,Price,Condition,withcdordvd")] Book book)
        {
            ModelState.Remove("Branches");
            if (ModelState.IsValid)
            {
                _bookService.Create(book);
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        [Authorize(Roles = "Principal Administrator, Administrator , Bookseller")]
        // GET: Book/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = _bookService.GetById(id.Value);
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
        [Authorize(Roles = "Principal Administrator, Administrator , Bookseller")]
        public IActionResult Edit(int id, [Bind("Id,Name,Autor,Editorial,Price,Condition,withcdordvd")] Book book)
        {
            if (id != book.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _bookService.Update(book);

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

       [Authorize(Roles = "Principal Administrator, Administrator , Bookseller")]
        // GET: Book/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = _bookService.GetById(id.Value);

            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        [Authorize(Roles = "Principal Administrator, Administrator , Bookseller")]
        // POST: Book/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _bookService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        private bool BookExists(int id)
        {
            return _bookService.GetById(id) != null;
        }
    }
}

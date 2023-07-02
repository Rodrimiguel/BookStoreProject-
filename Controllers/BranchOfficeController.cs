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


namespace BOOKSTORE00.Controllers
{
    public class BranchOfficeController : Controller
    {
        private IBranchOfficeService _branchofficeService;

        private IBookService _bookService;

        public BranchOfficeController(IBranchOfficeService branchofficeService, IBookService bookService)
        {
            _branchofficeService = branchofficeService;
            _bookService = bookService;
        }

        // GET: BranchOffice
        /*
        public IActionResult Index()
        {
            var list = _branchofficeService.GetAll();
            return View(list);
        }
        */

        
         public IActionResult Index(string NameFilter)
        {
            var model = new BranchOfficeViewModel();
            model.Branches = _branchofficeService.GetAll(NameFilter);
            return View(model);
        }
        

        // GET: BranchOffice/Details/5
        public IActionResult Details(int? id) // Mandamos el Id y nos devuelve un elemento.
        {
            if (id == null)
            {
                return NotFound();
            }

            var branchOffice = _branchofficeService.GetById(id.Value);
            if (branchOffice == null)
            {
                return NotFound();
            }

            return View(branchOffice);
        }

        // GET: BranchOffice/Create
        public IActionResult Create()
        {
            var bookList = _bookService.GetAll();
            ViewData["Books"] = new SelectList(bookList, "Id", "Name");
            return View();
        }

        // POST: BranchOffice/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,Adress,Mail,Phone,BookIds")] BranchOfficeCreateViewModel branchOfficeView)
        {

            if (ModelState.IsValid)
            {
                //var books = _context.Book.Where(x=> branchOfficeView.BookIds.Contains(x.Id)).ToList();

                var branchOffice = new BranchOffice
                {
                    Name = branchOfficeView.Name,
                    Adress = branchOfficeView.Adress,
                    Mail = branchOfficeView.Mail,
                    Phone = branchOfficeView.Phone,
                    // Books = books,               
                };

                _branchofficeService.Create(branchOffice);

                return RedirectToAction(nameof(Index));
            }

            return View(branchOfficeView); // cuando el modelo no es válido
        }

        // GET: BranchOffice/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var branchOffice = _branchofficeService.GetById(id.Value);
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
        public IActionResult Edit(int id, [Bind("Id,Name,Adress,Mail,Phone,BookBranchOffice")] BranchOffice branchOffice)
        {
            if (id != branchOffice.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _branchofficeService.Update(branchOffice);
                return RedirectToAction(nameof(Index));
            }

            return View(branchOffice);
        }

        // GET: BranchOffice/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var branchOffice = _branchofficeService.GetById(id.Value);
            if (branchOffice == null)
            {
                return NotFound();
            }

            return View(branchOffice);
        }

        // POST: BranchOffice/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {

            var branchOffice = _branchofficeService.GetById(id);
            if (branchOffice != null)
            {
                _branchofficeService.Delete(branchOffice);
            }

            return RedirectToAction(nameof(Index));
        }

        private bool BranchOfficeExists(int id)
        {
            return _branchofficeService.GetById(id) != null;
        }
    }
}

using BOOKSTORE00.Models;
using BOOKSTORE00.Data;
using Microsoft.EntityFrameworkCore;

namespace BOOKSTORE00.Services;

public class BookService : IBookService
{
    private readonly BookContext _context;
    public BookService(BookContext context)
    {
        _context = context;
    }
    public void Create(Book obj)
    {
        _context.Add(obj);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
         var obj = GetById(id);
        
        if (obj != null){
            _context.Remove(obj);
            _context.SaveChanges();
        }
    }

    public List<Book> GetAll(string filter)
    {
        var query = GetQuery();

        if (!string.IsNullOrEmpty(filter))
        {
            query = query.Where(x => x.Name.Contains(filter));
        }

        return query.ToList();
    }

    public List<Book> GetAll()
    {
        var query = GetQuery();
        return query.ToList();
    }

    public Book? GetById(int id)
    {
        var book = GetQuery()
                .Include(x=> x.Branches)
                .FirstOrDefault(m => m.Id == id);

        return book;
    }

    public void Update(Book obj)
    {
       _context.Update(obj);
        _context.SaveChanges();
    }

    private IQueryable<Book> GetQuery()
    {
        return from book in _context.Book select book;
    }
}
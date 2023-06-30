using BOOKSTORE00.Models;

namespace BOOKSTORE00.Services;

public interface IBookService
{
    void Create(Book obj);

    List<Book> GetAll(string filter);

    List<Book> GetAll();

    void Update(Book obj);

    void Delete(int id);

    Book? GetById(int id);
}
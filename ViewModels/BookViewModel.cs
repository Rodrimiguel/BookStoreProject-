using BOOKSTORE00.Models;

namespace BOOKSTORE00.ViewModels;

public class BookViewModel{

            public List<Book> Books {get; set;}  = new List<Book>();

            public string? NameFilter {get;set;} // Puede venir nula.


}
using BOOKSTORE00.Models;

namespace BOOKSTORE00.ViewModels;

public class BookViewModel{ // CREACION DE VIEWMODEL

            public List<Book> Books {get; set;}  = new List<Book>(); // LISTA DE LIBROS
                                                    // INSTANCIAMOS.
            public string? NameFilter {get;set;} // Puede venir nula.


}
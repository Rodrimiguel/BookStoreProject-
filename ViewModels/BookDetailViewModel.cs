using BOOKSTORE00.Models;

namespace BOOKSTORE00.ViewModels;

public class BookDetailViewModel{

    public int Id { get; set; }
    public string Name { get; set; }
    
    public string Autor { get; set; }
    
    public string Editorial { get; set; }
    
    public decimal Price { get; set; }
    
    public string BookCondition  { get; set; }
    
    public bool withcdordvd { get; set; } = false;

    public List<BranchOffice> Branches { get; set; } // Para poder acceder a los datos de la sucursal si se quiere desde el modelo Libro.


}
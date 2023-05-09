using BOOKSTORE00.Utils;

namespace BOOKSTORE00.Models;

public class BranchOffice

{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Adress { get; set; }

    public string Mail { get; set; }

    public string Phone { get; set; }

    public int BookId { get; set; }

    public virtual Book Book { get; set; } // Cuando me quiera traer el objeto mapeado: Libro. / Me va a traer la realcion si yo se lo pido. / Virtual (mejor rendimiento)
                                            // Carga peresoza -  / Virtual (mejor rendimiento)
}
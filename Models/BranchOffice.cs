using BOOKSTORE00.Utils;
using System.ComponentModel.DataAnnotations;

namespace BOOKSTORE00.Models;

public class BranchOffice

{
    public int Id { get; set; }

    [Display(Name="NOMBRE")]
    public string Name { get; set; }

    [Display(Name="DIRECCIÓN")]
    public string Adress { get; set; }

    [Display(Name="CORREO ELECTRÓNICO")]
    public string Mail { get; set; }

    [Display(Name="TELÉFONO")]
    public string Phone { get; set; }

    [Display(Name="LIBROID")]
    public int BookId { get; set; }


    public virtual Book Book { get; set; } // Cuando me quiera traer el objeto mapeado: Libro. / Me va a traer la realcion si yo se lo pido. / Virtual (mejor rendimiento)
                                            // Carga peresoza -  / Virtual (mejor rendimiento)
}
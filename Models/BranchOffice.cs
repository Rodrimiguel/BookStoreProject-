using BOOKSTORE00.Utils;
using System.ComponentModel.DataAnnotations;

namespace BOOKSTORE00.Models;

public class BranchOffice

{
    public int Id { get; set; }

    [Display(Name = "NOMBRE")]
    public string Name { get; set; }

    [Display(Name = "DIRECCIÓN")]
    public string Adress { get; set; }

    [Display(Name = "CORREO ELECTRÓNICO")]
    public string Mail { get; set; }

    [Display(Name = "TELÉFONO")]
    public string Phone { get; set; }

    public virtual List<Book> Books { get; set; }
}
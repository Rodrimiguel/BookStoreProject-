using BOOKSTORE00.Utils;
using System.ComponentModel.DataAnnotations;

namespace BOOKSTORE00.Models;

public class Book

{
    public int Id { get; set; }
    
    [Display(Name="NOMBRE")]
    public string Name { get; set; }
    
    [Display(Name="AUTOR")]
    public string Autor { get; set; }
    
    [Display(Name="EDITORIAL")]
    public string Editorial { get; set; }
    
    [Display(Name="PRECIO")]
    public decimal Price { get; set; }
    
    [Display(Name="CONDICIÓN")]
    public BookCondition Condition { get; set; }
    
    [Display(Name="CON CD O DVD")]
    public bool withcdordvd { get; set; } = false;

    public virtual List<BranchOffice> Branches { get; set; } // Para poder acceder a los datos de la sucursal si se quiere desde el modelo Libro.

}
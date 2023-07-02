using BOOKSTORE00.Models;

namespace BOOKSTORE00.ViewModels;

public class BranchOfficeCreateViewModel
{ // CREACION DE VIEWMODEL
    internal List<BranchOffice> branches;

    public int Id { get; set; }


    public string Name { get; set; }


    public string Adress { get; set; }


    public string Mail { get; set; }


    public string Phone { get; set; }


     public string? NameFilter {get;set;} // Puede venir nula.


    //public List <int> BookIds {get;set;}

}
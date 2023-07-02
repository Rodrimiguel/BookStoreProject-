using BOOKSTORE00.Models;
using BOOKSTORE00.Utils;

namespace BOOKSTORE00.ViewModels;


public class BranchOfficeViewModel{

            
            public string Name { get; set; }

            public string Adress { get; set; }

             public string Mail { get; set; }

             public string Phone { get; set; }
             

            public List<BranchOffice> Branches {get;set;} = new List<BranchOffice>();

            public string? NameFilter {get;set;}

}

using BOOKSTORE00.Models;

namespace Viewmodels;


public class BranchOfficeViewModel{

            public List<BranchOffice> Branches {get;set;} = new List<BranchOffice>();

            public string NameFilter {get;set;}

}
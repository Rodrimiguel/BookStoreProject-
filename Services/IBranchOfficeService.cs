using BOOKSTORE00.Models;
using BOOKSTORE00.ViewModels;

namespace BOOKSTORE00.Services;

public interface IBranchOfficeService
{
    void Create(BranchOffice obj);

    List<BranchOffice> GetAll(string filter);

    List<BranchOffice> GetAll();

    void Update(BranchOffice obj);

    void Delete(BranchOffice obj);

    BranchOffice? GetById(int id);
    void Update(BranchOfficeEditViewModel branchOffice);
}
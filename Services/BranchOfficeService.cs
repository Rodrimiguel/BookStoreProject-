using BOOKSTORE00.Data;
using BOOKSTORE00.Models;
using Microsoft.EntityFrameworkCore;

namespace BOOKSTORE00.Services;

public class BranchOfficeService : IBranchOfficeService
{
    private readonly BookContext _context;

    public BranchOfficeService(BookContext context) // Constructor recibe un objeto del tipo BookContext.
    {
        _context = context;
    }
    public void Create(BranchOffice obj)
    {
         _context.Add(obj);
        _context.SaveChanges();
    }

    public void Delete(BranchOffice obj)
    {
         _context.Remove(obj);
        _context.SaveChanges();
    }
  
    /*
    public List<BranchOffice> GetAll(string filter)
    {
        
    }
    */
    
    public List<BranchOffice> GetAll()
    {
        return _context.BranchOffice.Include(r => r.Books).ToList();
    }

    public BranchOffice? GetById(int id)
    {
        var branchOffice = _context.BranchOffice
                .Include(r => r.Books)
                .FirstOrDefault(m => m.Id == id);

        return branchOffice;
    }

    public void Update(BranchOffice obj)
    {
        
    }
}
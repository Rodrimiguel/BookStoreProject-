using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BOOKSTORE00.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace BOOKSTORE00.Data
{
    public class BookContext : IdentityDbContext
    {
        public BookContext(DbContextOptions<BookContext> options)
            : base(options)
        {
        }

        public DbSet<BOOKSTORE00.Models.Book> Book { get; set; } = default!;
        // Agregado de propiedad para manipular el objeto book que es una tabla en nuestra base de datos.

        public DbSet<BOOKSTORE00.Models.BranchOffice> BranchOffice { get; set; } = default!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Book>()
            .HasMany(p => p.Branches)
            .WithMany(p => p.Books)
            .UsingEntity("BookBranchOffice");

            base.OnModelCreating(modelBuilder);            
        }
    }
}

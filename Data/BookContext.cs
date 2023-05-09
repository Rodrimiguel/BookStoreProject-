using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BOOKSTORE00.Models;

namespace BOOKSTORE00.Data
{
    public class BookContext : DbContext
    {
        public BookContext(DbContextOptions<BookContext> options)
            : base(options)
        {
        }

        public DbSet<BOOKSTORE00.Models.Book> Book { get; set; } = default!;

        public DbSet<BOOKSTORE00.Models.BranchOffice> BranchOffice { get; set; } = default!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
            .HasMany(p => p.Branches)
            .WithOne(p => p.Book)
            .HasForeignKey(p => p.BookId);
        }
    }
}

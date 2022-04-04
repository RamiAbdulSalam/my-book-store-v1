using FirstCoreWebAPIApplication.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstCoreWebAPIApplication.Data
{
    public class AppDbContext:DbContext 
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
            
        }

        // Fluent API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure book-author-books
            modelBuilder.Entity<Book_Author>().HasOne(b => b.Books).WithMany(ba => ba.Book_Authors).HasForeignKey(bi => bi.BooksId);

            // Configure book-author-author
            modelBuilder.Entity<Book_Author>().HasOne(b => b.Author).WithMany(ba => ba.Book_Authors).HasForeignKey(bi => bi.AuthorId);
        }

        public DbSet<Books> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book_Author> Book_Authors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
    }
}

using FirstCoreWebAPIApplication.Data.Models;
using FirstCoreWebAPIApplication.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstCoreWebAPIApplication.Data.Services
{
    public class AuthorService
    {

        #region DI_context
        private AppDbContext _context;
        public AuthorService(AppDbContext context)
        {
            _context = context;
        }
        #endregion

        // Add New Author 
        public void AddAuthor(AuthorVM author)
        {
            var _author = new Author()
            {
                FullName = author.FullName
            };
            _context.Authors.Add(_author);
            _context.SaveChanges();
        }

        public AuthorwithBookVM GetAuthorWithBooksByAuthorid(int authorId)
        {
            var authorWithBooks = _context.Authors.Where(x => x.Id == authorId)
                .Select(y => new AuthorwithBookVM()
                {
                    FullName = y.FullName,
                    booksTitles = y.Book_Authors.Select(a => a.Books.Title).ToList()
                }).FirstOrDefault();
            return authorWithBooks;
        }

    }
}

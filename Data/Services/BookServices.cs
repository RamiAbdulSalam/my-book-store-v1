using FirstCoreWebAPIApplication.Data.Models;
using FirstCoreWebAPIApplication.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstCoreWebAPIApplication.Data.Services
{
    public class BookServices
    {
        #region DI_context
        private AppDbContext _context;
        public BookServices(AppDbContext context)
        {
            _context = context;
        }
        #endregion

        // Add New Book 
        public void AddBookWithAuthor(BookVM book)
        {
            var _book = new Books()
            {
                Title = book.Title,
                Description = book.Description,
                CoverUrl = book.CoverUrl,
                Genre = book.Genre,
                IsRead = book.IsRead,
                DateAdded = DateTime.Now,
                DateRead = book.IsRead ? book.DateRead.Value : null,
                Rate = book.IsRead ? book.Rate.Value : null,
                PublisherId = book.PublisherId
            };
            _context.Books.Add(_book);
            _context.SaveChanges();

            foreach (var Id in book.AuthorIds)
            {
                var _bookAuthor = new Book_Author()
                {
                    BooksId = _book.Id,
                    AuthorId = Id
                };
                _context.Book_Authors.Add(_bookAuthor);
                _context.SaveChanges();
            }
           
        }

        public List<Books> GetAllBooks()
        {
            return _context.Books.ToList();

        }

        public Books GetbookById(int bookId)
        {
            return _context.Books.FirstOrDefault(x => x.Id == bookId);

        }

        public BookwithAuthorVM GetBookById(int bookId)
        {
            BookwithAuthorVM bookWithAuther = _context.Books.Where(x => x.Id == bookId)
                .Select(book => new BookwithAuthorVM()
                {
                    Title = book.Title,
                    Description = book.Description,
                    CoverUrl = book.CoverUrl,
                    Genre = book.Genre,
                    IsRead = book.IsRead,
                    DateRead = book.IsRead ? book.DateRead.Value : null,
                    Rate = book.IsRead ? book.Rate.Value : null,
                    PublisherName = book.Publisher.Name,
                    AuthorsNames= book.Book_Authors.Select(x=>x.Author.FullName).ToList()
                }).FirstOrDefault();
            return bookWithAuther;
        }

        public Books UpdateBook(int bookId, BookVM book)
        {
            var bookToUpdate = GetbookById(bookId);
            if (bookToUpdate != null)
            {
                bookToUpdate.Title = book.Title;
                bookToUpdate.Description = book.Description;
                bookToUpdate.IsRead = book.IsRead;
                bookToUpdate.DateRead = book.DateRead;
                bookToUpdate.Rate = book.Rate;
                bookToUpdate.CoverUrl = book.CoverUrl;
                bookToUpdate.Genre = book.Genre;
                _context.SaveChanges();
            }
            return bookToUpdate;

        }

        public void DeleteBook(int bookId)
        {
            var bookToDelete = GetbookById(bookId);
            if (bookToDelete != null)
            {
                _context.Books.Remove(bookToDelete);
                _context.SaveChanges();
            }
        }
    }
}

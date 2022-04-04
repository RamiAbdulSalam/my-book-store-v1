using FirstCoreWebAPIApplication.Data.Models;
using FirstCoreWebAPIApplication.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;

namespace FirstCoreWebAPIApplication.Data.Services
{
    public class PublisherService
    {

        #region DI_context
        private AppDbContext _context;
        public PublisherService(AppDbContext context)
        {
            _context = context;
        }
        #endregion

        // Add New Author 
        public void AddPublisher(PublisherVM publisher)
        {
            var _publisher = new Publisher()
            {
                Name = publisher.Name
            };
            _context.Publishers.Add(_publisher);
            _context.SaveChanges();
        }

        public PublisherWithBooksVM GetPublisherWithBooks(int publisherId)
        {
            var publisherWithBook = _context.Publishers.Where(x => x.Id == publisherId)
                .Select(p => new PublisherWithBooksVM()
                {
                    Name = p.Name,
                    BookWithAuthors = p.Books.Select(b => new BookWithAuthors()
                    {
                        BookName = b.Title,
                        AuthorsNames = b.Book_Authors.Select(a => a.Author.FullName).ToList()
                    }).ToList()
                }).FirstOrDefault();

            return publisherWithBook;
        }

        public void DeletePublisher(int publisherId)
        {
            var _publisher = _context.Publishers.FirstOrDefault(x => x.Id == publisherId);
            if ( _publisher != null)
            {
                _context.Publishers.Remove(_publisher);
                _context.SaveChanges();
            }            
        }
    }
}

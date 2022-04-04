using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstCoreWebAPIApplication.Data.Models
{
    public class Book_Author
    {
        public int Id { get; set; }

        // Navigation Property
        public int BooksId { get; set; }
        public Books Books { get; set; }

        public int AuthorId { get; set; }
        public Author Author { get; set; }
    }
}

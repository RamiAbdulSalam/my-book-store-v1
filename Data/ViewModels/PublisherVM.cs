using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstCoreWebAPIApplication.Data.ViewModels
{
    public class PublisherVM
    {
        public string Name { get; set; }
    }

    public class PublisherWithBooksVM
    {
        public string Name { get; set; }
        public List<BookWithAuthors> BookWithAuthors { get; set; }
    }

    public class BookWithAuthors
    {
        public string BookName { get; set; }
        public List<string> AuthorsNames { get; set; }

    }
}

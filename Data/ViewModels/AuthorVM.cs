using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstCoreWebAPIApplication.Data.ViewModels
{
    public class AuthorVM
    {
        public string FullName { get; set; }
    }

    public class AuthorwithBookVM
    {
        public string FullName { get; set; }
        public List<string> booksTitles { get; set; }
    }
}

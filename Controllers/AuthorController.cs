using FirstCoreWebAPIApplication.Data.Services;
using FirstCoreWebAPIApplication.Data.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstCoreWebAPIApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        #region DI_bookSerivices
        public AuthorService _authorServices;
        public AuthorController(AuthorService authorServices)
        {
            _authorServices = authorServices;
        }
        #endregion

        [HttpPost("add-author")]
        public IActionResult AddAuthor([FromBody]  AuthorVM author)
        {
            _authorServices.AddAuthor(author);
            return Ok();
        }

        [HttpGet("get-author-with-books-by-id/{Id}")]
        public IActionResult GetAuthorWithBooksById(int Id)
        {
            var author = _authorServices.GetAuthorWithBooksByAuthorid(Id);
            return Ok(author);
        }
    }
}

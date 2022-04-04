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
    public class BooksController : ControllerBase
    {
        #region DI_bookSerivices
        public BookServices _bokServices;
        public BooksController(BookServices bookServices)
        {
            _bokServices = bookServices;
        }
        #endregion

        [HttpPost("add-book-with-author")]
        public IActionResult AddBook(BookVM book)
        {
            _bokServices.AddBookWithAuthor(book);
            return Ok();
        }

        [HttpGet("GetAllBooks")]
        public IActionResult GetAllBooks()
        {
            var booksList = _bokServices.GetAllBooks();
            return Ok(booksList);
        }

        [HttpGet("GetBookById/{id}")]
        public IActionResult GetBookById(int id)
        {
            var book = _bokServices.GetBookById(id);
            return Ok(book);
        }

        [HttpPut("update-book/{id}")]
        public IActionResult UpdateBook(int id,[FromBody] BookVM newBook)
        {
            var bookAfterUpdate = _bokServices.UpdateBook(id,newBook);
            return Ok(bookAfterUpdate);
        }

        [HttpDelete("delete-book/{id}")]
        public IActionResult DeleteBook(int id)
        {
            _bokServices.DeleteBook(id);
            return Ok();
        }

    }
}

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
    public class PublisherController : ControllerBase
    {
        #region DI_bookSerivices
        public PublisherService _publisherServices;
        public PublisherController(PublisherService publisherServices)
        {
            _publisherServices = publisherServices;
        }
        #endregion

        [HttpPost("add-publisher")]
        public IActionResult AddPublisher([FromBody] PublisherVM publisher)
        {
            _publisherServices.AddPublisher(publisher);
            return Ok();
        }

        [HttpGet("get-publisher-with-books-by-id/{Id}")]
        public IActionResult GetPublisherWithBooksById(int Id)
        {
           var publisherWithBooks=  _publisherServices.GetPublisherWithBooks(Id);
            return Ok(publisherWithBooks);
        }

        [HttpDelete("remove-publisher-by_id/{Id}")]
        public IActionResult DeletePublisher(int Id)
        {
            _publisherServices.DeletePublisher(Id);
            return Ok();
        }
    }
}

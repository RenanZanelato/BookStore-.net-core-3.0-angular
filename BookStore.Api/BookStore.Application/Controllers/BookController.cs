using BookStore.Domain.Entities;
using BookStore.Domain.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BookStore.Application.Controllers
{
    public class BookController : BaseController<Book>
    {
        private readonly IBookService _serviceBook;
        public BookController(IBookService bookService): base(bookService)
        {
            _serviceBook = bookService;
        }

        [HttpGet]
        [Route("filter")]
        public ActionResult GetAllWithAuthorAndGenre()
        {
            return Ok(_serviceBook.GetInfoBookAuthorAndGenre(null));
        }
        [HttpGet]
        [Route("{id}/filter")]
        public ActionResult GetOnlyWithAuthorAndGenre(Guid id)
        {
            return Ok(_serviceBook.GetInfoBookAuthorAndGenre(id));
        }
    }
}

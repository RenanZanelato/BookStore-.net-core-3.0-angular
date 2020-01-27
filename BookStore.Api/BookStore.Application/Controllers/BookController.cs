using BookStore.Domain.Entities;
using BookStore.Domain.Interfaces.Service;

namespace BookStore.Application.Controllers
{
    public class BookController : BaseController<Book>
    {
        public BookController(IBookService bookService): base(bookService)
        {
        }
    }
}

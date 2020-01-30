using BookStore.Domain.Entities;
using BookStore.Domain.Interfaces.Service;

namespace BookStore.Application.Controllers
{
    public class AuthorController : BaseController<Author>
    {
        public AuthorController(IAuthorService authorService) : base(authorService)
        {
        }
    }
}

using BookStore.Domain.Entities;
using BookStore.Domain.Interfaces.Service;

namespace BookStore.Application.Controllers
{

    public class GenreController : BaseController<Genre>
    {
        public GenreController(IGenreService genreService) : base(genreService)
        {
        }
    }
}

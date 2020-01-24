using BookStore.Domain.Entities;
using BookStore.Domain.Interfaces.Repository;
using BookStore.Domain.Interfaces.Service;

namespace BookStore.Service.Service
{
    public class GenreService : BaseService<Genre>, IGenreService
    {
        private readonly IGenreRepository _genreRepository;
        public GenreService(IGenreRepository genreRepository) : base(genreRepository)
        {
            _genreRepository = genreRepository;
        }
    }
}

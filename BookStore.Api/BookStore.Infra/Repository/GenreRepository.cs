using BookStore.Domain.Entities;
using BookStore.Domain.Interfaces.Repository;
using BookStore.Infra.Context;

namespace BookStore.Infra.Repository
{
    public class GenreRepository : BaseRepository<Genre>, IGenreRepository
    {
        public GenreRepository(MyContext context) : base(context)
        {
        }
    }
}

using BookStore.Domain.Entities;
using BookStore.Domain.Interfaces.Repository;
using BookStore.Infra.Context;

namespace BookStore.Infra.Repository
{
    public class AuthorRepository : BaseRepository<Author>, IAuthorRepository
    {
        public AuthorRepository(MyContext context) : base(context)
        {
        }
    }
}

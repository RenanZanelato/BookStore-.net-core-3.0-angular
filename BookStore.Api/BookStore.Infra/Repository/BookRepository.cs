using BookStore.Domain.Entities;
using BookStore.Domain.Interfaces.Repository;
using BookStore.Infra.Context;

namespace BookStore.Infra.Repository
{
    public class BookRepository : BaseRepository<Book>, IBookRepository
    {
        public BookRepository(MyContext context) : base(context)
        {
        }
    }
}

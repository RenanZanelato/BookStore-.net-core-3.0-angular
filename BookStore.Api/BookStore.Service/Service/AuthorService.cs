using BookStore.Domain.Entities;
using BookStore.Domain.Interfaces.Repository;
using BookStore.Domain.Interfaces.Service;

namespace BookStore.Service.Service
{
    public class AuthorService : BaseService<Author>, IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;
        public AuthorService(IAuthorRepository authorRepository) : base(authorRepository)
        {
            _authorRepository = authorRepository;
        }
    }
}

using BookStore.Domain.Entities;
using BookStore.Domain.Interfaces.Repository;
using BookStore.Domain.Interfaces.Service;

namespace BookStore.Service.Service
{
    public class BookService : BaseService<Book>, IBookService
    {
        private readonly IBookRepository _bookRepository;
        public BookService(IBookRepository bookRepository) : base(bookRepository)
        {
            _bookRepository = bookRepository;
        }

    }
}

using BookStore.Domain.Entities;
using BookStore.Domain.Interfaces.Repository;
using BookStore.Domain.Interfaces.Service;
using System;

namespace BookStore.Service.Service
{
    public class BookService : BaseService<Book>, IBookService
    {
        private readonly IBookRepository _bookRepository;
        public BookService(IBookRepository bookRepository) : base(bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public override Book Post(Book obj)
        {
            obj.Id = Guid.NewGuid();
            foreach (BookAuthor bookAuthor in obj.BookAuthor)
            {
                if (bookAuthor.AuthorId == null)
                {
                    continue;
                }
                bookAuthor.BookId = obj.Id;
            }

            foreach (BookGenre bookGenre in obj.BookGenre)
            {
                if (bookGenre.GenreId == null)
                {
                    continue;
                }
                bookGenre.BookId = obj.Id;
            }
            return base.Post(obj);
        }
    }
}

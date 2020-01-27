using BookStore.Domain.Entities;
using BookStore.Domain.Interfaces.Repository;
using BookStore.Domain.Interfaces.Service;
using System;

namespace BookStore.Service.Service
{
    public class BookService : BaseService<Book>, IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly IGenreRepository _genreRepository;
        public BookService(IBookRepository bookRepository,IAuthorRepository authorRepository,IGenreRepository genreRepository) : base(bookRepository)
        {
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
            _genreRepository = genreRepository;
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
                Author verifyAuthor = _authorRepository.Select(bookAuthor.AuthorId);
                if(verifyAuthor == null)
                {
                    throw new Exception("Author " + bookAuthor.AuthorId + "don't exist in database");
                }
                bookAuthor.BookId = obj.Id;
            }

            foreach (BookGenre bookGenre in obj.BookGenre)
            {
                if (bookGenre.GenreId == null)
                {
                    continue;
                }
                Genre verifyGenre = _genreRepository.Select(bookGenre.GenreId);
                if (verifyGenre == null)
                {
                    throw new Exception("Author " + bookGenre.GenreId + "don't exist in database");
                }
                bookGenre.BookId = obj.Id;
            }
            return base.Post(obj);
        }
    }
}

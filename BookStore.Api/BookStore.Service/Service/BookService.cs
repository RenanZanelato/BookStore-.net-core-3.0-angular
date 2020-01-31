using BookStore.Domain.Entities;
using BookStore.Domain.Exceptions;
using BookStore.Domain.Interfaces.Repository;
using BookStore.Domain.Interfaces.Service;
using BookStore.Domain.ModelViews.Response;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        public IEnumerable<SelectInfoBookAuthorAndGenre> GetInfoBookAuthorAndGenre(Guid? id)
        {
            return _bookRepository.SelectInfoAuthorAndGenre(id);
        }

        public override async Task<Book> Post(Book obj)
        {
            obj.Id = Guid.NewGuid();
            if (obj.BookAuthor.Count >= 1)
            {
                foreach (BookAuthor bookAuthor in obj.BookAuthor)
                {
                    if (bookAuthor.AuthorId == null)
                    {
                        continue;
                    }
                    Author verifyAuthor = await _authorRepository.Select(bookAuthor.AuthorId);
                    if (verifyAuthor == null)
                    {
                        throw new AuthorException("Author " + bookAuthor.AuthorId + "don't exist in database");
                    }
                    bookAuthor.BookId = obj.Id;
                }
            }
            if(obj.BookGenre.Count >= 1) { 
            foreach (BookGenre bookGenre in obj.BookGenre)
            {
                if (bookGenre.GenreId == null)
                {
                    continue;
                }
                Genre verifyGenre = await _genreRepository.Select(bookGenre.GenreId);
                if (verifyGenre == null)
                {
                    throw new GenreException("Genre " + bookGenre.GenreId + "don't exist in database");
                }
                bookGenre.BookId = obj.Id;
            }
            }
            return await base.Post(obj);
        }
    }
}

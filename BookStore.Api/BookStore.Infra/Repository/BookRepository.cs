using BookStore.Domain.Entities;
using BookStore.Domain.Interfaces.Repository;
using BookStore.Domain.ModelViews.Response;
using BookStore.Infra.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Infra.Repository
{
    public class BookRepository : BaseRepository<Book>, IBookRepository
    {

        public BookRepository(MyContext context) : base(context)
        {
        }

        public IEnumerable<SelectInfoBookAuthorAndGenre> SelectInfoAuthorAndGenre(Guid? BookId = null)
        {
            var query = _context.Set<Book>()
                .Select(obj => new SelectInfoBookAuthorAndGenre
                {
                    BookId = obj.Id,
                    Name = obj.Name,
                    Price = obj.Price,
                    Authors = obj.BookAuthor.Select(author => author.Author),
                    Genres = obj.BookGenre.Select(genre => genre.Genre)
                });

            if (BookId != null)
            {
                return query.Where(p => p.BookId == BookId).ToList();
            }

            return query.ToList();
        }
    }
}

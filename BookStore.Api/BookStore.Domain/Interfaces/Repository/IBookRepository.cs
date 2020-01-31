using BookStore.Domain.Entities;
using BookStore.Domain.ModelViews.Response;
using System;
using System.Collections.Generic;

namespace BookStore.Domain.Interfaces.Repository
{
    public interface IBookRepository : IBaseRepository<Book>
    {
        IEnumerable<SelectInfoBookAuthorAndGenre> SelectInfoAuthorAndGenre(Guid? id = null);
    }
}


using BookStore.Domain.Entities;
using BookStore.Domain.ModelViews.Response;
using System;
using System.Collections.Generic;

namespace BookStore.Domain.Interfaces.Service
{
    public interface IBookService : IBaseService<Book>
    {
        IEnumerable<SelectInfoBookAuthorAndGenre> GetInfoBookAuthorAndGenre(Guid? id);
    }
}


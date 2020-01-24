using BookStore.Domain.Entities;
using System;
using System.Collections.Generic;

namespace BookStore.Domain.Interfaces.Repository
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        T Insert(T obj);
        T Update(T obj);
        bool Delete(Guid id);
        T Select(Guid id);
        IEnumerable<T> SelectAll();
    }
}


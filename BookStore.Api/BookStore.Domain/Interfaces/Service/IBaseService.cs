using BookStore.Domain.Entities;
using System;
using System.Collections.Generic;

namespace BookStore.Domain.Interfaces.Service
{
    public interface IBaseService<T> where T : BaseEntity
    {
        T Post(T obj);

        T Put(T obj);
        void Delete(Guid id);

        T Get(Guid id);

        IEnumerable<T> Get();
    }
}


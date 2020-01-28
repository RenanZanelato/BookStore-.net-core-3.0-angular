using BookStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.Domain.Interfaces.Service
{
    public interface IBaseService<T> where T : BaseEntity
    {
        Task<T> Post(T obj);

        Task<T> Put(T obj);
        Task<bool> Delete(Guid id);

        Task<T> Get(Guid id);

        Task<IEnumerable<T>> Get();
    }
}


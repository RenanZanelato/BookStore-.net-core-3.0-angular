using BookStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.Domain.Interfaces.Repository
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<T> Insert(T obj);
        Task<T> Update(T obj);
        Task<bool> Delete(Guid id);
        Task<T> Select(Guid id);
        Task<IEnumerable<T>> SelectAll();
    }
}


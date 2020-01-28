using BookStore.Domain.Entities;
using BookStore.Domain.Interfaces.Repository;
using BookStore.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.Service.Service
{
    public class BaseService<T> : IBaseService<T> where T : BaseEntity
    {
        private readonly IBaseRepository<T> _repository;
        public BaseService(IBaseRepository<T> repository) 
        {
            _repository = repository;
        }
        public virtual async Task<bool> Delete(Guid id)
        {
            return await _repository.Delete(id);
        }

        public virtual async Task<T> Get(Guid id)
        {
            return await _repository.Select(id);
        }

        public virtual async Task<IEnumerable<T>> Get()
        {
            return await _repository.SelectAll();
        }

        public virtual async Task<T> Post(T obj)
        {
            return await _repository.Insert(obj);
        }

        public virtual async Task<T> Put(T obj)
        {
            return await _repository.Update(obj);
        }
    }
}

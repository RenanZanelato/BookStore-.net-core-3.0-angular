using BookStore.Domain.Entities;
using BookStore.Domain.Interfaces.Repository;
using BookStore.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;

namespace BookStore.Service.Service
{
    public class BaseService<T> : IBaseService<T> where T : BaseEntity
    {
        private readonly IBaseRepository<T> _repository;
        public BaseService(IBaseRepository<T> repository) 
        {
            _repository = repository;
        }
        public void Delete(Guid id)
        {
            _repository.Delete(id);
        }

        public T Get(Guid id)
        {
            return _repository.Select(id);
        }

        public IEnumerable<T> Get()
        {
            return _repository.SelectAll();
        }

        public T Post(T obj)
        {
            return _repository.Insert(obj);
        }

        public T Put(T obj)
        {
            return _repository.Update(obj);
        }
    }
}

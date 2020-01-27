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
        public virtual void Delete(Guid id)
        {
            _repository.Delete(id);
        }

        public virtual T Get(Guid id)
        {
            return _repository.Select(id);
        }

        public virtual IEnumerable<T> Get()
        {
            return _repository.SelectAll();
        }

        public virtual T Post(T obj)
        {
            return _repository.Insert(obj);
        }

        public virtual T Put(T obj)
        {
            return _repository.Update(obj);
        }
    }
}

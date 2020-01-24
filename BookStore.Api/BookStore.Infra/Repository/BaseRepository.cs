using BookStore.Domain.Entities;
using BookStore.Domain.Interfaces.Repository;
using BookStore.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Infra.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly MyContext _context;
        public BaseRepository(MyContext context)
        {
            _context = context;
        }

        public bool Delete(Guid id)
        {
            var result = Select(id);
            if(result == null)
            {
                throw new Exception("Any data to delete");
            }
            _context.Set<T>().Remove(result);
            _context.SaveChanges();
            return true;
        }

        public T Insert(T obj)
        {
            obj.CreatedAt = DateTime.UtcNow;
            obj.UpdateAt = DateTime.UtcNow;
            _context.Set<T>().Add(obj);
            _context.SaveChanges();

            return obj;
        }

        public T Select(Guid id)
        {
            return _context.Set<T>().Find(id);
        }

        public IEnumerable<T> SelectAll()
        {
            return _context.Set<T>().ToList();
        }

        public T Update(T obj)
        {
            var result = Select(obj.Id);
            if(result == null)
            {
                throw new Exception("Any data to Update");
            }
            obj.UpdateAt = DateTime.UtcNow;
            obj.CreatedAt = result.CreatedAt;

            _context.Entry(result).CurrentValues.SetValues(obj);
            _context.SaveChanges();
            return obj;
        }
    }
}

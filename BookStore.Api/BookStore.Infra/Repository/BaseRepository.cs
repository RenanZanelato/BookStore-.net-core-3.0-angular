using BookStore.Domain.Entities;
using BookStore.Domain.Interfaces.Repository;
using BookStore.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Infra.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly MyContext _context;
        private DbSet<T> _dataset;
        public BaseRepository(MyContext context)
        {
            _context = context;
            _dataset = context.Set<T>();
        }

        public async Task<bool> Delete(Guid id)
        {
            var result = await _dataset.SingleOrDefaultAsync(p => p.Id.Equals(id));
            if (result == null)
            {
                throw new Exception("Any data to delete");
            }
            _dataset.Remove(result);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<T> Insert(T item)
        {
            if (item.Id == Guid.Empty)
            {
                item.Id = Guid.NewGuid();
            }
            item.CreatedAt = DateTime.UtcNow;
            _dataset.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<T> Select(Guid id)
        {
            var result = await _dataset.SingleOrDefaultAsync(p => p.Id.Equals(id));
            return result;
        }

        public async Task<IEnumerable<T>> SelectAll()
        {
            return await _dataset.ToListAsync();
        }

        public async Task<T> Update(T item)
        {
            var result = await _dataset.SingleOrDefaultAsync(p => p.Id.Equals(item.Id));
            if (result == null)
            {
                throw new Exception("Any data to update");
            }
            item.UpdateAt = DateTime.UtcNow;
            item.CreatedAt = result.CreatedAt;
            _context.Entry(result).CurrentValues.SetValues(item);
            await _context.SaveChangesAsync();
            return result;
        }
    }
}


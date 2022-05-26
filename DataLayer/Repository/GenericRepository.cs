using CoreLayer.Interfaces.Repository;
using DataLayer.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository
{
   public class GenericRepository<T>:IGenericRepository<T> where T:class
    {
        protected readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
            context.Database.EnsureCreated();
        }

        public async Task AddAsync(T t)
        {
            await _dbSet.AddAsync(t);
        }

        public async Task AddRangeAsync(IEnumerable<T> Entities)
        {
            await _dbSet.AddRangeAsync(Entities);
        }

        public async Task<IEnumerable<T>> getAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> getByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public void Remove(T t)
        {
            _dbSet.Remove(t);
        }

        public void RemoveRange(IEnumerable<T> Entities)
        {
            _dbSet.RemoveRange(Entities);
        }

        public void Update(T t)
        {
            _dbSet.Update(t);
        }
    }
}

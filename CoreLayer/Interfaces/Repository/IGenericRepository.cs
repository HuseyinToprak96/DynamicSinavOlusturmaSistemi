using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Interfaces.Repository
{
    public interface IGenericRepository<T> where T:class
    {
        Task<IEnumerable<T>> getAllAsync();
        Task<T> getByIdAsync(int id);
        Task AddAsync(T t);
        Task AddRangeAsync(IEnumerable<T> Entities);
        void Remove(T t);
        void RemoveRange(IEnumerable<T> Entities);
        void Update(T t);
    }
}

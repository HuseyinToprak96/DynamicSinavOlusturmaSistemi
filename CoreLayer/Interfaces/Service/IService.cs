using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Interfaces.Service
{
    public interface IService<T> where T:class
    {
        Task<IEnumerable<T>> getAllAsync();
        Task<T> getByIdAsync(int id);
        Task<T> AddAsync(T t);
        Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> Entities);
        Task Remove(T t);
        Task RemoveRange(IEnumerable<T> Entities);
        Task Update(T t);
    }
}

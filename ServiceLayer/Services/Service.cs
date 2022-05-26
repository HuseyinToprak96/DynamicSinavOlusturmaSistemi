using AutoMapper;
using CoreLayer.Interfaces.Repository;
using CoreLayer.Interfaces.Service;
using CoreLayer.Interfaces.UnitOfWork;
using ServiceLayer.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public class Service<T>:IService<T> where T:class
    {
        protected readonly IMapper _mapper;
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IGenericRepository<T> _genericRepository;

        public Service(IMapper mapper, IGenericRepository<T> genericRepository, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _genericRepository = genericRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<T> AddAsync(T t)
        {
            await _genericRepository.AddAsync(t);
            await _unitOfWork.CommitAsync();
            return t;
        }

        public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> Entities)
        {
            await _genericRepository.AddRangeAsync(Entities);
            await _unitOfWork.CommitAsync();
            return Entities;
        }

        public async Task<IEnumerable<T>> getAllAsync()
        {
            return await _genericRepository.getAllAsync();
        }

        public async Task<T> getByIdAsync(int id)
        {
            var result= await _genericRepository.getByIdAsync(id);
            if (result == null)
                throw new ClientSideException($"{typeof(T).Name} bulunamadı");
                return result;
        }

        public async Task Remove(T t)
        {
            _genericRepository.Remove(t);
            await _unitOfWork.CommitAsync();
        }

        public async Task RemoveRange(IEnumerable<T> Entities)
        {
            _genericRepository.RemoveRange(Entities);
            await _unitOfWork.CommitAsync();
        }

        public async Task Update(T t)
        {
            _genericRepository.Update(t);
            await _unitOfWork.CommitAsync();
        }
    }
}

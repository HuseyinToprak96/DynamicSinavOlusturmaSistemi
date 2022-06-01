using AutoMapper;
using CoreLayer.Dtos;
using CoreLayer.Interfaces.Repository;
using CoreLayer.Interfaces.Service;
using CoreLayer.Interfaces.UnitOfWork;
using CoreLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public class SinavService : Service<Sinav>, ISinavService
    {
        private readonly ISinavRepository _sinavRepository;
        public SinavService(IMapper mapper, IGenericRepository<Sinav> genericRepository, IUnitOfWork unitOfWork, ISinavRepository sinavRepository) : base(mapper, genericRepository, unitOfWork)
        {
            _sinavRepository = sinavRepository;
        }

        public async Task<CustomResponseDto<IEnumerable<Kullanici>>> GirecekListesi(int id)
        {
            return CustomResponseDto<IEnumerable<Kullanici>>.success(200, await _sinavRepository.GirecekListesi(id));
        }
        public async Task<CustomResponseDto<Sinav>> Sinav(int id)
        {
            return CustomResponseDto<Sinav>.success(200, await _sinavRepository.Sinav(id));
        }
    }
}

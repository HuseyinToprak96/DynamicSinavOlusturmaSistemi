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
    public class KullaniciService : Service<Kullanici>,IKullaniciService
    {
        private readonly IKullaniciRepository _kullaniciRepository;
        public KullaniciService(IMapper mapper, IGenericRepository<Kullanici> genericRepository, IUnitOfWork unitOfWork, IKullaniciRepository kullaniciRepository) : base(mapper, genericRepository, unitOfWork)
        {
            _kullaniciRepository = kullaniciRepository;
        }

        public async Task<IEnumerable<string>> allNumber()
        {
            return await _kullaniciRepository.allNumber();
        }

        public async Task<CustomResponseDto<IEnumerable<SinavDto>>> KullanicininSinavlari(int id)
        {
            return CustomResponseDto<IEnumerable<SinavDto>>.success(200, _mapper.Map<List<SinavDto>>(await _kullaniciRepository.KullanicininSinavlari(id)));
        }

        public async Task<CustomResponseDto<IEnumerable<SinavDto>>> OlusturduguSinavlar(int id)
        {
            return CustomResponseDto<IEnumerable<SinavDto>>.success(200,_mapper.Map<List<SinavDto>>(await _kullaniciRepository.OlusturduguSinavlar(id)));
        }

        public async Task<CustomResponseDto<IEnumerable<SinavSonucu>>> SinavSonuclari(int id)
        {
            return CustomResponseDto<IEnumerable<SinavSonucu>>.success(200, await _kullaniciRepository.SinavSonuclari(id));
        }
    }
}

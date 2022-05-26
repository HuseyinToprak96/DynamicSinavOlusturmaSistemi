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
    public class KategoriService : Service<Kategori>, IKategoriService
    {
        private readonly IKategoriRepository _kategoriRepository;
        public KategoriService(IMapper mapper, IGenericRepository<Kategori> genericRepository, IUnitOfWork unitOfWork, IKategoriRepository kategoriRepository) : base(mapper, genericRepository, unitOfWork)
        {
            _kategoriRepository = kategoriRepository;
        }

        public async Task<CustomResponseDto<IEnumerable<Sinav>>> KategorininSinavlari(int id)
        {
            return CustomResponseDto<IEnumerable<Sinav>>.success(200, await _kategoriRepository.KategorininSinavlari(id));
        }
    }
}

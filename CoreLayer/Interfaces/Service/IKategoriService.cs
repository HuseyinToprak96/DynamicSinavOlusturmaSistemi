using CoreLayer.Dtos;
using CoreLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Interfaces.Service
{
    public interface IKategoriService:IService<Kategori>
    {
        Task<CustomResponseDto<IEnumerable<Sinav>>> KategorininSinavlari(int id);

    }
}

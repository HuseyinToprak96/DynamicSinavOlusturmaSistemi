using CoreLayer.Dtos;
using CoreLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Interfaces.Service
{
    public interface ISinavService:IService<Sinav>
    {
        Task<CustomResponseDto<Sinav>> Sinav(int id);
        Task<CustomResponseDto<IEnumerable<Kullanici>>> GirecekListesi(int id);
    }
}

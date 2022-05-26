using CoreLayer.Dtos;
using CoreLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Interfaces.Service
{
    public interface IKullaniciService:IService<Kullanici>
    {
        Task<IEnumerable<string>> allNumber();
        Task<CustomResponseDto<IEnumerable<SinavDto>>> KullanicininSinavlari(int id);
        Task<CustomResponseDto<IEnumerable<SinavDto>>> OlusturduguSinavlar(int id);
        Task<CustomResponseDto<IEnumerable<SinavSonucu>>> SinavSonuclari(int id);
    }
}

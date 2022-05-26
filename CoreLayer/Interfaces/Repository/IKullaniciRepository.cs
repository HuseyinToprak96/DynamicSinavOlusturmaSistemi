using CoreLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Interfaces.Repository
{
    public interface IKullaniciRepository:IGenericRepository<Kullanici>
    {
        Task<IEnumerable<string>> allNumber();
        Task<IEnumerable<Sinav>> KullanicininSinavlari(int id);
        Task<IEnumerable<Sinav>> OlusturduguSinavlar(int id);
        Task<IEnumerable<SinavSonucu>> SinavSonuclari(int id);

    }
}

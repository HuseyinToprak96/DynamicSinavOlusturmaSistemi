using CoreLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Interfaces.Repository
{
    public interface IKategoriRepository:IGenericRepository<Kategori>
    {
        Task<IEnumerable<Sinav>> KategorininSinavlari(int id);
        
    }
}

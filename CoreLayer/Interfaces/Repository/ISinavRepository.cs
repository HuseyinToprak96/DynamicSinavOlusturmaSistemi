using CoreLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Interfaces.Repository
{
    public interface ISinavRepository:IGenericRepository<Sinav>
    {
        Task<Sinav> Sinav(int id);
        Task<IEnumerable<Kullanici>> GirecekListesi(int id);
    }
}

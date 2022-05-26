using CoreLayer.Interfaces.Repository;
using CoreLayer.Models;
using DataLayer.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository
{
    public class SinavRepository : GenericRepository<Sinav>, ISinavRepository
    {
        public SinavRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Kullanici>> GirecekListesi(int id)
        {
            var Kullanicilar = await _context.Sinav_Kullanici.Where(x => x.SinavId == id).Include(x => x.kullanici).Select(x => x.kullanici).ToListAsync();
            return Kullanicilar;
        }

        public async Task<Sinav> Sinav(int id)
        {
          var sinav=  await _context.Sinavlar.Where(x=>x.Id==id).Include(x=>x.SinavKategorileri).ThenInclude(x=>x.Sorular).ThenInclude(x=>x.Cevaplar).SingleOrDefaultAsync();
            return sinav;
        }
    }
}

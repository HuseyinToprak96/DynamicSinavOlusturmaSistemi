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
    public class KullaniciRepository : GenericRepository<Kullanici>, IKullaniciRepository
    {
        public KullaniciRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<string>> allNumber()
        {
            var numaralar = await _context.Kullanicilar.Select(x => new { x.Numara }).ToListAsync();
            return (IEnumerable<string>)numaralar;
        }

        public async Task<IEnumerable<Sinav>> KullanicininSinavlari(int id)
        {
            var kullanicinSinavlari = await _context.Sinav_Kullanici.Include(x => x.sinav).Where(x => x.KullaniciId == id).Select(x=>x.sinav).ToListAsync();

            return kullanicinSinavlari; 
                      
        }

        public async Task<IEnumerable<Sinav>> OlusturduguSinavlar(int id)
        {
            var olusturduguSinavlar = await _context.Kullanicilar.Include(x => x.OlusturduguSinavlar).Where(x => x.Id == id).Select(x => x.OlusturduguSinavlar).SingleOrDefaultAsync();
            return olusturduguSinavlar;
        }

        public async Task<IEnumerable<SinavSonucu>> SinavSonuclari(int id)
        {
            var sinavSonuclari = await _context.Kullanicilar.Where(x => x.Id == id).Include(x => x.KullanicininSinavlari).ThenInclude(x => x.sinavSonucu).Select(x=>x.KullanicininSinavlari.Select(x=>x.sinavSonucu).ToList()).SingleOrDefaultAsync();
            return sinavSonuclari;
        }
    }
}

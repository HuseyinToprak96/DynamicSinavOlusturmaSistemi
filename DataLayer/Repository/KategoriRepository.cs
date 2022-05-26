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
    public class KategoriRepository : GenericRepository<Kategori>, IKategoriRepository
    {
        public KategoriRepository(AppDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Sinav>> KategorininSinavlari(int id)
        {
            var sinavlar = await _context.Kategoriler.Include(x => x.Sinavlar).Where(x => x.Id == id).Select(x => x.Sinavlar).SingleOrDefaultAsync();
            return sinavlar;
        }
    }
}

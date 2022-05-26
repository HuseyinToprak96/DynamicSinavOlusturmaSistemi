using CoreLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Configurations
{
    public class SinavConfiguration : IEntityTypeConfiguration<Sinav>
    {
        public void Configure(EntityTypeBuilder<Sinav> builder)
        {
            builder.HasOne(x => x.kategori).WithMany(x => x.Sinavlar).HasForeignKey(x => x.KategoriId);
            builder.Property(x => x.SinavAdi).HasMaxLength(80).IsRequired();
            builder.Property(x => x.Aciklama).HasMaxLength(300);
            
        
        }
    }
}

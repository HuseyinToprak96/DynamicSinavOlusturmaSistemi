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
    public class KullaniciConfiguration : IEntityTypeConfiguration<Kullanici>
    {
        public void Configure(EntityTypeBuilder<Kullanici> builder)
        {
            builder.Property(x => x.Ad).IsRequired().HasMaxLength(25);
            builder.Property(x => x.Soyad).HasMaxLength(25).IsRequired();
            builder.Property(x => x.Sifre).IsRequired().HasMaxLength(25);
            builder.Property(x => x.KullaniciAdi).HasMaxLength(25).IsRequired();
            builder.Property(x => x.Numara).IsRequired().HasMaxLength(5);
            
        }
    }
}

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
    public class SinavKullaniciConfiguration : IEntityTypeConfiguration<Sinav_Kullanici>
    {
        public void Configure(EntityTypeBuilder<Sinav_Kullanici> builder)
        {
            builder.HasOne(x => x.kullanici).WithMany(x => x.KullanicininSinavlari).HasForeignKey(x => x.KullaniciId);
            builder.HasOne(x => x.sinav).WithMany(x => x.Sinav_Kullanicilari).HasForeignKey(x => x.SinavId);
        }
    }
}

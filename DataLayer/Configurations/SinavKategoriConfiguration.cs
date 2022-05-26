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
   public class SinavKategoriConfiguration:IEntityTypeConfiguration<SinavKategorisi>
    {

        public void Configure(EntityTypeBuilder<SinavKategorisi> builder)
        {
            builder.HasOne(x => x.sinav).WithMany(x => x.SinavKategorileri).HasForeignKey(x => x.SinavId);
            builder.Property(x => x.KategoriAdi).HasMaxLength(30).IsRequired();
        }
    }
}

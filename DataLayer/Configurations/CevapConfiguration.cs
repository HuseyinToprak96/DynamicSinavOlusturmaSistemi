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
    public class CevapConfiguration : IEntityTypeConfiguration<Cevap>
    {
        public void Configure(EntityTypeBuilder<Cevap> builder)
        {
            builder.HasOne(x => x.soru).WithMany(x => x.Cevaplar).HasForeignKey(x => x.SoruId);
            builder.Property(x => x.cevap).IsRequired().HasMaxLength(100);
           
        }
    }
}

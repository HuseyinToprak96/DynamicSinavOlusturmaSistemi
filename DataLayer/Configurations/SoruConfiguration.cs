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
    public class SoruConfiguration : IEntityTypeConfiguration<Soru>
    {
        public void Configure(EntityTypeBuilder<Soru> builder)
        {
            builder.HasOne(x => x.sinavKategorisi).WithMany(x => x.Sorular).HasForeignKey(x => x.KategoriId);
            builder.Property(x => x.soru).IsRequired().HasMaxLength(250);
            
        }
    }
}

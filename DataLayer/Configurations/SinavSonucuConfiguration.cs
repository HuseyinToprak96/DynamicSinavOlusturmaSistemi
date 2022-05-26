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
    public class SinavSonucuConfiguration : IEntityTypeConfiguration<SinavSonucu>
    {
        public void Configure(EntityTypeBuilder<SinavSonucu> builder)
        {
         //   builder.HasOne(x => x.sinav_Kullanici).WithOne(x => x.sinavSonucu).HasForeignKey(;
        }
    }
}

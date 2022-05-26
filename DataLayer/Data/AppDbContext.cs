using CoreLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataLayer.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }
        public DbSet<Kategori> Kategoriler { get; set; }
        public DbSet<Sinav> Sinavlar { get; set; }
        public DbSet<SinavKategorisi> SinavKategorileri { get; set; }
        public DbSet<Soru> Sorular { get; set; }
        public DbSet<Cevap> Cevaplar { get; set; }
        public DbSet<Sinav_Kullanici> Sinav_Kullanici { get; set; }
        public DbSet<SinavSonucu> SinavSonuclari { get; set; }
        public DbSet<Kullanici> Kullanicilar { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var item in ChangeTracker.Entries())
            {
                if (item.Entity is BaseEntity entityReferences)
                {
                    switch (item.State)
                    {
                        case EntityState.Added:
                        {
                                entityReferences.EklenmeTarihi = DateTime.Now;
                                break;
                            }
                        case EntityState.Modified:
                            {
                                entityReferences.GuncellenmeTarihi = DateTime.Now;
                                break;
                            }
                    }
                } }
            return base.SaveChangesAsync(cancellationToken);
        }
        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            foreach (var item in ChangeTracker.Entries())
            {
                if (item.Entity is BaseEntity entityReferences)
                {
                    switch (item.State)
                    {
                        case EntityState.Added:
                            {
                                entityReferences.EklenmeTarihi = DateTime.Now;
                                break;
                            }
                        case EntityState.Modified:
                            {
                                Entry(entityReferences).Property(x => x.EklenmeTarihi).IsModified = false;
                                entityReferences.GuncellenmeTarihi = DateTime.Now;
                                break;
                            }
                    }
                }
            }


            return base.SaveChanges(acceptAllChangesOnSuccess);
        }
    }
}

using KolejDenemeProjesi.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KolejDenemeProjesi.DataAccessLayer.EntityFramework
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Burslar> Burslar { get; set; }
        public DbSet<BursTipleri> BursTipleri { get; set; }
        public DbSet<OgrenimTipleri> OgrenimTipleri { get; set; }
        public DbSet<SinifSeviyeleri> SinifSeviyeleri { get; set; }
        public DbSet<Subeler> Subeler { get; set; }
        public DbSet<DonemGunBilgileri> DonemGunBilgileri { get; set; }
        public DbSet<Donemler> Donemler { get; set; }
        public DbSet<Dersler> Dersler { get; set; }
        public DbSet<DonemTakvimi> DonemTakvimi { get; set; }
        public DbSet<GunTipleri> GunTipleri { get; set; }
        public DbSet<Kullanicilar> Kullanicilar { get; set; }
        public DbSet<KullaniciTipleri> KullaniciTipleri { get; set; }
        public DbSet<Ogrenciler> Ogrenciler { get; set; }
        public DbSet<OgrenciTipDonem> OgrenciTipDonem { get; set; }
        public DbSet<OgrenciVelileri> OgrenciVelileri { get; set; }
        public DbSet<Veliler> Veliler { get; set; }
        public DbSet<VeliYakinlikDereceleri> VeliYakinlikDereceleri { get; set; }


        public DatabaseContext()
        {
            Database.SetInitializer(new MyInitializer());
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}

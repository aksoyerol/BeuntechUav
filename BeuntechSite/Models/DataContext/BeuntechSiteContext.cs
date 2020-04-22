using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BeuntechSite.Models.DataContext
{
    public class BeuntechSiteContext : DbContext

    {
        public BeuntechSiteContext() : base("BeuntechsiteDB")
        {
        }

        public DbSet<Admin> Admin { get; set; }
        public DbSet<Blog> Blog { get; set; }
        public DbSet<Hakkimizda> Hakkimizda { get; set; }
        public DbSet<Iletisim> Iletisim { get; set; }
        public DbSet<Kategori> Kategori { get; set; }
        public DbSet<Projeler> Projeler { get; set; }
        public DbSet<SiteKimlik> SiteKimlik { get; set; }
        public DbSet<Slider> Slider { get; set; }
        public DbSet<Takim> Takim { get; set; }
        public DbSet<Service> Service { get; set; }
    }

}
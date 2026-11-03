using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HurtowniaAPI.Entities
{
    public class HurtowniaDbContext : IdentityDbContext<Użytkownik>
    {
        public DbSet<Zapytanie> Zapytania { get; set;}
        public DbSet<Zamówienie> Zamówienia { get; set;}
        public DbSet<Produkt> Produkty { get; set;}
        public DbSet<Zdjęcie> Zdjęcia { get; set;}
        public DbSet<RodzajPrzesyłki> RodzajePrzesyłki { get; set;}
        public DbSet<RodzajPłatności> RodzajePłatności { get; set;}
        public DbSet<ProduktZamówienie> ProduktyZamówienia { get; set; }

        public HurtowniaDbContext(DbContextOptions<HurtowniaDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ProduktZamówienie>().HasKey(i => new { i.ProduktId, i.ZamówienieId });
        }

    }
}
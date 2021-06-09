using Microsoft.EntityFrameworkCore;
using Economat_v2.Models;


namespace Economat_v2.Data
{
    public class EconomatContext : DbContext
    {
        public EconomatContext(DbContextOptions<EconomatContext> options)
            : base(options)
        {
        }

        public DbSet<Angajat> Angajati { get; set; }

        public DbSet<Companie> Companii { get; set; }
        public DbSet<Detali> Detalii { get; set; }
        public DbSet<Factura> Facturi { get; set; }
        public DbSet<Numar_Factura> Numar_Facturi { get; set; }
        public DbSet<Produs> Produse { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Detali
            modelBuilder.Entity<Detali>()
                .HasOne<Factura>(d => d.Factura)
                .WithMany(f => f.Detalii)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(d => d.FacturaId);

            modelBuilder.Entity<Detali>()
                .HasOne<Produs>(p => p.Produs)
                .WithMany(d => d.Detalii)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(p => p.ProdusId);


            //Companie
            modelBuilder.Entity<Companie>()
                .HasOne<Factura>(c => c.Factura)
                .WithOne(f => f.Companie)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey<Factura>(c => c.CompanieId);

            //Numar_Factura
            modelBuilder.Entity<Numar_Factura>()
                .HasOne<Factura>(f => f.Factura)
                .WithOne(n => n.Numar_Factura)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey<Factura>(f => f.Numar_FacturaId);

            //Factura
            modelBuilder.Entity<Factura>()
                .HasOne<Angajat>(f => f.Angajat)
                .WithMany(a => a.Facturi)
                .HasForeignKey(f => f.AngajatId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.NoAction);



        }
    }
}
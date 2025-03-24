using Microsoft.EntityFrameworkCore;

namespace CIPCommerce.Modeles
{
    public partial class BdContexteCommerce : DbContext
    {
        private string _stringConnexion = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False;Database=BdCIPCommerce;";

        public BdContexteCommerce() { }

        public BdContexteCommerce(string stringConnexion)
        {
            _stringConnexion = stringConnexion;
        }

        public BdContexteCommerce(DbContextOptions<BdContexteCommerce> options) : base(options) {  }

        public virtual DbSet<Utilisateur> TableUtilisateur {  get; set; }
        public virtual DbSet<Facture> TableFacture { get; set; }
        public virtual DbSet<FactureProduits> TableFactureProduits { get; set; }
        public virtual DbSet<Panier> TablePanier { get; set; }
        public virtual DbSet<Produit> TableProduit { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer(_stringConnexion);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Utilisateur -> Produit (One-to-Many)
            modelBuilder.Entity<Produit>()
                .HasOne(p => p.Vendeur)
                .WithMany(u => u.Produits)
                .HasForeignKey(p => p.IdVendeur)
                .OnDelete(DeleteBehavior.Restrict);


            // Facture -> FactureProduits (One-to-Many)
            modelBuilder.Entity<FactureProduits>()
                .HasOne(fp => fp.LaFacture)
                .WithMany(f => f.ListeProduits)
                .HasForeignKey(fp => fp.IdFacture)
                .OnDelete(DeleteBehavior.Restrict);

            // Produit -> FactureProduits (One-to-Many)
            modelBuilder.Entity<FactureProduits>()
                .HasOne(fp => fp.LeProduit)
                .WithMany(p => p.FactureProduits)
                .HasForeignKey(fp => fp.IdProduit)
                .OnDelete(DeleteBehavior.Restrict);

            // Utilisateur -> Facture (One-to-Many)
            modelBuilder.Entity<Facture>()
                .HasOne(f => f.Acheteur)
                .WithMany(u => u.Factures)
                .HasForeignKey(f => f.IdAcheteur)
                .OnDelete(DeleteBehavior.Restrict);

            // Utilisateur -> Panier (One-to-Many)
            modelBuilder.Entity<Panier>()
                .HasOne(p => p.Acheteur)
                .WithMany(u => u.Paniers)
                .HasForeignKey(p => p.IdAcheteur)
                .OnDelete(DeleteBehavior.Cascade);

            // Produit -> Panier (One-to-Many)
            modelBuilder.Entity<Panier>()
                .HasOne(p => p.LeProduit)
                .WithMany(pr => pr.Paniers)
                .HasForeignKey(p => p.IdProduit)
                .OnDelete(DeleteBehavior.Cascade);

        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

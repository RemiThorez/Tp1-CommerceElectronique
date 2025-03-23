using Microsoft.EntityFrameworkCore;

namespace CIPCommerce.Modeles
{
    public partial class BdContexteCommerce : DbContext
    {
        private string _stringConnexion = "";

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
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

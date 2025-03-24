using System.ComponentModel.DataAnnotations;

namespace CIPCommerce.Modeles
{
    public partial class Utilisateur
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public string Nom {  get; set; }
        [Required]
        public string Identifiant {  get; set; }
        [Required]
        public string Mdp { get; set; }
        [Required]
        public bool Role { get; set; }

        public bool Actif { get; set; } = true;

        public ICollection<Panier> Paniers { get; set; } = new List<Panier>();

        public ICollection<Produit> Produits { get; set; } = new List<Produit>();

        public ICollection<Facture> Factures { get; set; } = new List<Facture>();
    }
}

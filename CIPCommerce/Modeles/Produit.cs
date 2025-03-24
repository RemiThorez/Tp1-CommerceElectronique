using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CIPCommerce.Modeles
{
    public partial class Produit
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Titre { get; set; }

        public string Description { get; set; }
        [Required]
        public double Prix { get; set; }

        public string Categorie {  get; set; }

        public string Image {  get; set; }
        [Required]
        public int IdVendeur {  get; set; }

        [ForeignKey("IdVendeur")]
        public Utilisateur? Vendeur { get; set; }

        public ICollection<Panier> Paniers { get; set; } = new List<Panier>();

        public ICollection<FactureProduits> FactureProduits { get; set; } = new List<FactureProduits>();
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CIPCommerce.Modeles
{
    public partial class Produit
    {
        [Key]
        public int Id { get; set; }

        public string Titre { get; set; }

        public string Description { get; set; }

        public double Prix { get; set; }

        public string Categorie {  get; set; }

        public string Image {  get; set; }
        
        public int IdVendeur {  get; set; }

        [ForeignKey("IdVendeur")]
        public Utilisateur Vendeur { get; set; }
    }
}

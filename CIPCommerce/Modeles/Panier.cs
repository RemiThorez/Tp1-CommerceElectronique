using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CIPCommerce.Modeles
{
    public partial class Panier
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public int IdAcheteur {  get; set; }
        [Required]
        public int IdProduit { get; set; }
        [Required]
        public int Qte {  get; set; }

        [ForeignKey("IdAcheteur")]
        public Utilisateur Acheteur { get; set; }

        [ForeignKey("IdProduit")]
        public Produit LeProduit { get; set; }
    }
}

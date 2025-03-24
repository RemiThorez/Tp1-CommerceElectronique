using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CIPCommerce.Modeles
{
    public partial class FactureProduits
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public int IdFacture {  get; set; }
        [Required]
        public int IdProduit { get; set; }
        [Required]
        public int Qte {  get; set; }

        [ForeignKey("IdFacture")]
        public Facture? LaFacture { get; set; }

        [ForeignKey("IdProduit")]
        public Produit? LeProduit { get; set; }
    }
}

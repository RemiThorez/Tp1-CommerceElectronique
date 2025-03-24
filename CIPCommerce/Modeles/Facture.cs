using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CIPCommerce.Modeles
{
    public partial class Facture
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public int IdAcheteur {  get; set; }
        [Required]
        public DateTime DateAchat {  get; set; }

        [ForeignKey("IdAcheteur")]
        public Utilisateur Acheteur { get; set; }

        public ICollection<FactureProduits> ListeProduits { get; set; } = new List<FactureProduits>();
    }
}

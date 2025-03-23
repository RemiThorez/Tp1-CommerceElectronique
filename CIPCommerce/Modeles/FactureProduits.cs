using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CIPCommerce.Modeles
{
    public partial class FactureProduits
    {
        [Key]
        public int Id { get; set; }

        public int IdFacture {  get; set; }

        public int IdProduit { get; set; }

        public int Qte {  get; set; }

        [ForeignKey("IdFacture")]
        public Facture LaFacture { get; set; }

        [ForeignKey("IdProduit")]
        public Produit LeProduit { get; set; }
    }
}

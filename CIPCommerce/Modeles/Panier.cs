using System.ComponentModel.DataAnnotations.Schema;

namespace CIPCommerce.Modeles
{
    public partial class Panier
    {
        public int Id { get; set; }

        public int IdAcheteur {  get; set; }

        public int IdProduit { get; set; }

        public int Qte {  get; set; }

        [ForeignKey("IdAcheteur")]
        public Utilisateur Acheteur { get; set; }

        [ForeignKey("IdProduit")]
        public Produit LeProduit { get; set; }
    }
}

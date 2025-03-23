using System.ComponentModel.DataAnnotations.Schema;

namespace CIPCommerce.Modeles
{
    public partial class Facture
    {
        public int Id { get; set; }

        public int IdAcheteur {  get; set; }

        public DateTime DateAchat {  get; set; }

        [ForeignKey("IdAcheteur")]
        public Utilisateur Acheteur { get; set; }
    }
}

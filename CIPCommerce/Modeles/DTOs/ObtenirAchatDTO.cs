namespace CIPCommerce.Modeles.DTOs
{
    public class ObtenirAchatDTO
    {
        public ObtenirAchatDTO() { }

        public double MontantTotal { get; set; }

        public List<Produit> LesProduits { get; set; }
    }
}

namespace CIPCommerce.Modeles.DTOs
{
    public class ProduitAchatDTO
    {
        public ProduitAchatDTO() { }

        public int Id { get; set; }

        public string Titre { get; set; }

        public double Prix { get; set; }

        public string Categorie { get; set; }

        public int IdVendeur { get; set; }
    }
}

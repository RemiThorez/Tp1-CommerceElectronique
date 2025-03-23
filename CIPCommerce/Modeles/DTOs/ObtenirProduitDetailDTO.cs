namespace CIPCommerce.Modeles.DTOs
{
    public class ObtenirProduitDetailDTO
    {
        public ObtenirProduitDetailDTO() { }

        public int Id { get; set; }

        public string Titre { get; set; }

        public string Description { get; set; }

        public double Prix { get; set; }

        public string Categorie { get; set; }

        public string Image { get; set; }

        public int IdVendeur { get; set; }

    }
}

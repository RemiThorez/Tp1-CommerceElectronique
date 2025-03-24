namespace CIPCommerce.Modeles.DTOs
{
    public class ObtenirProduitDTO
    {
        public ObtenirProduitDTO() { }

        public ObtenirProduitDTO(Produit produit)
        {
            IdProduit = produit.Id;
            Titre = produit.Titre;
            Prix = produit.Prix;
            Categorie = produit.Categorie;
            Image = produit.Image;
            IdVendeur = produit.IdVendeur;
            NomVendeur = produit.Vendeur.Nom;
            EnVente = produit.EnVente;
        }

        public int IdProduit { get; set; }

        public string Titre { get; set; }

        public double Prix { get; set; }

        public string Categorie { get; set; }

        public string Image { get; set; }

        public int IdVendeur { get; set; }

        public string NomVendeur { get; set; }

        public bool EnVente { get; set; }
    }
}

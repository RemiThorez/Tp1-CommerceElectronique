namespace CIPCommerce.Modeles.DTOs
{
    public class CreerProduitDTO
    {
        public CreerProduitDTO() { }

        public Produit RetournerProduit(BdContexteCommerce bd)
        {
            Produit produit = new Produit();

            produit.Titre = Titre;
            produit.Description = Description;
            produit.Prix = Prix;
            produit.Categorie = Categorie;
            produit.Image = Image;
            produit.IdVendeur = IdVendeur;
            produit.EnVente = EnVente;

            return produit;
        }

        public string Titre { get; set; }

        public string Description { get; set; }

        public double Prix { get; set; }

        public string Categorie { get; set; }

        public string Image { get; set; }

        public int IdVendeur { get; set; }

        public bool EnVente { get; set; }
    }
}

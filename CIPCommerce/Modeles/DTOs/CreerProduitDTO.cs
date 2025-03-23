namespace CIPCommerce.Modeles.DTOs
{
    public class CreerProduitDTO
    {
        public CreerProduitDTO() { }

        public Produit RetournerProduit()
        {
            Produit produit = new Produit();

            BdContexteCommerce _bd = new BdContexteCommerce();

            produit.Titre = Titre;
            produit.Description = Description;
            produit.Prix = Prix;
            produit.Categorie = Categorie;
            produit.Image = Image;
            produit.IdVendeur = IdVendeur;
            produit.Vendeur = _bd.TableUtilisateur.Find(IdVendeur);

            return produit;
        }

        public string Titre { get; set; }

        public string Description { get; set; }

        public double Prix { get; set; }

        public string Categorie { get; set; }

        public string Image { get; set; }

        public int IdVendeur { get; set; }
    }
}

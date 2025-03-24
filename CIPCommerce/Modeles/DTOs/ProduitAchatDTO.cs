namespace CIPCommerce.Modeles.DTOs
{
    public class ProduitAchatDTO
    {
        public ProduitAchatDTO() { }

        public ProduitAchatDTO(Produit produit, int qte, DateTime dateAchat) 
        {
            Id = produit.Id;
            Titre = produit.Titre;
            Prix = produit.Prix;
            DateAchat = dateAchat;
            Qte = qte;
            NomVendeur = produit.Vendeur.Nom;
            IdVendeur = produit.IdVendeur;
        }

        public int Id { get; set; }

        public string Titre { get; set; }

        public double Prix { get; set; }

        public DateTime DateAchat { get; set; }
        public int Qte { get; set; }

        public double PrixUnitaire { get; set; }

        public string NomVendeur { get; set; }

        public int IdVendeur { get; set; }
    }
}

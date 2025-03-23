namespace CIPCommerce.Modeles.DTOs
{
    public class ProduitVenteDTO
    {
        public ProduitVenteDTO() { }

        public ProduitVenteDTO(Produit produit, int qte, DateTime dateAchat, int idAcheteur, string nomAcheteur)
        {
            Id = produit.Id;
            Titre = produit.Titre;
            Prix = produit.Prix;
            DateAchat = dateAchat;
            Qte = qte;
            NomAcheteur = nomAcheteur;
            IdAcheteur = idAcheteur;
        }

        public int Id { get; set; }

        public string Titre { get; set; }

        public double Prix { get; set; }

        public DateTime DateAchat { get; set; }
        public int Qte { get; set; }

        public double PrixUnitaire { get; set; }

        public string NomAcheteur { get; set; }

        public int IdAcheteur { get; set; }
    }
}

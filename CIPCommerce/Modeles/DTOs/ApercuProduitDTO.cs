namespace CIPCommerce.Modeles.DTOs
{
    public class ApercuProduitDTO
    {
        public ApercuProduitDTO() { }

        public ApercuProduitDTO(int id, int qte, BdContexteCommerce bd)
        {
            IdProduit = id;
            Qte = qte;

            Produit p = bd.TableProduit.Find(id);

            Titre = p.Titre;
            Prix = p.Prix;
            EnVente = p.EnVente;
        }

        public int IdProduit { get; set; }

        public string Titre {  get; set; }

        public double Prix { get; set; }

        public int Qte { get; set; }

        public bool EnVente { get; set; }
    }
}

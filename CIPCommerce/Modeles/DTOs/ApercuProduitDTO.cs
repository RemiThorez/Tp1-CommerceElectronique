namespace CIPCommerce.Modeles.DTOs
{
    public class ApercuProduitDTO
    {
        public ApercuProduitDTO() { }

        public ApercuProduitDTO(int id, int qte)
        {
            IdProduit = id;
            Qte = qte;

            BdContexteCommerce _bd = new BdContexteCommerce();

            Produit p = _bd.TableProduit.Find(id);

            Titre = p.Titre;
            Prix = p.Prix;
        }

        public int IdProduit { get; set; }

        public string Titre {  get; set; }

        public double Prix { get; set; }

        public int Qte { get; set; }
    }
}

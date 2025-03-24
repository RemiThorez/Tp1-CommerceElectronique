namespace CIPCommerce.Modeles.DTOs
{
    public class ObtenirPanierDTO
    {
        public ObtenirPanierDTO() { }

        public ObtenirPanierDTO(int idUsager, BdContexteCommerce bd)
        {
            LesProduits = new List<ApercuProduitDTO>();
            Total = 0;

            List<Panier> contenuPanierUsager = bd.TablePanier.Where(p => p.IdAcheteur == idUsager).ToList();

            foreach (Panier p in contenuPanierUsager)
            {
                LesProduits.Add(new ApercuProduitDTO(p.IdProduit, p.Qte, bd));
                Total += p.LeProduit.Prix * p.Qte;
            }
        }
        
        public List<ApercuProduitDTO> LesProduits { get; set; }
        public double Total { get; set; }
    }
}

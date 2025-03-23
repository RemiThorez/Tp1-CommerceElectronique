namespace CIPCommerce.Modeles.DTOs
{
    public class ObtenirAchatDTO
    {
        public ObtenirAchatDTO() { }

        public ObtenirAchatDTO(List<Facture> facturesUtilisateurs) 
        {
            LesProduits = new List<ProduitAchatDTO>();
            MontantTotal = 0;

            BdContexteCommerce _bd = new BdContexteCommerce();
            foreach (Facture f in facturesUtilisateurs)
            {
                List<FactureProduits> factureProduits = _bd.TableFactureProduits.Where(fp => fp.IdFacture == f.Id).ToList();

                foreach (FactureProduits fp in factureProduits)
                {
                    Produit produit = _bd.TableProduit.Find(fp.IdProduit);
                    LesProduits.Add(new ProduitAchatDTO(produit, fp.Qte, f.DateAchat));
                    MontantTotal += produit.Prix * fp.Qte;
                }
            }
        }

        public double MontantTotal { get; set; }

        public List<ProduitAchatDTO> LesProduits { get; set; }
    }
}

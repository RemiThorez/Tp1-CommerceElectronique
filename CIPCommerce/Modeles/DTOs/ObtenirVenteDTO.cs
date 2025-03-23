namespace CIPCommerce.Modeles.DTOs
{
    public class ObtenirVenteDTO
    {
        public ObtenirVenteDTO() { }

        public ObtenirVenteDTO(int idVendeur)
        {
            LesProduits.Clear();
            MontantTotal = 0;

            BdContexteCommerce _bd = new BdContexteCommerce();

            List<FactureProduits> factureProduits = _bd.FactureProduits.Where(fp => _bd.Produit.Where(p => p.IdVendeur == idVendeur).Select(p => p.Id).Contains(fp.IdProduit)).ToList();

            foreach (FactureProduits fp in factureProduits)
            {
                Produit produit = _bd.TableProduit.Find(fp.IdProduit);
                LesProduits.Add(new ProduitVenteDTO(produit, fp.Qte, fp.LaFacture.DateAchat, fp.LaFacture.IdAcheteur, _bd.TableUtilisateur.Find(fp.LaFacture.IdAcheteur).Select(u => u.Nom));
                MontantTotal += produit.Prix * fp.Qte;
            }
        }

        public double MontantTotal { get; set; }

        public List<ProduitVenteDTO> LesProduits { get; set; }
    }
}
}

namespace CIPCommerce.Modeles.DTOs
{
    public class ObtenirVenteDTO
    {
        public ObtenirVenteDTO() { }

        public ObtenirVenteDTO(int idVendeur, BdContexteCommerce bd)
        {
            LesProduits = new List<ProduitVenteDTO>();
            MontantTotal = 0;

            List<FactureProduits> factureProduits = bd.TableFactureProduits.Where(fp => bd.TableProduit.Where(p => p.IdVendeur == idVendeur).Select(p => p.Id).Contains(fp.IdProduit)).ToList();

            foreach (FactureProduits fp in factureProduits)
            {
                Produit produit = bd.TableProduit.Find(fp.IdProduit);
                LesProduits.Add(new ProduitVenteDTO(produit, fp.Qte, fp.LaFacture.DateAchat, fp.LaFacture.IdAcheteur, bd.TableUtilisateur.Find(fp.LaFacture.IdAcheteur).Nom));
                MontantTotal += produit.Prix * fp.Qte;
            }
        }

        public double MontantTotal { get; set; }

        public List<ProduitVenteDTO> LesProduits { get; set; }
    }
}


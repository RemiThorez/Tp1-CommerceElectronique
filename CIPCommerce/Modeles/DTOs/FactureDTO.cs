namespace CIPCommerce.Modeles.DTOs
{
    public class FactureDTO
    {
        public FactureDTO() { }

        public FactureDTO(int id) 
        {
            ApercusProduits = new List<ApercuProduitDTO>();
            BdContexteCommerce _bd = new BdContexteCommerce();
            IdFacture = id;
            DateAchat = _bd.TableFacture.Find(id).DateAchat;

            List<FactureProduits> factureProduits = _bd.TableFactureProduits.Where(fp => fp.IdFacture == id).ToList();

            foreach (FactureProduits fp in factureProduits)
            {
                ApercusProduits.Add(new ApercuProduitDTO(fp.IdProduit, fp.Qte));
            }
        }

        public int IdFacture { get; set; }

        public DateTime DateAchat { get; set; }

        public List<ApercuProduitDTO> ApercusProduits { get; set; }
    }
}

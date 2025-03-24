namespace CIPCommerce.Modeles.DTOs
{
    public class FactureDTO
    {
        public FactureDTO() { }

        public FactureDTO(int id, BdContexteCommerce bd) 
        {
            ApercusProduits = new List<ApercuProduitDTO>();
            IdFacture = id;
            DateAchat = bd.TableFacture.Find(id).DateAchat;

            List<FactureProduits> factureProduits = bd.TableFactureProduits.Where(fp => fp.IdFacture == id).ToList();

            foreach (FactureProduits fp in factureProduits)
            {
                ApercusProduits.Add(new ApercuProduitDTO(fp.IdProduit, fp.Qte,bd));
            }
        }

        public int IdFacture { get; set; }

        public DateTime DateAchat { get; set; }

        public List<ApercuProduitDTO> ApercusProduits { get; set; }
    }
}

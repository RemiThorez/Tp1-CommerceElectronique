namespace CIPCommerce.Modeles.DTOs
{
    public class ObtenirFactureDTO
    {
        public ObtenirFactureDTO() { }

        public ObtenirFactureDTO(int idAcheteur, BdContexteCommerce bd)
        {
            Factures = new List<FactureDTO>();

            List<int> idsFactures = bd.TableFacture.Where(f => f.IdAcheteur == idAcheteur).Select(f => f.Id).ToList();

            foreach (int id in idsFactures)
            {
                Factures.Add(new FactureDTO(id,bd));
            }
        }

        public List<FactureDTO> Factures { get; set; }
    }
}

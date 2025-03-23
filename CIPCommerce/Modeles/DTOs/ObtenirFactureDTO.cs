namespace CIPCommerce.Modeles.DTOs
{
    public class ObtenirFactureDTO
    {
        public ObtenirFactureDTO() { }

        public ObtenirFactureDTO(int idAcheteur)
        {
            Factures = new List<FactureDTO>();
            BdContexteCommerce _bd = new BdContexteCommerce();

            List<int> idsFactures = _bd.TableFacture.Where(f => f.IdAcheteur == idAcheteur).Select(f => f.Id).ToList();

            foreach (int id in idsFactures)
            {
                Factures.Add(new FactureDTO(id));
            }
        }

        public List<FactureDTO> Factures { get; set; }
    }
}

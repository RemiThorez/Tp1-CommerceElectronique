namespace CIPCommerce.Modeles.DTOs
{
    public class ObtenirUsagerDTO
    {
        public ObtenirUsagerDTO() { }

        public ObtenirUsagerDTO(Utilisateur utilisateur)
        {
            IdUtilisateur = utilisateur.Id;
            Nom = utilisateur.Nom;
        }

        public int IdUtilisateur {  get; set; }

        public string Nom { get; set; }
    }
}

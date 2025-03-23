namespace CIPCommerce.Modeles.DTOs
{
    public class CreationUsagerDTO
    {
        public CreationUsagerDTO() { }

        public Utilisateur RetoutrnerUtilisateur()
        {
            Utilisateur utilisateur = new Utilisateur();

            utilisateur.Nom = Nom;
            utilisateur.Identifiant = Identifiant;
            utilisateur.Mdp = Mdp;
            utilisateur.Role = Role;

            return utilisateur;
        }
        public string Nom { get; set; }

        public string Identifiant { get; set; }

        public string Mdp { get; set; }

        public bool Role { get; set; }
    }
}

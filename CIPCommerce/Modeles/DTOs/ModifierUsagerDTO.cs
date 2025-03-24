namespace CIPCommerce.Modeles.DTOs
{
    public class ModifierUsagerDTO
    {
        public ModifierUsagerDTO() { }

        public void AppliquerModification(int id, BdContexteCommerce bd)
        {
            Utilisateur utilisateur = bd.TableUtilisateur.Find(id);

            utilisateur.Nom = Nom ?? utilisateur.Nom;
            utilisateur.Mdp = Mdp ?? utilisateur.Mdp;
            utilisateur.Role = Role ?? utilisateur.Role;

            bd.SaveChanges();
        }
        public string Nom { get; set; }

        public string Mdp { get; set; }

        public bool? Role { get; set; }
    }
}

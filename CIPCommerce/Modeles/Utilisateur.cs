using System.ComponentModel.DataAnnotations;

namespace CIPCommerce.Modeles
{
    public partial class Utilisateur
    {
        [Key]
        public int Id { get; set; }

        public string Nom {  get; set; }

        public string Identifiant {  get; set; }

        public string Mdp { get; set; }

        public bool Role { get; set; }
    }
}

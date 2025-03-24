using CIPCommerce.JWT;
using CIPCommerce.Modeles;
using CIPCommerce.Modeles.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Security.Cryptography;
using System.Text;

namespace CIPCommerce.Controleurs
{
    [Produces("application/json")]
    [Route("api/utilisateur/")]
    [ApiController]
    public class UtilisateurController : ControllerBase
    {
        private readonly BdContexteCommerce _bd;
        private readonly Authentification _auth;

        public UtilisateurController(BdContexteCommerce bd, IOptions<ConfigApp> config)
        {
            _bd = bd;
            _auth = new Authentification(bd, config.Value);
        }

        [HttpPost("connexion")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ConnexionReussiDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BadRequestResult))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(UnauthorizedResult))]
        public IActionResult Connexion([FromBody] ConnexionUsagerDTO infoConnexion)
        {
            if(infoConnexion != null && infoConnexion.Identifiant != null && infoConnexion.Mdp != null)
            {
                Utilisateur? utilisateur = _bd.TableUtilisateur.Where(u => u.Identifiant ==  infoConnexion.Identifiant).First();

                if(utilisateur != null)
                {
                    if (utilisateur.Mdp == infoConnexion.Mdp)
                    {
                        return Ok(new ConnexionReussiDTO(utilisateur.Id, _auth.GenerationJetonJWT(utilisateur)));
                    }
                }
                return Unauthorized();
            }
            return BadRequest();
        }

        [HttpPost]
        public IActionResult CreerUtilisateur()
        {

        }

        [HttpPatch]
        public IActionResult ModifierUtilisateur()
        {

        }

        [HttpGet]
        public IActionResult ObtenirVendeurs()
        {

        }

        [HttpGet]
        public IActionResult ObtenirUtilisateur()
        {

        }

        [HttpDelete]
        public IActionResult DesactiverUtilisateur()
        {

        }

        /// <summary>
        /// La méthode <c>HacheurProffessionel</c> sert à haché le mot de passe, 
        /// c'est ça seul fonction, il ne rajoute pas de sel. Le code vient d'un des labs de piratage que j'ai fait.
        /// </summary>
        /// <param name="mdpNonHacher">Le mot de passe à hacher</param>
        /// <returns>Retourne la string du mot de passe étant maintenant hacher.</returns>
        static private string HacheurProfessionel(string mdpNonHacher)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hachisParmentier = sha256.ComputeHash(Encoding.UTF8.GetBytes(mdpNonHacher));

                StringBuilder reconstructeurDeHachisParmentier = new StringBuilder();
                foreach (byte b in hachisParmentier)
                {
                    reconstructeurDeHachisParmentier.Append(b.ToString("x2"));
                }

                return reconstructeurDeHachisParmentier.ToString();
            }
        }
    }
}

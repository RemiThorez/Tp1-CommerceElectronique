using CIPCommerce.JWT;
using CIPCommerce.Modeles;
using CIPCommerce.Modeles.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.Extensions.Options;
using System.Data;
using System.Runtime.Intrinsics.Arm;
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
                Utilisateur? utilisateur = _bd.TableUtilisateur.Where(u => u.Identifiant == infoConnexion.Identifiant && u.Actif).First();

                infoConnexion.Mdp = HacheurProfessionel(infoConnexion.Mdp);

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

        [HttpPost("creer")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CreatedResult))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BadRequestResult))]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(ConflictResult))]
        public IActionResult CreerUtilisateur([FromBody] CreationUsagerDTO nouveauUtilisateur)
        {
            if (nouveauUtilisateur.Identifiant == null || nouveauUtilisateur.Mdp == null || nouveauUtilisateur.Role == null)
                return BadRequest();

            nouveauUtilisateur.Mdp = HacheurProfessionel(nouveauUtilisateur.Mdp);


            if (_bd.TableUtilisateur.Where(u => u.Identifiant == nouveauUtilisateur.Identifiant).Any())
            {
                return Conflict();
            }

            Utilisateur? utilisateur = nouveauUtilisateur.RetoutrnerUtilisateur();
         
            _bd.TableUtilisateur.Add(utilisateur);
            _bd.SaveChanges();

            return Created();
        }

        [HttpPatch("modifier")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ConnexionReussiDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BadRequestResult))]
        public IActionResult ModifierUtilisateur([FromBody] ModifierUsagerDTO utilisateurModifier)
        {
            utilisateurModifier.Mdp = HacheurProfessionel(utilisateurModifier.Mdp);

            Utilisateur? utilisateurAuth = ControllerContext.HttpContext.Items["Utilisateur"] as Utilisateur;

            if (utilisateurAuth == null)
            {
                return BadRequest();
            }

            utilisateurModifier.AppliquerModification(utilisateurAuth.Id, _bd);

            return Ok();
        }

        [HttpGet("vendeur")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ObtenirUsagerDTO>))]
        public IActionResult ObtenirVendeurs()
        {
            List<ObtenirUsagerDTO> usagerDTOs = new List<ObtenirUsagerDTO>();

            _bd.TableUtilisateur.Where(u => u.Role == true).ToList().ForEach(u => usagerDTOs.Add(new ObtenirUsagerDTO(u)));

            return Ok(usagerDTOs);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ObtenirUsagerDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(NotFoundResult))]
        public IActionResult ObtenirUtilisateur(int id)
        {
            Utilisateur? utilisateur = _bd.TableUtilisateur.Find(id);
            if(utilisateur == null)
                return NotFound();
            return Ok(new ObtenirUsagerDTO(utilisateur));
        }

        [HttpDelete("desactiver")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OkResult))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BadRequestResult))]
        public IActionResult DesactiverUtilisateur()
        {
            Utilisateur? utilisateurAuth = ControllerContext.HttpContext.Items["Utilisateur"] as Utilisateur;

            if (utilisateurAuth == null)
            {
                return BadRequest();
            }

            Utilisateur utilisateur = _bd.TableUtilisateur.Find(utilisateurAuth.Id);
            utilisateur.Actif = false;

            List<Produit> produits = _bd.TableProduit.Where(p => p.IdVendeur == utilisateurAuth.Id).ToList();
            produits.ForEach(p => p.EnVente = false);

            _bd.SaveChanges();

            ControllerContext.HttpContext.Items["Utilisateur"] = null;

            return Ok();
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

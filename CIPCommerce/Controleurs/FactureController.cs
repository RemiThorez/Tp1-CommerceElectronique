using CIPCommerce.Modeles;
using CIPCommerce.Modeles.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CIPCommerce.Controleurs
{
    [Produces("application/json")]
    [Route("api/facture/")]
    [ApiController]
    public class FactureController : ControllerBase
    {
        private readonly BdContexteCommerce _bd;

        public FactureController(BdContexteCommerce bd)
        {
            _bd = bd;
        }

        [HttpGet("factures")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BadRequestResult))]
        [ProducesResponseType(StatusCodes.Status200OK, Type =typeof(ObtenirFactureDTO))]
        public IActionResult ObtenirFactures()
        {
            Utilisateur utilisateurAuth = ControllerContext.HttpContext.Items["Utilisateur"] as Utilisateur;

            if (utilisateurAuth == null)
            {
                return BadRequest();
            }
            return Ok(new ObtenirFactureDTO(utilisateurAuth.Id, _bd));
        }

        [HttpGet("achats")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BadRequestResult))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ObtenirAchatDTO))]
        public IActionResult ObtenirAchats()
        {
            Utilisateur utilisateurAuth = ControllerContext.HttpContext.Items["Utilisateur"] as Utilisateur;

            if (utilisateurAuth == null)
            {
                return BadRequest();
            }
            return Ok(new ObtenirAchatDTO(_bd.TableFacture.Where(f => f.IdAcheteur == utilisateurAuth.Id).ToList(), _bd));
        }

        [HttpGet("ventes")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type =typeof(BadRequestResult))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ObtenirVenteDTO))]
        public IActionResult ObtenirVentes()
        {
            Utilisateur utilisateurAuth = ControllerContext.HttpContext.Items["Utilisateur"] as Utilisateur;

            if (utilisateurAuth == null)
            {
                return BadRequest();
            }
            return Ok(new ObtenirVenteDTO(utilisateurAuth.Id, _bd));
        }
    }
}

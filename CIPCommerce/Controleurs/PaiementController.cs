using CIPCommerce.Modeles;
using CIPCommerce.Modeles.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Stripe;

namespace CIPCommerce.Controleurs
{
    [Produces("application/json")]
    [Route("api/paiement/")]
    [ApiController]
    public class PaiementController : ControllerBase
    {
        private readonly StripeConfig _stripe;
        private readonly BdContexteCommerce _bd;
        
        public PaiementController(BdContexteCommerce bd, IOptions<StripeConfig> stripe)
        {
            _bd = bd;
            _stripe = stripe.Value;
        }

        [HttpGet("cle")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(UnauthorizedResult))]
        public IActionResult ObtenirClePublique()
        {
            Utilisateur? utilisateurAuth = ControllerContext.HttpContext.Items["Utilisateur"] as Utilisateur;

            if (utilisateurAuth == null)
                return Unauthorized();
            return Ok(_stripe.PublishableKey);
        }

        [HttpPost("payer")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OkResult))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(UnauthorizedResult))]
        public IActionResult EffectuerPaiment([FromBody] ChargeCreateOptions optionPaiment)
        {
            Utilisateur? utilisateurAuth = ControllerContext.HttpContext.Items["Utilisateur"] as Utilisateur;

            if (utilisateurAuth == null)
                return Unauthorized();

            long total = (long)(_bd.TablePanier.Where(p => p.IdAcheteur == utilisateurAuth.Id).Sum(p => p.Qte * p.LeProduit.Prix) * 100);

            if (total != optionPaiment.Amount)
                return BadRequest("Tentative de changement du montant");

            ChargeService servicePaiement = new ChargeService();
            Charge paiement = servicePaiement.Create(optionPaiment);

            if (paiement.Status == "succeeded")
            {
                Facture nouvelleFacture = new Facture { IdAcheteur = utilisateurAuth.Id, DateAchat = DateTime.Now };

                List<Panier> lePanier = _bd.TablePanier.Where(p => p.IdAcheteur == utilisateurAuth.Id).ToList();
                List<FactureProduits> lesProduitsFacturer = lePanier.Select(p => new FactureProduits { IdFacture = nouvelleFacture.Id, IdProduit = p.IdProduit, Qte = p.Qte }).ToList();


                _bd.TableFacture.Add(nouvelleFacture);
                _bd.SaveChanges();

                _bd.TableFactureProduits.AddRange(lesProduitsFacturer);
                _bd.TablePanier.RemoveRange(lePanier);
                _bd.SaveChanges();
                
                return Ok();
            }
            return BadRequest(paiement.FailureMessage);
        }
    }
}

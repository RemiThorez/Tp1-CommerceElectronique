﻿using CIPCommerce.Modeles;
using CIPCommerce.Modeles.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CIPCommerce.Controleurs
{
    [Produces("application/json")]
    [Route("api/produit")]
    [ApiController]
    public class ProduitController : ControllerBase
    {
        private BdContexteCommerce _bd;

        public ProduitController()
        {
            _bd = new BdContexteCommerce();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ObtenirProduitDTO>))]
        public IActionResult ObtenirProduits()
        {
            List<ObtenirProduitDTO> produitsDTOs = new List<ObtenirProduitDTO>();

            _bd.TableProduit.ToList().ForEach(p => produitsDTOs.Add(new ObtenirProduitDTO(p)));

            return Ok(produitsDTOs);
        }

        [HttpGet("/{categorie}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ObtenirProduitDTO>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BadRequestResult))]
        public IActionResult ObtenirProduitsCategorie(string categorie)
        {
            if (categorie == null || categorie == "" || categorie == " ")
            {
                return BadRequest();
            }

            List<ObtenirProduitDTO> produitsDTOs = new List<ObtenirProduitDTO>();

            _bd.TableProduit.Where(p => p.Categorie == categorie).ToList().ForEach(p => produitsDTOs.Add(new ObtenirProduitDTO(p)));

            return Ok(produitsDTOs);
        }

        [HttpGet("/{idVendeur}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ObtenirProduitDTO>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BadRequestResult))]
        public IActionResult ObtenirProduitsVendeur(int idVendeur)
        {
            if(idVendeur < 0)
            {
                return BadRequest();
            }

            List<ObtenirProduitDTO> produitsDTOs = new List<ObtenirProduitDTO>();

            _bd.TableProduit.Where(p => p.IdVendeur == idVendeur).ToList().ForEach(p => produitsDTOs.Add(new ObtenirProduitDTO(p)));

            return Ok(produitsDTOs);
        }

        [HttpGet("detail/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ObtenirProduitDetailDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BadRequestResult))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(NotFoundResult))]
        public IActionResult ObtenirProduitDetaille(int id)
        {
            if (id < 0)
            {
                return BadRequest();
            }

            Produit produit = _bd.TableProduit.Find(id);

            if(produit == null)
            {
                return NotFound();
            }

            return Ok(new ObtenirProduitDetailDTO(produit));
        }

        [HttpGet("panier")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ObtenirPanierDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BadRequestResult))]
        public IActionResult ObtenirPanier()
        {
            Utilisateur utilisateurAuth = ControllerContext.HttpContext.Items["Utilisateur"] as Utilisateur;

            if (utilisateurAuth == null)
            {
                return BadRequest();
            }
            return Ok(new ObtenirPanierDTO(utilisateurAuth.Id));
        }

        [HttpPost("creer")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CreatedResult))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BadRequestResult))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(UnauthorizedResult))]
        public IActionResult CreerProduit([FromBody] CreerProduitDTO produit)
        {
            Utilisateur utilisateurAuth = ControllerContext.HttpContext.Items["Utilisateur"] as Utilisateur;

            if (utilisateurAuth == null)
            {
                return BadRequest();
            }

            if(utilisateurAuth.Role != true)
            {
                return Unauthorized();
            }

            _bd.TableProduit.Add(produit.RetournerProduit());
            _bd.SaveChanges();

            return Created();
        }

        [HttpPatch("modifier")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OkResult))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BadRequestResult))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(UnauthorizedResult))]
        public IActionResult ModifierProduit([FromBody] ModifierProduitDTO produitModifier)
        {
            Utilisateur utilisateurAuth = ControllerContext.HttpContext.Items["Utilisateur"] as Utilisateur;

            if (utilisateurAuth == null)
            {
                return BadRequest();
            }

            if (utilisateurAuth.Role != true)
            {
                return Unauthorized();
            }

            Produit ancienProduit = _bd.TableProduit.Find(produitModifier.IdProduit);

            if(ancienProduit == null)
            {
                return BadRequest();
            }

            if(ancienProduit.IdVendeur != utilisateurAuth.Id)
            {
                return Unauthorized();
            }

            produitModifier.AppliquerModification(_bd);

            return Ok();
        }

        [HttpPost("panier")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ObtenirPanierDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BadRequestResult))]
        public IActionResult AjouterProduitPanier(AjouterProduitPanierDTO nouveauProduit)
        {
            Utilisateur utilisateurAuth = ControllerContext.HttpContext.Items["Utilisateur"] as Utilisateur;

            if (utilisateurAuth == null)
            {
                return BadRequest();
            }

            if(_bd.TablePanier.Where(p => p.IdProduit == nouveauProduit.IdProduit && p.IdAcheteur == utilisateurAuth.Id).Any())
            {
                Panier produitExistant = _bd.TablePanier.Where(p => p.IdProduit == nouveauProduit.IdProduit && p.IdAcheteur == utilisateurAuth.Id).First();
                produitExistant.Qte += nouveauProduit.Qte;
                _bd.SaveChanges();
                return Ok(new ObtenirPanierDTO(utilisateurAuth.Id));
            }
            else
            {
                Panier nouveauProduitPanier = new Panier();
                nouveauProduitPanier.Qte = nouveauProduit.Qte;
                nouveauProduitPanier.IdProduit = nouveauProduit.IdProduit;
                nouveauProduitPanier.IdAcheteur = utilisateurAuth.Id;

                _bd.TablePanier.Add(nouveauProduitPanier);
                _bd.SaveChanges();

                return Ok(new ObtenirPanierDTO(utilisateurAuth.Id));
            }
        }
    }
}

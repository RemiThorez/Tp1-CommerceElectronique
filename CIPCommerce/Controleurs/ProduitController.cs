using CIPCommerce.Modeles;
using Microsoft.AspNetCore.Mvc;

namespace CIPCommerce.Controleurs
{
    [Produces("application/json")]
    [Route("api/Produit")]
    [ApiController]
    public class ProduitController : ControllerBase
    {
        private BdContexteCommerce _bd;

        public ProduitController()
        {
            _bd = new BdContexteCommerce();
        }
    }
}

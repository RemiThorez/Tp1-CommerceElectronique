using CIPCommerce.Modeles;
using Microsoft.AspNetCore.Mvc;

namespace CIPCommerce.Controleurs
{
    [Produces("application/json")]
    [Route("api/Facture")]
    [ApiController]
    public class FactureController : ControllerBase
    {
        private BdContexteCommerce _bd;

        public FactureController()
        {
            _bd = new BdContexteCommerce();
        }
    }
}

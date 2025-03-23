using CIPCommerce.Modeles;
using Microsoft.AspNetCore.Mvc;

namespace CIPCommerce.Controleurs
{
    [Produces("application/json")]
    [Route("api/Utilisateur")]
    [ApiController]
    public class UtilisateurController : ControllerBase
    {
        private BdContexteCommerce _bd;

        public UtilisateurController()
        {
            _bd = new BdContexteCommerce();
        }
    }
}

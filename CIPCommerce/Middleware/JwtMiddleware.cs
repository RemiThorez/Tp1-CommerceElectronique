using CIPCommerce.JWT;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using CIPCommerce.Modeles;

namespace CIPCommerce.Middleware
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate suivant_;
        private readonly IConfiguration config_;

        /// <summary>
        /// Le constructeur
        /// </summary>
        /// <param name="suivant">Prochain middleware/etape</param>
        /// <param name="config"></param>
        public JwtMiddleware(RequestDelegate suivant, IConfiguration config)
        {
            suivant_ = suivant;
            config_ = config;
        }

        /// <summary>
        /// Fonction appelée lorsque le Middleware est intérrogé.
        /// </summary>
        /// <param name="contexte"></param>
        /// <param name="bd"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        public async Task InvokeAsync(HttpContext contexte, BdContexteCommerce bd, IOptions<ConfigApp> config)
        {
            Authentification auth = new Authentification(bd, config.Value);
            // On récupère le token d'authentification dans le header.
            var jeton = contexte.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            // Si on a un token, on le valide
            if (jeton != null)
            {
                await auth.ValidateTokenAsync(contexte, jeton);
            }

            await suivant_(contexte);
        }
    }
    /// <summary>
    /// Permet d'utilisé [JWTAutorize] au lieu de [Autorize]
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class JwtAuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        /// <summary>
        ///Notre méthode de validation 
        /// </summary>
        /// <param name="context"></param>
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            // On vérifie s'il y a un usager de connecté dans le contexte
            if (context.HttpContext.Items == null || context.HttpContext.Items["Utilisateur"] == null)
            {
                // Si invalide, on retourne le message d'erreur de connexion.
                context.Result = new UnauthorizedResult();
            }
        }
    }
}


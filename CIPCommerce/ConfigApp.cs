namespace CIPCommerce
{
    /// <summary>
    /// La classe <c>ConfigApp</c> permet d'obtenir les secrets.
    /// </summary>
    public class ConfigApp
    {
        /// <summary>
        /// Shut c'est un secret...
        /// </summary>
        public string Secret { get; set; } = null!;
        public string ChaineConnexion { get; set; } = null!;
    }
}

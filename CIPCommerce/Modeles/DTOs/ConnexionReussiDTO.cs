namespace CIPCommerce.Modeles.DTOs
{
    public class ConnexionReussiDTO
    {
        public ConnexionReussiDTO() { }

        public ConnexionReussiDTO(int id, string jeton) 
        {
            Id = id;
            Jeton = jeton;
        }

        public int Id { get; set; }

        public string Jeton {  get; set; }
    }
}

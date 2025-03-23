namespace CIPCommerce.Modeles.DTOs
{
    public class ModifierProduitDTO
    {
        public ModifierProduitDTO() { }

        public void AppliquerModification(BdContexteCommerce bd)
        {
            Produit produitAModifier = bd.TableProduit.Find(IdProduit);

            produitAModifier.Titre = Titre ?? produitAModifier.Titre;
            produitAModifier.Description = Description ?? produitAModifier.Description;
            produitAModifier.Prix = Prix ?? produitAModifier.Prix;
            produitAModifier.Categorie = Categorie ?? produitAModifier.Categorie;
            produitAModifier.Image = Image ?? produitAModifier.Image;

            bd.SaveChanges();
        }

        public int IdProduit { get; set; }

        public string? Titre { get; set; }

        public string? Description { get; set; }

        public double? Prix { get; set; }

        public string? Categorie { get; set; }

        public string? Image { get; set; }

        public int IdVendeur { get; set; }
    }
}

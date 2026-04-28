namespace ClavierDOr.Models.Roles;

public class DeveloppeurBack : Role
{
    public DeveloppeurBack()
    {
        Nom = "Développeur Back";
        Description = "Bénéficie d'un rattrapage automatique (2ème essai) en cas d'erreur.";
    }

    public override string ActiverPouvoir()
    {
        PouvoirUtilise = true;
        return "Rattrapage activé : Vous avez le droit à un deuxième essai !";
    }
}
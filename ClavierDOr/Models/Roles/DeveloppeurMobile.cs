namespace ClavierDOr.Models.Roles;

public class DeveloppeurMobile : Role
{
    public DeveloppeurMobile()
    {
        Nom = "Développeur Mobile";
        Description = "Obtient un indice (supprime 2 mauvaises réponses).";
    }

    public override string ActiverPouvoir()
    {
        PouvoirUtilise = true;
        return "Indice activé : 2 mauvaises réponses ont été supprimées !";
    }
}
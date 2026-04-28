namespace ClavierDOr.Models.Roles;

// La classe hérite (:) de Role
public class DeveloppeurMobile : Role
{
    // Le constructeur
    public DeveloppeurMobile()
    {
        Nom = "Développeur Mobile";
        Description = "Obtient un indice (supprime 2 mauvaises réponses).";
    }

    // On personnalise la méthode pour le Mobile
    public override string ActiverPouvoir()
    {
        PouvoirUtilise = true;
        return "Indice activé : 2 mauvaises réponses ont été supprimées !";
    }
}
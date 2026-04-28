namespace ClavierDOr.Models.Roles;

// La classe hérite (:) de Role
public class DeveloppeurFront : Role
{
    // Le constructeur : il s'exécute dès qu'on crée un DevFront
    public DeveloppeurFront()
    {
        // On remplit les propriétés héritées du parent
        Nom = "Développeur Front";
        Description = "Peut changer de question une fois par partie.";
    }

    // "override" permet de personnaliser la méthode abstraite du parent
    public override string ActiverPouvoir()
    {
        // On note que le pouvoir a été consommé
        PouvoirUtilise = true;
        // On renvoie un message qui sera affiché à l'écran
        return "Changement de question ! Une nouvelle question arrive.";
    }
}
namespace ClavierDOr.Models.Roles;

// La classe hérite (:) de Role
public class DeveloppeurBack : Role
{
    // Le constructeur pour initialiser les valeurs
    public DeveloppeurBack()
    {
        Nom = "Développeur Back";
        Description = "Bénéficie d'un rattrapage automatique (2ème essai) en cas d'erreur.";
    }

    // On personnalise la méthode pour le Back
    public override string ActiverPouvoir()
    {
        // On grille le joker
        PouvoirUtilise = true;
        // On renvoie le texte d'activation
        return "Rattrapage activé : Vous avez le droit à un deuxième essai !";
    }
}
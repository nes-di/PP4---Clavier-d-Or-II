namespace ClavierDOr.Models.Roles;

// Classe statique : pas besoin de l'instancier pour l'utiliser
public static class RoleFactory
{
    // Cette méthode reçoit le choix de l'utilisateur (ex: "Front") et renvoie un objet Role prêt à l'emploi
    public static Role CreerRole(string typeRole)
    {
        // Si le joueur a choisi Front, on fabrique un objet DeveloppeurFront
        if (typeRole == "Front")
        {
            return new DeveloppeurFront();
        }
        // Si c'est Back, on fabrique un DeveloppeurBack
        else if (typeRole == "Back")
        {
            return new DeveloppeurBack();
        }
        // Si c'est Mobile, on fabrique un DeveloppeurMobile
        else if (typeRole == "Mobile")
        {
            return new DeveloppeurMobile();
        }
        // Par sécurité (si l'utilisateur a triché), on renvoie un Front par défaut
        else
        {
            return new DeveloppeurFront();
        }
    }
}
// On déclare notre espace de noms pour le dossier Roles
namespace ClavierDOr.Models.Roles;

// "abstract" signifie qu'on ne peut pas créer un "Role" générique, c'est juste un modèle de base
public abstract class Role
{
    // Le nom du rôle (ex: "Développeur Front")
    public string Nom { get; set; } = string.Empty;

    // L'explication du pouvoir pour l'afficher à l'écran
    public string Description { get; set; } = string.Empty;

    // Un booléen pour savoir si le joueur a déjà utilisé son pouvoir unique pendant la partie
    public bool PouvoirUtilise { get; set; } = false;

    // Méthode abstraite : on force tous les enfants à posséder cette méthode d'activation
    public abstract string ActiverPouvoir();
}
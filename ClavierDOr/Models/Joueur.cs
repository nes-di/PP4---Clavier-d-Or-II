// Toujours le même espace de noms pour que les classes se trouvent entre elles
namespace ClavierDOr.Models;

// Définition de la classe Joueur pour stocker le profil de l'utilisateur
public class Joueur
{
    // Propriété Id : Clé primaire unique du joueur
    public int Id { get; set; }

    // Propriété Pseudo : Le nom choisi par le joueur à l'accueil
    public string Pseudo { get; set; } = string.Empty;

    // Propriété RoleChoisi : Stocke le nom du rôle (ex: "DevFront", "DevBack")
    public string RoleChoisi { get; set; } = string.Empty;

    // Propriété MeilleurScore : Un entier pour conserver le record du joueur
    public int MeilleurScore { get; set; }
}
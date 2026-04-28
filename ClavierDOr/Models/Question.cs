// Déclaration de l'espace de noms (namespace) pour organiser notre code
namespace ClavierDOr.Models;

// Définition de la classe Question qui servira de plan pour nos objets et notre table BDD
public class Question
{
    // Propriété Id : Entier qui sert de clé primaire unique dans la base de données
    public int Id { get; set; }

    // Propriété Theme : Chaîne de caractères pour classer la question (ex: "Maths")
    public string Theme { get; set; } = string.Empty;

    // Propriété Texte : L'intitulé de la question posée au joueur
    public string Texte { get; set; } = string.Empty;

    // Propriété OptionA : Le texte de la première réponse possible
    public string OptionA { get; set; } = string.Empty;

    // Propriété OptionZ : Le texte de la deuxième réponse possible
    public string OptionZ { get; set; } = string.Empty;

    // Propriété OptionE : Le texte de la troisième réponse possible
    public string OptionE { get; set; } = string.Empty;

    // Propriété OptionR : Le texte de la quatrième réponse possible
    public string OptionR { get; set; } = string.Empty;

    // Propriété ReponseCorrecte : Stocke la lettre de la bonne réponse (A, Z, E ou R)
    public string ReponseCorrecte { get; set; } = string.Empty;

    // Propriété EstBoss : Booléen (Vrai/Faux) pour indiquer si c'est une question difficile
    public bool EstBoss { get; set; }
}
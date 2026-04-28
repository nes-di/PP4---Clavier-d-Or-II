using System;

namespace ClavierDOr.Models;

// Cette classe représente une sauvegarde complète de l'état du jeu
public class Partie
{
    // Identifiant unique de la sauvegarde en base de données
    public int Id { get; set; }

    // Le pseudo du joueur pour l'afficher dans l'historique
    public string Pseudo { get; set; } = string.Empty;

    // Le rôle choisi (Front, Back, Mobile) pour reconstruire l'objet Role au chargement
    public string RoleChoisi { get; set; } = string.Empty;

    // Le thème sélectionné (Maths, Sports, etc.)
    public string Theme { get; set; } = string.Empty;

    // Le score cumulé jusqu'à la sauvegarde
    public int ScoreAtteint { get; set; }

    // L'index de la question en cours (pour ne pas recommencer au début du thème)
    public int IndexQuestion { get; set; }

    // État du pouvoir : pour ne pas pouvoir tricher en rechargeant la partie
    public bool PouvoirDejaUtilise { get; set; }

    // Date et heure de la sauvegarde
    public DateTime DateSauvegarde { get; set; } = DateTime.Now;
}
using System;

namespace ClavierDOr.Models;

public class Partie
{
    public int Id { get; set; }
    public string Pseudo { get; set; } = string.Empty;
    public string RoleChoisi { get; set; } = string.Empty;
    public string Theme { get; set; } = string.Empty;
    public int ScoreAtteint { get; set; }
    public int IndexQuestion { get; set; }
    public bool PouvoirDejaUtilise { get; set; }
    public DateTime DateSauvegarde { get; set; } = DateTime.Now;
}
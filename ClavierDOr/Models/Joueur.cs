namespace ClavierDOr.Models;

public class Joueur
{
    public int Id { get; set; }
    public string Pseudo { get; set; } = string.Empty;
    public string RoleChoisi { get; set; } = string.Empty;
    public int MeilleurScore { get; set; }
}
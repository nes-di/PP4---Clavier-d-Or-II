using Microsoft.EntityFrameworkCore; // Importe Entity Framework Core pour gérer les interactions avec la base de données
using ClavierDOr.Models; // Importe l'espace de noms Models pour accéder aux classes Question, Partie et Joueur

namespace ClavierDOr.Data; // Définit l'espace de noms Data pour organiser les classes liées à la base de données

public class AppDbContext : DbContext // Classe principale qui représente le contexte de la base de données, hérite de DbContext d'Entity Framework
{
    public DbSet<Question> Questions { get; set; } // Propriété DbSet pour accéder et manipuler la table Questions dans la base de données
    public DbSet<Partie> Parties { get; set; } // Propriété DbSet pour accéder et manipuler la table Parties dans la base de données
    public DbSet<Joueur> Joueurs { get; set; } // Propriété DbSet pour accéder et manipuler la table Joueurs dans la base de données

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) // Constructeur qui prend les options de configuration de la base de données et les passe à la classe parente DbContext
    {
    }
}
using Microsoft.EntityFrameworkCore;
using ClavierDOr.Models;

namespace ClavierDOr.Data;

public class AppDbContext : DbContext
{
    public DbSet<Question> Questions { get; set; }
    public DbSet<Partie> Parties { get; set; }
    public DbSet<Joueur> Joueurs { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
}
using ClavierDOr.Components;
using Microsoft.EntityFrameworkCore;
// Importation de nos dossiers pour que le programme trouve nos classes
using ClavierDOr.Data;
using ClavierDOr.Services;
using QuestPDF.Infrastructure;

// 1. INITIALISATION DU CONSTRUCTEUR
var builder = WebApplication.CreateBuilder(args);

// 2. AJOUT DES SERVICES DE BASE BLAZOR
// On active les composants Razor et le mode "Server" pour l'interactivité (clics de boutons)
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// 3. CONFIGURATION DE L'ORM (ENTITY FRAMEWORK)
// On lie notre AppDbContext au fichier de base de données SQLite "quiz.db"
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=quiz.db"));

// 4. ENREGISTREMENT DE NOS SERVICES (INJECTION DE DÉPENDANCES)
// AddScoped signifie qu'une instance est créée par utilisateur
builder.Services.AddScoped<GameService>(); // Le cerveau du quizz
builder.Services.AddScoped<PdfService>();  // Le moteur de génération PDF

// 5. CONFIGURATION DE LA LICENCE PDF
// Obligatoire pour utiliser QuestPDF en version gratuite (Community)
QuestPDF.Settings.License = LicenseType.Community;

// 6. CONSTRUCTION DE L'APPLICATION
var app = builder.Build();

// 7. CONFIGURATION DU PIPELINE (GESTION DES ERREURS ET FICHIERS)
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection(); // Force le HTTPS
app.UseStaticFiles();      // Autorise l'utilisation du CSS et des images (dossier wwwroot)
app.UseAntiforgery();     // Sécurité contre les attaques de formulaires

// 8. CARTOGRAPHIE DES COMPOSANTS
// On indique à Blazor d'utiliser le mode "InteractiveServer" pour que les boutons fonctionnent
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

// --- INITIALISATION DE LA BASE (SEEDER) ---
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    // On appelle notre classe Seeder pour remplir les questions
    ClavierDOr.Data.DatabaseSeeder.Initialiser(context);
}


// 9. LANCEMENT !
app.Run();
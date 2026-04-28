using ClavierDOr.Data; // Importe l'espace de noms Data pour accéder à AppDbContext
using ClavierDOr.Models; // Importe les modèles comme Joueur, Question
using ClavierDOr.Models.Roles; // Importe les rôles comme Role, RoleFactory
using Microsoft.EntityFrameworkCore; // Importe Entity Framework pour les requêtes LINQ

namespace ClavierDOr.Services; // Définit l'espace de noms Services

public class GameService // Classe principale pour gérer la logique du jeu
{
    private readonly AppDbContext _context; // Contexte de base de données injecté
    public Joueur? JoueurActuel { get; private set; } // Joueur actuel de la partie
    public Role? RoleActuel { get; private set; } // Rôle choisi par le joueur
    public int ScoreActuel { get; private set; } // Score cumulé du joueur
    public Question? QuestionEnCours { get; private set; } // Question actuellement posée
    public string ThemeActuel { get; private set; } = string.Empty; // Thème sélectionné
    public string MessageAction { get; private set; } = string.Empty; // Message affiché au joueur
    public bool PartieTerminee { get; private set; } = false; // Indique si la partie est finie

    // --- NOUVEAUTÉ : Pour le 50/50 --- // Section pour le pouvoir 50/50
    public List<string> OptionsMasquees { get; private set; } = new(); // Liste des options masquées par le pouvoir

    private List<Question> _questionsDeLaPartie = new(); // Liste des questions de la partie
    private int _indexQuestionActuelle = 0; // Index de la question en cours
    
    public int NumeroQuestion => _indexQuestionActuelle; // Propriété calculée pour le numéro de question
    public int TotalQuestions => 10; // Nombre total de questions par partie

    public GameService(AppDbContext context) { _context = context; } // Constructeur injectant le contexte

    public List<string> GetThemesDisponibles() => _context.Questions.Select(q => q.Theme).Distinct().ToList(); // Récupère les thèmes disponibles

    public void DemarrerPartie(string pseudo, string roleChoisi, string themeChoisi) // Démarre une nouvelle partie
    {
        JoueurActuel = new Joueur { Pseudo = pseudo, RoleChoisi = roleChoisi }; // Crée le joueur
        RoleActuel = RoleFactory.CreerRole(roleChoisi); // Crée le rôle
        ThemeActuel = themeChoisi; // Définit le thème
        ScoreActuel = 0; // Réinitialise le score
        PartieTerminee = false; // Partie non terminée
        _indexQuestionActuelle = 0; // Réinitialise l'index

        var questionsNormales = _context.Questions // Récupère les questions normales
            .Where(q => q.Theme == themeChoisi && !q.EstBoss) // Filtre par thème et non-boss
            .AsEnumerable() // Passe en mémoire
            .OrderBy(x => Guid.NewGuid()) // Mélange aléatoirement
            .Take(9) // Prend 9 questions
            .ToList(); // Convertit en liste

        var questionBoss = _context.Questions // Récupère la question boss
            .Where(q => q.Theme == themeChoisi && q.EstBoss) // Filtre par thème et boss
            .AsEnumerable() // Passe en mémoire
            .OrderBy(x => Guid.NewGuid()) // Mélange
            .Take(1) // Prend 1
            .FirstOrDefault(); // Première ou null

        _questionsDeLaPartie = questionsNormales; // Assigne les normales
        if (questionBoss != null) _questionsDeLaPartie.Add(questionBoss); // Ajoute la boss si existe

        MessageAction = $"La quête commence ! 9 questions + 1 BOSS FINAL."; // Message de début
        ChargerNouvelleQuestion(); // Charge la première question
    }

    public void VerifierReponse(string reponseChoisie) // Vérifie la réponse donnée
    {
        if (QuestionEnCours == null) return; // Si pas de question, rien

        if (reponseChoisie == QuestionEnCours.ReponseCorrecte) // Si bonne réponse
        {
            if (QuestionEnCours.EstBoss) // Si c'est une boss
            {
                ScoreActuel += 30; // +30 points
                MessageAction = "🔥 INCROYABLE ! Boss vaincu : +30 POINTS !"; // Message victoire boss
            }
            else // Sinon normale
            {
                ScoreActuel += 10; // +10 points
                MessageAction = "Bonne réponse ! +10 points."; // Message bonne réponse
            }
            ChargerNouvelleQuestion(); // Passe à la suivante
        }
        else // Mauvaise réponse
        {
            if (RoleActuel is DeveloppeurBack && !RoleActuel.PouvoirUtilise) // Si Back et pouvoir disponible
            {
                MessageAction = RoleActuel.ActiverPouvoir(); // Active le pouvoir
                // On ne change pas de question, le joueur peut retenter // Commentaire
            }
            else // Sinon échec
            {
                MessageAction = QuestionEnCours.EstBoss ? "Le Boss vous a terrassé..." : "Échec... Partie terminée."; // Message échec
                PartieTerminee = true; // Termine la partie
                EnregistrerScoreFinal(); // Enregistre le score
            }
        }
    }

    public void ChargerNouvelleQuestion() // Charge la prochaine question
    {
        // On vide systématiquement les options masquées à chaque nouvelle question // Vide les masquées
        OptionsMasquees.Clear();

        if (_indexQuestionActuelle < _questionsDeLaPartie.Count) // Si il y a encore des questions
        {
            QuestionEnCours = _questionsDeLaPartie[_indexQuestionActuelle]; // Assigne la question
            _indexQuestionActuelle++; // Incrémente l'index
        }
        else // Plus de questions
        {
            PartieTerminee = true; // Termine
            QuestionEnCours = null; // Pas de question
            MessageAction = "🏆 QUÊTE TERMINÉE ! Vous êtes un Maître du Clavier !"; // Message fin
            EnregistrerScoreFinal(); // Enregistre
        }
    }

    public void UtiliserPouvoir() // Utilise le pouvoir du rôle
    { 
        if (RoleActuel == null || RoleActuel.PouvoirUtilise || QuestionEnCours == null) return; // Conditions d'utilisation

        MessageAction = RoleActuel.ActiverPouvoir(); // Active le pouvoir

        if (RoleActuel is DeveloppeurFront) // Si Front
        {
            ChargerNouvelleQuestion(); // Saute la question
        }
        else if (RoleActuel is DeveloppeurMobile) // Si Mobile
        {
            // --- LOGIQUE DU 50/50 --- // Logique 50/50
            var toutesOptions = new List<string> { "A", "Z", "E", "R" }; // Toutes les options
            // On retire la bonne réponse de la liste des candidats à l'effacement // Retire la bonne
            toutesOptions.Remove(QuestionEnCours.ReponseCorrecte);

            // On mélange les 3 mauvaises et on en prend 2 // Mélange et prend 2
            var aMasquer = toutesOptions.OrderBy(x => Guid.NewGuid()).Take(2).ToList();
            OptionsMasquees.AddRange(aMasquer); // Ajoute aux masquées
        }
    }

    public void SauvegarderPartieEnCours() { if (JoueurActuel == null || PartieTerminee) return; var s = new Partie { Pseudo = JoueurActuel.Pseudo, RoleChoisi = JoueurActuel.RoleChoisi, Theme = ThemeActuel, ScoreAtteint = ScoreActuel, IndexQuestion = _indexQuestionActuelle - 1, PouvoirDejaUtilise = RoleActuel?.PouvoirUtilise ?? false, DateSauvegarde = DateTime.Now }; _context.Parties.Add(s); _context.SaveChanges(); } // Sauvegarde la partie en cours
    
    public void ChargerSauvegarde(Partie s) { JoueurActuel = new Joueur { Pseudo = s.Pseudo, RoleChoisi = s.RoleChoisi }; RoleActuel = RoleFactory.CreerRole(s.RoleChoisi); RoleActuel.PouvoirUtilise = s.PouvoirDejaUtilise; ThemeActuel = s.Theme; ScoreActuel = s.ScoreAtteint; PartieTerminee = false; _questionsDeLaPartie = _context.Questions.Where(q => q.Theme == s.Theme).ToList(); _indexQuestionActuelle = s.IndexQuestion; if (_indexQuestionActuelle < _questionsDeLaPartie.Count) { QuestionEnCours = _questionsDeLaPartie[_indexQuestionActuelle]; _indexQuestionActuelle++; } } // Charge une sauvegarde
    
    private void EnregistrerScoreFinal() { if (JoueurActuel == null) return; var j = _context.Joueurs.FirstOrDefault(x => x.Pseudo == JoueurActuel.Pseudo); if (j != null) { if (ScoreActuel > j.MeilleurScore) j.MeilleurScore = ScoreActuel; } else { JoueurActuel.MeilleurScore = ScoreActuel; _context.Joueurs.Add(JoueurActuel); } _context.SaveChanges(); } // Enregistre le score final
}
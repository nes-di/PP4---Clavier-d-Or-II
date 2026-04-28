using ClavierDOr.Data;
using ClavierDOr.Models;
using ClavierDOr.Models.Roles;
using Microsoft.EntityFrameworkCore;

namespace ClavierDOr.Services;

public class GameService
{
    private readonly AppDbContext _context;

    public Joueur? JoueurActuel { get; private set; }
    public Role? RoleActuel { get; private set; }
    public int ScoreActuel { get; private set; }
    public Question? QuestionEnCours { get; private set; }
    public string ThemeActuel { get; private set; } = string.Empty;
    public string MessageAction { get; private set; } = string.Empty;
    public bool PartieTerminee { get; private set; } = false;

    private List<Question> _questionsDeLaPartie = new();
    private int _indexQuestionActuelle = 0;

    public int NumeroQuestion => _indexQuestionActuelle;
    public int TotalQuestions => 10;

    public List<string> OptionsMasquees { get; private set; } = new();
    public bool? DerniereReponseCorrecte { get; private set; }
    public string? LettreSelectionnee { get; private set; }
    public bool APerdu { get; private set; } = false;

    public GameService(AppDbContext context) { _context = context; }

    public List<string> GetThemesDisponibles() => _context.Questions.Select(q => q.Theme).Distinct().ToList();

    public void DemarrerPartie(string pseudo, string roleChoisi, string thèmeChoisi)
    {
        JoueurActuel = new Joueur { Pseudo = pseudo, RoleChoisi = roleChoisi };
        RoleActuel = RoleFactory.CreerRole(roleChoisi);
        ThemeActuel = thèmeChoisi;
        ScoreActuel = 0;
        PartieTerminee = false;
        APerdu = false;
        _indexQuestionActuelle = 0;
        DerniereReponseCorrecte = null;
        LettreSelectionnee = null;

        var questionsNormales = _context.Questions
            .Where(q => q.Theme == thèmeChoisi && !q.EstBoss)
            .AsEnumerable()
            .OrderBy(x => Guid.NewGuid())
            .Take(9)
            .ToList();

        var questionBoss = _context.Questions
            .Where(q => q.Theme == thèmeChoisi && q.EstBoss)
            .AsEnumerable()
            .OrderBy(x => Guid.NewGuid())
            .Take(1)
            .FirstOrDefault();

        _questionsDeLaPartie = questionsNormales;
        if (questionBoss != null) _questionsDeLaPartie.Add(questionBoss);

        MessageAction = $"La quête commence ! 9 questions + 1 BOSS FINAL.";
        ChargerNouvelleQuestion();
    }

    public void VerifierReponse(string reponseChoisie)
    {
        if (QuestionEnCours == null || PartieTerminee) return;

        LettreSelectionnee = reponseChoisie;

        if (reponseChoisie == QuestionEnCours.ReponseCorrecte)
        {
            DerniereReponseCorrecte = true;

            if (QuestionEnCours.EstBoss)
            {
                ScoreActuel += 30;
                MessageAction = "🔥 INCROYABLE ! Boss vaincu : +30 POINTS !";
            }
            else
            {
                ScoreActuel += 10;
                MessageAction = "Bonne réponse ! +10 points.";
            }
        }
        else
        {
            DerniereReponseCorrecte = false;

            if (RoleActuel is DeveloppeurBack && !RoleActuel.PouvoirUtilise)
            {
                MessageAction = RoleActuel.ActiverPouvoir();
            }
            else
            {
                MessageAction = QuestionEnCours.EstBoss ? "Le Boss vous a terrassé..." : "Échec... Partie terminée.";
                PartieTerminee = true;
                APerdu = true;
                EnregistrerScoreFinal();
            }
        }
    }

    public void ChargerNouvelleQuestion()
    {
        DerniereReponseCorrecte = null;
        LettreSelectionnee = null;
        OptionsMasquees.Clear();

        if (_indexQuestionActuelle < _questionsDeLaPartie.Count)
        {
            QuestionEnCours = _questionsDeLaPartie[_indexQuestionActuelle];
            _indexQuestionActuelle++;
        }
        else
        {
            PartieTerminee = true;
            APerdu = false;
            QuestionEnCours = null;
            MessageAction = "🏆 QUÊTE TERMINÉE ! Vous êtes un Maître du Clavier !";
            EnregistrerScoreFinal();
        }
    }

    public void UtiliserPouvoir()
    {
        if (RoleActuel == null || RoleActuel.PouvoirUtilise || QuestionEnCours == null) return;

        MessageAction = RoleActuel.ActiverPouvoir();

        if (RoleActuel is DeveloppeurFront)
        {
            ChargerNouvelleQuestion();
        }
        else if (RoleActuel is DeveloppeurMobile)
        {
            var toutesOptions = new List<string> { "A", "Z", "E", "R" };
            toutesOptions.Remove(QuestionEnCours.ReponseCorrecte);

            var aMasquer = toutesOptions.OrderBy(x => Guid.NewGuid()).Take(2).ToList();
            OptionsMasquees.AddRange(aMasquer);
        }
    }

    public void SauvegarderPartieEnCours()
    {
        if (JoueurActuel == null || PartieTerminee) return;

        var s = new Partie
        {
            Pseudo = JoueurActuel.Pseudo,
            RoleChoisi = JoueurActuel.RoleChoisi,
            Theme = ThemeActuel,
            ScoreAtteint = ScoreActuel,
            IndexQuestion = _indexQuestionActuelle - 1,
            PouvoirDejaUtilise = RoleActuel?.PouvoirUtilise ?? false,
            DateSauvegarde = DateTime.Now
        };

        _context.Parties.Add(s);
        _context.SaveChanges();
    }

    public void ChargerSauvegarde(Partie s)
    {
        JoueurActuel = new Joueur { Pseudo = s.Pseudo, RoleChoisi = s.RoleChoisi };
        RoleActuel = RoleFactory.CreerRole(s.RoleChoisi);
        RoleActuel.PouvoirUtilise = s.PouvoirDejaUtilise;
        ThemeActuel = s.Theme;
        ScoreActuel = s.ScoreAtteint;
        PartieTerminee = false;
        APerdu = false;

        _questionsDeLaPartie = _context.Questions.Where(q => q.Theme == s.Theme).ToList();
        _indexQuestionActuelle = s.IndexQuestion;

        if (_indexQuestionActuelle < _questionsDeLaPartie.Count)
        {
            QuestionEnCours = _questionsDeLaPartie[_indexQuestionActuelle];
            _indexQuestionActuelle++;
        }
    }

    private void EnregistrerScoreFinal()
    {
        if (JoueurActuel == null) return;

        var j = _context.Joueurs.FirstOrDefault(x => x.Pseudo == JoueurActuel.Pseudo);

        if (j != null)
        {
            if (ScoreActuel > j.MeilleurScore) j.MeilleurScore = ScoreActuel;
        }
        else
        {
            JoueurActuel.MeilleurScore = ScoreActuel;
            _context.Joueurs.Add(JoueurActuel);
        }

        _context.SaveChanges();
    }
}
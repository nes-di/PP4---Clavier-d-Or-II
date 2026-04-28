using ClavierDOr.Models; // Importe les modèles pour utiliser la classe Question
using Microsoft.EntityFrameworkCore; // Importe Entity Framework pour interagir avec la base de données
using System.Collections.Generic; // Importe les collections génériques pour List
using System.Linq; // Importe LINQ pour les requêtes sur les collections

namespace ClavierDOr.Data; // Définit l'espace de noms Data

public static class DatabaseSeeder // Classe statique pour initialiser la base de données avec des données de départ
{
    public static void Initialiser(AppDbContext context) // Méthode statique pour remplir la base avec des questions
    {
        context.Database.Migrate(); // Applique les migrations pour créer ou mettre à jour la structure de la base de données

        if (context.Questions.Any()) return; // Si la base contient déjà des questions, on arrête pour éviter les doublons

        var q = new List<Question>(); // Crée une liste vide de questions pour les ajouter en lot

        // --- ⚽ SPORTS (10 questions) --- // Section pour les questions de sport
        q.Add(new Question { Theme = "Sports", Texte = "Dans quel sport y a-t-il un smash ?", OptionA = "Tous", OptionZ = "Tennis", OptionE = "Badminton", OptionR = "Volley", ReponseCorrecte = "A" }); // Ajoute une question sur le smash dans les sports
        q.Add(new Question { Theme = "Sports", Texte = "Quelle est la couleur du maillot jaune au Tour de France ?", OptionA = "Vert", OptionZ = "Jaune", OptionE = "Rouge", OptionR = "Blanc", ReponseCorrecte = "Z" }); // Question sur le maillot jaune du Tour de France
        q.Add(new Question { Theme = "Sports", Texte = "Quel pays a gagné la Coupe du Monde 2018 ?", OptionA = "Croatie", OptionZ = "France", OptionE = "Allemagne", OptionR = "Brésil", ReponseCorrecte = "Z" }); // Question sur le vainqueur de la Coupe du Monde 2018
        q.Add(new Question { Theme = "Sports", Texte = "Combien de temps dure un match de foot (hors arrêts) ?", OptionA = "80 min", OptionZ = "90 min", OptionE = "100 min", OptionR = "45 min", ReponseCorrecte = "Z" }); // Durée d'un match de football
        q.Add(new Question { Theme = "Sports", Texte = "Quel sport est pratiqué par Rafael Nadal ?", OptionA = "Golf", OptionZ = "Tennis", OptionE = "Boxe", OptionR = "Rugby", ReponseCorrecte = "Z" }); // Sport de Rafael Nadal
        q.Add(new Question { Theme = "Sports", Texte = "Nombre de joueurs dans une équipe de basket ?", OptionA = "4", OptionZ = "5", OptionE = "6", OptionR = "11", ReponseCorrecte = "Z" }); // Nombre de joueurs en basket
        q.Add(new Question { Theme = "Sports", Texte = "Quelle est la distance d'un marathon (en km) ?", OptionA = "40.195", OptionZ = "42.195", OptionE = "44.195", OptionR = "21.000", ReponseCorrecte = "Z" }); // Distance du marathon
        q.Add(new Question { Theme = "Sports", Texte = "Dans quel sport Michael Jordan a-t-il excellé ?", OptionA = "Baseball", OptionZ = "Basket", OptionE = "Foot", OptionR = "Tennis", ReponseCorrecte = "Z" }); // Sport de Michael Jordan
        q.Add(new Question { Theme = "Sports", Texte = "Combien de points vaut un essai au Rugby (sans transformation) ?", OptionA = "3", OptionZ = "5", OptionE = "7", OptionR = "2", ReponseCorrecte = "Z" }); // Points pour un essai en rugby
        q.Add(new Question { Theme = "Sports", Texte = "Combien pèse précisément un ballon de foot officiel (grammes) ?", OptionA = "400", OptionZ = "450", OptionE = "430", OptionR = "410", ReponseCorrecte = "Z", EstBoss = true }); // Poids du ballon de foot, question boss

        // --- 📐 MATHS (10 questions) --- // Section maths
        q.Add(new Question { Theme = "Maths", Texte = "Combien font 7 x 6 ?", OptionA = "36", OptionZ = "42", OptionE = "48", OptionR = "54", ReponseCorrecte = "Z" }); // Multiplication 7x6
        q.Add(new Question { Theme = "Maths", Texte = "Quelle est la racine carrée de 81 ?", OptionA = "7", OptionZ = "8", OptionE = "9", OptionR = "10", ReponseCorrecte = "E" }); // Racine carrée de 81
        q.Add(new Question { Theme = "Maths", Texte = "Combien font 100 / 4 ?", OptionA = "20", OptionZ = "25", OptionE = "30", OptionR = "50", ReponseCorrecte = "Z" }); // Division 100/4
        q.Add(new Question { Theme = "Maths", Texte = "Combien font 15 + 25 ?", OptionA = "35", OptionZ = "40", OptionE = "45", OptionR = "50", ReponseCorrecte = "Z" }); // Addition 15+25
        q.Add(new Question { Theme = "Maths", Texte = "Un angle droit mesure combien de degrés ?", OptionA = "45", OptionZ = "90", OptionE = "180", OptionR = "360", ReponseCorrecte = "Z" }); // Mesure d'un angle droit
        q.Add(new Question { Theme = "Maths", Texte = "Combien font 9 x 9 ?", OptionA = "72", OptionZ = "81", OptionE = "90", OptionR = "100", ReponseCorrecte = "Z" }); // 9x9
        q.Add(new Question { Theme = "Maths", Texte = "Le nombre Pi est environ égal à ?", OptionA = "2.14", OptionZ = "3.14", OptionE = "4.14", OptionR = "1.14", ReponseCorrecte = "Z" }); // Valeur de Pi
        q.Add(new Question { Theme = "Maths", Texte = "Quelle est la somme des angles d'un triangle ?", OptionA = "90°", OptionZ = "180°", OptionE = "360°", OptionR = "270°", ReponseCorrecte = "Z" }); // Somme des angles d'un triangle
        q.Add(new Question { Theme = "Maths", Texte = "Combien font 12 x 12 ?", OptionA = "124", OptionZ = "144", OptionE = "134", OptionR = "154", ReponseCorrecte = "Z" }); // 12x12
        q.Add(new Question { Theme = "Maths", Texte = "Quel est le résultat exact de 13² + 17² ?", OptionA = "458", OptionZ = "338", OptionE = "628", OptionR = "538", ReponseCorrecte = "A", EstBoss = true }); // Calcul 13² + 17², boss

        // --- 🧪 SCIENCE (10 questions) --- // Section science
        q.Add(new Question { Theme = "Science", Texte = "Quel organe pompe le sang dans tout le corps ?", OptionA = "Cœur", OptionZ = "Poumon", OptionE = "Foie", OptionR = "Rein", ReponseCorrecte = "A" }); // Organe qui pompe le sang
        q.Add(new Question { Theme = "Science", Texte = "Quel animal pond des œufs et allaite ses petits ?", OptionA = "Cygne", OptionZ = "Ornithorynque", OptionE = "Kangourou", OptionR = "Dauphin", ReponseCorrecte = "Z" }); // Animal ovipare et mammifère
        q.Add(new Question { Theme = "Science", Texte = "Quelle est la planète la plus proche du Soleil ?", OptionA = "Vénus", OptionZ = "Mars", OptionE = "Mercure", OptionR = "Terre", ReponseCorrecte = "E" }); // Planète la plus proche du Soleil
        q.Add(new Question { Theme = "Science", Texte = "Quelle est la formule chimique de l'eau ?", OptionA = "CO2", OptionZ = "H2O", OptionE = "O2", OptionR = "NaCl", ReponseCorrecte = "Z" }); // Formule de l'eau
        q.Add(new Question { Theme = "Science", Texte = "Quelle planète est surnommée la 'Planète Rouge' ?", OptionA = "Jupiter", OptionZ = "Mars", OptionE = "Saturne", OptionR = "Vénus", ReponseCorrecte = "Z" }); // Planète rouge
        q.Add(new Question { Theme = "Science", Texte = "Quelle est l'unité de mesure de la tension électrique ?", OptionA = "Watt", OptionZ = "Ampère", OptionE = "Volt", OptionR = "Ohm", ReponseCorrecte = "E" }); // Unité de tension
        q.Add(new Question { Theme = "Science", Texte = "Qui a découvert la loi de la gravité (légende de la pomme) ?", OptionA = "Einstein", OptionZ = "Newton", OptionE = "Galilée", OptionR = "Tesla", ReponseCorrecte = "Z" }); // Découvreur de la gravité
        q.Add(new Question { Theme = "Science", Texte = "Quel est le plus grand mammifère du monde ?", OptionA = "Éléphant", OptionZ = "Baleine Bleue", OptionE = "Requin", OptionR = "Girafe", ReponseCorrecte = "Z" }); // Plus grand mammifère
        q.Add(new Question { Theme = "Science", Texte = "Quel gaz est essentiel à la respiration humaine ?", OptionA = "Azote", OptionZ = "Oxygène", OptionE = "Hélium", OptionR = "CO2", ReponseCorrecte = "Z" }); // Gaz pour respiration
        q.Add(new Question { Theme = "Science", Texte = "Combien d'os possède un corps humain adulte ?", OptionA = "196", OptionZ = "206", OptionE = "216", OptionR = "226", ReponseCorrecte = "Z", EstBoss = true }); // Nombre d'os, boss

        // --- 🌍 GEOGRAPHIE (10 questions) --- // Section géographie
        q.Add(new Question { Theme = "Geographie", Texte = "Quelle est la capitale de la France ?", OptionA = "Lyon", OptionZ = "Paris", OptionE = "Marseille", OptionR = "Lille", ReponseCorrecte = "Z" }); // Capitale de la France
        q.Add(new Question { Theme = "Geographie", Texte = "Quel est le plus grand pays du monde en superficie ?", OptionA = "Chine", OptionZ = "Russie", OptionE = "USA", OptionR = "Canada", ReponseCorrecte = "Z" }); // Plus grand pays
        q.Add(new Question { Theme = "Geographie", Texte = "Quel océan sépare l'Europe de l'Amérique ?", OptionA = "Indien", OptionZ = "Atlantique", OptionE = "Pacifique", OptionR = "Arctique", ReponseCorrecte = "Z" }); // Océan entre Europe et Amérique
        q.Add(new Question { Theme = "Geographie", Texte = "Quel est le plus long fleuve du monde ?", OptionA = "Le Nil", OptionZ = "L'Amazone", OptionE = "La Seine", OptionR = "Le Danube", ReponseCorrecte = "Z" }); // Plus long fleuve
        q.Add(new Question { Theme = "Geographie", Texte = "Quelle est la capitale du Japon ?", OptionA = "Kyoto", OptionZ = "Tokyo", OptionE = "Osaka", OptionR = "Nara", ReponseCorrecte = "Z" }); // Capitale du Japon
        q.Add(new Question { Theme = "Geographie", Texte = "Combien y a-t-il de continents sur Terre ?", OptionA = "5", OptionZ = "6", OptionE = "7", OptionR = "8", ReponseCorrecte = "E" }); // Nombre de continents
        q.Add(new Question { Theme = "Geographie", Texte = "Dans quel pays se trouvent les Pyramides de Gizeh ?", OptionA = "Grèce", OptionZ = "Égypte", OptionE = "Mexique", OptionR = "Maroc", ReponseCorrecte = "Z" }); // Pays des pyramides
        q.Add(new Question { Theme = "Geographie", Texte = "Quelle est la hauteur approximative de la Tour Eiffel ?", OptionA = "230m", OptionZ = "330m", OptionE = "430m", OptionR = "530m", ReponseCorrecte = "Z" }); // Hauteur Tour Eiffel
        q.Add(new Question { Theme = "Geographie", Texte = "Quel est le point le plus profond des océans ?", OptionA = "Fosse Mariannes", OptionZ = "Abysse Java", OptionE = "Faille Porto Rico", OptionR = "Trou Bleu", ReponseCorrecte = "A" }); // Point le plus profond
        q.Add(new Question { Theme = "Geographie", Texte = "Quelle est l'altitude précise de l'Everest (mètres) ?", OptionA = "8848", OptionZ = "8888", OptionE = "8750", OptionR = "9000", ReponseCorrecte = "A", EstBoss = true }); // Altitude Everest, boss

        // --- 💻 INFORMATIQUE (10 questions) --- // Section informatique
        q.Add(new Question { Theme = "Informatique", Texte = "Que signifie RAM ?", OptionA = "Read Access Memory", OptionZ = "Random Access Memory", OptionE = "Real Access Memory", OptionR = "Rapid Access Memory", ReponseCorrecte = "Z" }); // Signification RAM
        q.Add(new Question { Theme = "Informatique", Texte = "Qui est le principal fondateur de Microsoft ?", OptionA = "Steve Jobs", OptionZ = "Bill Gates", OptionE = "Mark Zuckerberg", OptionR = "Jeff Bezos", ReponseCorrecte = "Z" }); // Fondateur Microsoft
        q.Add(new Question { Theme = "Informatique", Texte = "Quel langage est utilisé par Blazor ?", OptionA = "Python", OptionZ = "C#", OptionE = "Java", OptionR = "PHP", ReponseCorrecte = "Z" }); // Langage de Blazor
        q.Add(new Question { Theme = "Informatique", Texte = "Que signifie HTML ?", OptionA = "HyperText Mail Language", OptionZ = "HyperText Markup Language", OptionE = "HighText Markup Language", OptionR = "HomeTool Markup Language", ReponseCorrecte = "Z" }); // Signification HTML
        q.Add(new Question { Theme = "Informatique", Texte = "Quelle pièce est le 'cerveau' de l'ordinateur ?", OptionA = "Carte Graphique", OptionZ = "Processeur (CPU)", OptionE = "Disque Dur", OptionR = "Alimentation", ReponseCorrecte = "Z" }); // Cerveau de l'ordinateur
        q.Add(new Question { Theme = "Informatique", Texte = "Quel symbole désigne un ID en CSS ?", OptionA = ".", OptionZ = "#", OptionE = "@", OptionR = "&", ReponseCorrecte = "Z" }); // Symbole ID en CSS
        q.Add(new Question { Theme = "Informatique", Texte = "Quel système d'exploitation est basé sur le noyau Linux ?", OptionA = "Windows 11", OptionZ = "Ubuntu", OptionE = "macOS", OptionR = "iOS", ReponseCorrecte = "Z" }); // OS basé sur Linux
        q.Add(new Question { Theme = "Informatique", Texte = "Qui a inventé la souris d'ordinateur ?", OptionA = "Douglas Engelbart", OptionZ = "Alan Turing", OptionE = "Ada Lovelace", OptionR = "John von Neumann", ReponseCorrecte = "A" }); // Inventeur de la souris
        q.Add(new Question { Theme = "Informatique", Texte = "Quel était le nom du premier bug informatique (un vrai insecte) ?", OptionA = "Moustique", OptionZ = "Papillon de nuit", OptionE = "Cafard", OptionR = "Fourmi", ReponseCorrecte = "Z" }); // Premier bug
        q.Add(new Question { Theme = "Informatique", Texte = "En binaire, quelle est la valeur du nombre '1010' ?", OptionA = "8", OptionZ = "10", OptionE = "12", OptionR = "14", ReponseCorrecte = "Z", EstBoss = true }); // Valeur binaire 1010, boss

        // --- 🏰 HISTOIRE (10 questions) --- // Section histoire
        q.Add(new Question { Theme = "Histoire", Texte = "En quelle année a eu lieu le sacre de Charlemagne ?", OptionA = "476", OptionZ = "800", OptionE = "1515", OptionR = "1789", ReponseCorrecte = "Z" }); // Sacre de Charlemagne
        q.Add(new Question { Theme = "Histoire", Texte = "Qui était le roi de France lors de la Révolution de 1789 ?", OptionA = "Louis XIV", OptionZ = "Louis XV", OptionE = "Louis XVI", OptionR = "Charles X", ReponseCorrecte = "E" }); // Roi lors de la Révolution
        q.Add(new Question { Theme = "Histoire", Texte = "Quelle guerre a duré 116 ans ?", OptionA = "Guerre de 30 ans", OptionZ = "Guerre de 7 ans", OptionE = "Guerre de 100 ans", OptionR = "Guerres Napoléoniennes", ReponseCorrecte = "E" }); // Guerre de 100 ans
        q.Add(new Question { Theme = "Histoire", Texte = "Qui a découvert l'Amérique en 1492 ?", OptionA = "Vasco de Gama", OptionZ = "Christophe Colomb", OptionE = "Magellan", OptionR = "Jacques Cartier", ReponseCorrecte = "Z" }); // Découvreur de l'Amérique
        q.Add(new Question { Theme = "Histoire", Texte = "Quel empereur a instauré le Code Civil en 1804 ?", OptionA = "Jules César", OptionZ = "Charlemagne", OptionE = "Napoléon Ier", OptionR = "Louis-Philippe", ReponseCorrecte = "E" }); // Code Civil
        q.Add(new Question { Theme = "Histoire", Texte = "En quelle année le mur de Berlin est-il tombé ?", OptionA = "1945", OptionZ = "1961", OptionE = "1989", OptionR = "1991", ReponseCorrecte = "E" }); // Chute du mur de Berlin
        q.Add(new Question { Theme = "Histoire", Texte = "Quelle civilisation a construit les pyramides de Gizeh ?", OptionA = "Les Mayas", OptionZ = "Les Romains", OptionE = "Les Égyptiens", OptionR = "Les Grecs", ReponseCorrecte = "E" }); // Constructeurs des pyramides
        q.Add(new Question { Theme = "Histoire", Texte = "Qui était surnommé le 'Roi-Soleil' ?", OptionA = "Louis XIII", OptionZ = "Louis XIV", OptionE = "François Ier", OptionR = "Henri IV", ReponseCorrecte = "Z" }); // Roi-Soleil
        q.Add(new Question { Theme = "Histoire", Texte = "Quel pays a été envahi le 1er septembre 1939 ?", OptionA = "La France", OptionZ = "La Pologne", OptionE = "L'Autriche", OptionR = "La Russie", ReponseCorrecte = "Z" }); // Invasion de 1939
        q.Add(new Question { Theme = "Histoire", Texte = "En quelle année a été signé l'Édit de Nantes par Henri IV ?", OptionA = "1515", OptionZ = "1572", OptionE = "1598", OptionR = "1610", ReponseCorrecte = "E", EstBoss = true }); // Édit de Nantes, boss

        // --- 📚 LITTÉRATURE & ARTS (10 questions) --- // Section littérature et arts
        q.Add(new Question { Theme = "Litterature", Texte = "Qui a écrit 'Les Misérables' ?", OptionA = "Zola", OptionZ = "Flaubert", OptionE = "Hugo", OptionR = "Balzac", ReponseCorrecte = "E" }); // Auteur Les Misérables
        q.Add(new Question { Theme = "Litterature", Texte = "Quel peintre est le maître de l'Impressionnisme ?", OptionA = "Picasso", OptionZ = "Monet", OptionE = "Dali", OptionR = "Van Gogh", ReponseCorrecte = "Z" }); // Maître impressionnisme
        q.Add(new Question { Theme = "Litterature", Texte = "Qui a écrit 'Le Petit Prince' ?", OptionA = "Camus", OptionZ = "Saint-Exupéry", OptionE = "Proust", OptionR = "Sartre", ReponseCorrecte = "Z" }); // Auteur Le Petit Prince
        q.Add(new Question { Theme = "Litterature", Texte = "Quel dramaturge a écrit 'L'Avare' et 'Le Misanthrope' ?", OptionA = "Corneille", OptionZ = "Racine", OptionE = "Molière", OptionR = "Beaumarchais", ReponseCorrecte = "E" }); // Dramaturge Molière
        q.Add(new Question { Theme = "Litterature", Texte = "Qui a peint 'La Nuit Étoilée' ?", OptionA = "Manet", OptionZ = "Van Gogh", OptionE = "Gauguin", OptionR = "Cézanne", ReponseCorrecte = "Z" }); // Peintre La Nuit Étoilée
        q.Add(new Question { Theme = "Litterature", Texte = "Dans quelle ville se déroule l'intrigue de 'Roméo et Juliette' ?", OptionA = "Venise", OptionZ = "Rome", OptionE = "Vérone", OptionR = "Florence", ReponseCorrecte = "E" }); // Ville Roméo et Juliette
        q.Add(new Question { Theme = "Litterature", Texte = "Quel mouvement artistique utilise des formes géométriques ?", OptionA = "Surréalisme", OptionZ = "Cubisme", OptionE = "Romantisme", OptionR = "Baroque", ReponseCorrecte = "Z" }); // Mouvement cubisme
        q.Add(new Question { Theme = "Litterature", Texte = "Qui est l'auteur de la série de romans '1984' ?", OptionA = "Aldous Huxley", OptionZ = "George Orwell", OptionE = "Ray Bradbury", OptionR = "Isaac Asimov", ReponseCorrecte = "Z" }); // Auteur 1984
        q.Add(new Question { Theme = "Litterature", Texte = "Quel compositeur a créé la 9ème Symphonie (Hymne à la Joie) ?", OptionA = "Mozart", OptionZ = "Bach", OptionE = "Beethoven", OptionR = "Chopin", ReponseCorrecte = "E" }); // Compositeur 9ème symphonie
        q.Add(new Question { Theme = "Litterature", Texte = "Qui a écrit 'À la recherche du temps perdu' ?", OptionA = "Marcel Proust", OptionZ = "Gustave Flaubert", OptionE = "Émile Zola", OptionR = "André Gide", ReponseCorrecte = "A", EstBoss = true }); // Auteur À la recherche du temps perdu, boss

        context.Questions.AddRange(q); // Ajoute toutes les questions à la base de données en une fois
        context.SaveChanges(); // Sauvegarde les changements dans la base de données
    }
}
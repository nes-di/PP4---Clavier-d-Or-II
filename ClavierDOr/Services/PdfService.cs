// Importation des outils de QuestPDF
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System;

namespace ClavierDOr.Services;

// Le service chargé de fabriquer le PDF
public class PdfService
{
    // Cette méthode prend les infos du joueur et renvoie le fichier PDF sous forme de données (tableau d'octets)
    public byte[] GenererCertificat(string pseudo, string role, int score)
    {
        // On crée un nouveau document PDF
        var document = Document.Create(container =>
        {
            // On ajoute une page au document
            container.Page(page =>
            {
                // On définit la taille (A4) et les marges
                page.Size(PageSizes.A4);
                page.Margin(2, Unit.Centimetre);
                page.PageColor(Colors.White);
                page.DefaultTextStyle(x => x.FontSize(12).FontFamily("Arial"));

                // --- L'EN-TÊTE DU PDF ---
                page.Header().AlignCenter().Text("Le Clavier d'Or - Certificat de Réussite")
                    .SemiBold().FontSize(24).FontColor(Colors.Blue.Darken2);

                // --- LE CONTENU DU PDF ---
                // On met de l'espace vertical puis on crée une colonne pour empiler nos textes
                page.Content().PaddingVertical(1, Unit.Centimetre).Column(colonne =>
                {
                    colonne.Spacing(20); // Espace entre chaque ligne
                    
                    // On ajoute les textes personnalisés avec le pseudo, le rôle et le score
                    colonne.Item().Text($"Félicitations {pseudo} !").FontSize(20).Bold();
                    colonne.Item().Text($"Vous avez brillamment participé au grand tournoi de programmation.");
                    colonne.Item().Text($"Spécialité choisie (Rôle POO) : {role}").Italic().FontSize(14);
                    
                    // On affiche le score en gros et en vert
                    colonne.Item().Text($"Votre score final : {score} points").Bold().FontSize(18).FontColor(Colors.Green.Darken2);
                    
                    colonne.Item().Text($"Fait le {DateTime.Now:dd/MM/yyyy}"); // Date du jour automatique
                });

                // --- LE PIED DE PAGE ---
                page.Footer().AlignCenter().Text(x =>
                {
                    x.Span("Page ");
                    x.CurrentPageNumber(); // Numéro de page automatique
                });
            });
        });

        // On génère le PDF et on le renvoie sous forme de "byte[]" (données informatiques brutes)
        return document.GeneratePdf();
    }
}
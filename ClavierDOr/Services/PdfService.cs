using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System;

namespace ClavierDOr.Services;

public class PdfService
{
    public byte[] GenererCertificat(string pseudo, string role, int score)
    {
        var document = Document.Create(container =>
        {
            container.Page(page =>
            {
                page.Size(PageSizes.A4);
                page.Margin(2, Unit.Centimetre);
                page.PageColor(Colors.White);
                page.DefaultTextStyle(x => x.FontSize(12).FontFamily("Arial"));

                page.Header().AlignCenter().Text("Le Clavier d'Or - Certificat de Réussite")
                    .SemiBold().FontSize(24).FontColor(Colors.Blue.Darken2);

                page.Content().PaddingVertical(1, Unit.Centimetre).Column(colonne =>
                {
                    colonne.Spacing(20);
                    colonne.Item().Text($"Félicitations {pseudo} !").FontSize(20).Bold();
                    colonne.Item().Text($"Vous avez brillamment participé au grand tournoi de programmation.");
                    colonne.Item().Text($"Spécialité choisie (Rôle POO) : {role}").Italic().FontSize(14);
                    colonne.Item().Text($"Votre score final : {score} points").Bold().FontSize(18).FontColor(Colors.Green.Darken2);
                    colonne.Item().Text($"Fait le {DateTime.Now:dd/MM/yyyy}");
                });

                page.Footer().AlignCenter().Text(x =>
                {
                    x.Span("Page ");
                    x.CurrentPageNumber();
                });
            });
        });

        return document.GeneratePdf();
    }
}
namespace ClavierDOr.Models;

public class Question
{
    public int Id { get; set; }
    public string Theme { get; set; } = string.Empty;
    public string Texte { get; set; } = string.Empty;
    public string OptionA { get; set; } = string.Empty;
    public string OptionZ { get; set; } = string.Empty;
    public string OptionE { get; set; } = string.Empty;
    public string OptionR { get; set; } = string.Empty;
    public string ReponseCorrecte { get; set; } = string.Empty;
    public bool EstBoss { get; set; }
}
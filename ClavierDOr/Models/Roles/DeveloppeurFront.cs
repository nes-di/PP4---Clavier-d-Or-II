namespace ClavierDOr.Models.Roles;

public class DeveloppeurFront : Role
{
    public DeveloppeurFront()
    {
        Nom = "Développeur Front";
        Description = "Peut changer de question une fois par partie.";
    }

    public override string ActiverPouvoir()
    {
        PouvoirUtilise = true;
        return "Changement de question ! Une nouvelle question arrive.";
    }
}
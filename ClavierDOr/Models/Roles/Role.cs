namespace ClavierDOr.Models.Roles;

public abstract class Role
{
    public string Nom { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public bool PouvoirUtilise { get; set; } = false;
    public abstract string ActiverPouvoir();
}
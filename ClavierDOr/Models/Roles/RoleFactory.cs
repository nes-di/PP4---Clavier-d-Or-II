namespace ClavierDOr.Models.Roles;

public static class RoleFactory
{
    public static Role CreerRole(string typeRole)
    {
        if (typeRole == "Front")
        {
            return new DeveloppeurFront();
        }
        else if (typeRole == "Back")
        {
            return new DeveloppeurBack();
        }
        else if (typeRole == "Mobile")
        {
            return new DeveloppeurMobile();
        }
        else
        {
            return new DeveloppeurFront();
        }
    }
}
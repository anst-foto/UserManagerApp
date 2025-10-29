namespace UserManagerApp.Desktop.Models;

public class User
{
    public Guid Id { get; set; }
    public string LastName { get; set; }
    public string FirstName { get; set; }
    
    public string FullName => $"{LastName} {FirstName}";
    public string FullNameWithInitials => $"{LastName} {FirstName[0]}.";
    public string ShortId => Id.ToString()[..8];
}
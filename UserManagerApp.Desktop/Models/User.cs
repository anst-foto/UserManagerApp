namespace UserManagerApp.Desktop.Models;

public class User
{
    public Guid Id { get; set; }
    public string LastName { get; set; }
    public string FirstName { get; set; }

    public User(Guid id, string lastName, string firstName)
    {
        Id = id;
        LastName = lastName;
        FirstName = firstName;
    }

    public User(string lastName, string firstName)
    {
        Id = Guid.NewGuid();
        LastName = lastName;
        FirstName = firstName;
    }

    public string FullName => $"{LastName} {FirstName}";
    public string FullNameWithInitials => $"{LastName} {FirstName[0]}.";
    public string ShortId => Id.ToString()[..8];
}
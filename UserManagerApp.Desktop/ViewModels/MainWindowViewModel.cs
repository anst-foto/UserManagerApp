using System.Collections.ObjectModel;
using System.Windows.Input;
using UserManagerApp.Desktop.Models;

namespace UserManagerApp.Desktop.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private Guid? _id;
    public Guid? Id
    {
        get => _id; 
        set => SetProperty(ref _id, value);
    }

    private string? _lastName;
    public string? LastName
    {
        get => _lastName; 
        set => SetProperty(ref _lastName, value);
    }
    
    private string? _firstName;
    public string? FirstName
    {
        get => _firstName; 
        set => SetProperty(ref _firstName, value);
    }
    
    public ObservableCollection<User> Users { get; set; } = [];
    
    private User? _selectedUser;
    public User? SelectedUser
    {
        get => _selectedUser;
        set
        {
            var result = SetProperty( ref _selectedUser, value);
            if (!result) return;
            
            Id = value?.Id;
            FirstName = value?.FirstName;
            LastName = value?.LastName;
        }
    }
    
    public ICommand CommandSave { get; }
    public ICommand CommandDelete { get; }
    public ICommand CommandClear { get; }

    public MainWindowViewModel()
    {
        CommandSave = new LambdaCommand(
            execute: _ =>
            {
                Clear();
            },
            canExecute: _ => !string.IsNullOrWhiteSpace(LastName) &&
                             !string.IsNullOrWhiteSpace(FirstName));
        CommandDelete = new LambdaCommand(
            execute: _ =>
            {
                Clear();
            },
            canExecute: _ => SelectedUser != null);
        CommandClear = new LambdaCommand(
            execute: _ => Clear(),
            canExecute: _ => !string.IsNullOrWhiteSpace(LastName) ||
                             !string.IsNullOrWhiteSpace(FirstName));
    }

    private void InitUsers(IEnumerable<User> users)
    {
        Users.Clear();

        foreach (var user in users)
        {
            Users.Add(user);
        }
    }
    
    private void Clear()
    {
        Id = null;
        LastName = null;
        FirstName = null;
        
        SelectedUser = null;
    }
}
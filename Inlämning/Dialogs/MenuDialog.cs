
using Library.Factories;
using Library.Interfaces;

namespace MainApp.Dialogs;

public class MenuDialog
{
    private readonly IUserService _userService;

    public MenuDialog(IUserService userService)
    {
        _userService = userService;
    }

    public void MainMenu()
    {
        Console.WriteLine("1. Add User");
        Console.WriteLine("2. View Users");
        Console.Write("Select option: ");
        var option = Console.ReadLine();

        switch (option)
        {
            case "1":
                AddUser();
                break;

            case "2":
                ViewUsers();  
                break;
        }
    }

    public void AddUser()
    {
        var user = UserFactory.Create();
        Console.Clear();
        Console.WriteLine("Add User");
        Console.Write("Enter name: ");
        user.FirstName = Console.ReadLine()!;

        _userService.AddUser(user);
    }
    public void ViewUsers()
    {
        Console.Clear();
        Console.WriteLine("View Users");
        Console.WriteLine("1. Add new user");

        foreach (var user in _userService.ImportAllUsers()) 
            Console.WriteLine($"{user.Name}");

        Console.ReadKey();
    }

    
}


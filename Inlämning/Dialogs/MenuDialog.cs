
using Library.Factories;
using Library.Interfaces;
using Library.Services;

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
        while(true)
        {
            Console.WriteLine("1. Add User");
            Console.WriteLine("2. View Users");
            Console.WriteLine("3. Export users to file");
            Console.WriteLine("4. Import users from file");
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

                case "3":
                    ExportUsers();
                    break;

                case "4":
                    ImportUsers();
                    break;

                case "5":

                    return;
            }
        }
    }
    public void AddUser()
    {
        var user = UserFactory.Create();
        Console.Clear();
        Console.WriteLine("Add User");
        Console.Write("Enter your first name: ");
        user.FirstName = Console.ReadLine()!;
        Console.Write("Enter your last name: ");
        user.LastName = Console.ReadLine()!;
        Console.Write("Enter your email: ");
        user.Email = Console.ReadLine()!;
        Console.Write("Enter your phone number: ");
        user.PhoneNumber = Console.ReadLine()!;
        Console.Write("Enter your street name and number: ");
        user.Street = Console.ReadLine()!;
        Console.Write("Enter your zip code: ");
        user.ZipCode = Console.ReadLine()!;
        Console.Write("Enter your region: ");
        user.Region = Console.ReadLine()!;

        _userService.AddUser(user);
    }
    public void ViewUsers()
    {
        Console.Clear();
        Console.WriteLine("View Users");
        

        foreach (var user in _userService.ImportAllUsers())
        {
            Console.WriteLine($"{user.FirstName} {user.LastName}");
            Console.WriteLine($"{user.Email}");
            Console.WriteLine($"{user.PhoneNumber}");
            Console.WriteLine($"{user.Street}");
            Console.WriteLine($"{user.ZipCode} {user.Region}");
        }
            

        Console.WriteLine("5. Return to main menu");

        Console.ReadKey();
    }

    public void ExportUsers()
    {
        Console.Clear();
        Console.WriteLine("3. Export to file");

        Console.Write("Enter the directory to save the file (e.g., C:\\) ");
        string directoryPath = Console.ReadLine()!;

        Console.Write("Enter the file name (e.g., users.json): ");
        string fileName = Console.ReadLine()!;

        var fileService = new FileService(directoryPath, fileName);

        _userService.SaveContentToFile(fileService);

        Console.WriteLine($"Users have been successfully exported to {directoryPath}\\{fileName}.");
        Console.WriteLine("5. Return to main menu");
        Console.ReadKey();
    }

    public void ImportUsers()
    {
        Console.Clear();
        Console.WriteLine("4. Import from file");

        Console.Write("Enter full path to the file to import (e.g., C:\\users.json): ");
        string filePath = Console.ReadLine()!;

        _userService.ImportUsers(filePath);

        Console.WriteLine("5. Return to main menu");
        Console.ReadKey();
    }
    
}


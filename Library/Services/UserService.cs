
using System.Text.Json;
using Library.Interfaces;
using Library.Models;

namespace Library.Services;

public class UserService : IUserService
{

    private readonly IFileService _fileService;
    private List<User> _users;

    //------Chatgpt start------
    //för att skapa en automatisk importering av användare, sparar informationen i specifik mapp
    private readonly string _lastUsedFilePath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).FullName, "lastUsedFilePath.txt");
    //------Chatgpt slut------

    public UserService(IFileService fileService)
    {
        _fileService = fileService;
        _users = new List<User>();

        //------Chatgpt start------
        //för att skapa en automatisk importering av användare
        string lastUsedFile = LoadLastUsedFilePath();
        if (!string.IsNullOrEmpty(lastUsedFile))
        {
            ImportUsers(lastUsedFile);
        }
        //------Chatgpt slut------
    }

    public void AddUser(User user)
    {
        _users.Add(user);
        SaveContentToFile(_fileService);
    }

    public IEnumerable<User> ImportAllUsers()
    {
        return _users;
    }
    public void SaveContentToFile(IFileService fileService)
    {
        var json = JsonSerializer.Serialize(_users, new JsonSerializerOptions { WriteIndented = true });
        fileService.SaveContentToFile(json);
    }

    public void ImportUsers(string filePath)
    {
        if (File.Exists(filePath))
        {
            var json = File.ReadAllText(filePath);
            if (!string.IsNullOrEmpty(json))
            {
                _users = JsonSerializer.Deserialize<List<User>>(json) ?? new List<User>();
                Console.WriteLine("Users imported successfully.");

                SaveLastUsedFilePath(filePath);
            }
            else
            {
                Console.WriteLine("The file is empty.");
            }
        }
        else
        {
            Console.WriteLine("The file does not exist.");
        }
    }

    private void SaveLastUsedFilePath(string filePath)
    {
        File.WriteAllText(_lastUsedFilePath, filePath);
    }
    private string LoadLastUsedFilePath()
    {
        if (File.Exists(_lastUsedFilePath))
        {
            return File.ReadAllText(_lastUsedFilePath);
        }

        return string.Empty;
    }


}




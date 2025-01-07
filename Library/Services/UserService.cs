
using System.Text.Json;
using Library.Interfaces;
using Library.Models;

namespace Library.Services;

public class UserService(IFileService fileService) : IUserService
{
    
    private readonly IFileService _fileService = fileService;
    private List<User> _users = [];

    public void AddUser(User user)
    {
        _users.Add(user);
        SaveContentToFile();
    }

    public void AddUser(User user)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<User> ImportAllUsers()
    {
        return _users;
    }
    public void SaveContentToFile()
    {
        var json = JsonSerializer.Serialize(_users);
        _fileService.SaveContentToFile(json);
    }

    public void ImportUsers()
    {
        var json = _fileService.GetContentFromFile();
        if (!string.IsNullOrEmpty(json))
        {
            _users = JsonSerializer.Deserialize<List<User>>(json)!;
        }
    }
}

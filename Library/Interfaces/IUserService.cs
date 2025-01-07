namespace Library.Interfaces;
using Library.Models;

public interface IUserService
{
    void AddUser(User user);
    IEnumerable<User> ImportAllUsers();
    void SaveContentToFile(IFileService fileService);
    void ImportUsers(string filePath);
}

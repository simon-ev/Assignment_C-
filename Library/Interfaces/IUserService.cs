namespace Library.Interfaces;
using Library.Models;

public interface IUserService
{
    void AddContact(User user);
    IEnumerable<User> GetAllUsers();

    
}

namespace Library.Interfaces;
using Library.Models;

public interface IUserService
{
    void AddUser(User user);
    IEnumerable<User> ImportAllUsers();

    
}



using Library.Factories;
using Library.Models;

namespace C_Tests.Factories;

public class UserTestFactory
{
    [Fact]
    public void Create_ShouldReturnUser()
    {
        var result = UserFactory.Create();

        Assert.NotNull(result);
        Assert.IsType<User>(result);
    }
}

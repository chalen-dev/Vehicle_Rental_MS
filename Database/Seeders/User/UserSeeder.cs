using VRMS.Enums;
using VRMS.Services.Account;

namespace VRMS.Database.Seeders.Users;

public class UserSeeder : ISeeder
{
    public string Name => "UserSeeder";

    private readonly UserService _userService;

    private static readonly (string Username, string Password)[] Admins =
    {
        //Add more admins here
        ("Chael", "113121"),
        ("superadmin", "super123")
    };

    private static readonly (string Username, string Password)[] RentalAgents =
    {
        //Add more rental agents here
        ("agent", "agent123"),
        ("agent.john", "john123")
    };

    public UserSeeder(UserService userService)
    {
        _userService = userService;
    }

    public void Run()
    {
        SeedUsers(Admins, UserRole.Admin);
        SeedUsers(RentalAgents, UserRole.RentalAgent);
    }

    private void SeedUsers(
        (string Username, string Password)[] users,
        UserRole role
    )
    {
        foreach (var (username, password) in users)
        {
            EnsureUser(username, password, role);
        }
    }

    private void EnsureUser(
        string username,
        string password,
        UserRole role
    )
    {
        try
        {
            _userService.GetByUsername(username);
        }
        catch
        {
            _userService.CreateUser(
                username,
                password,
                role,
                isActive: true
            );
        }
    }
}
using System.Data;
using VRMS.Database;
using VRMS.Enums;
using VRMS.Helpers.Security;
using VRMS.Models.Accounts;

namespace VRMS.Services.Account;

public class UserService
{
    // ----------------------------
    // AUTHENTICATION
    // ----------------------------

    public User Authenticate(string username, string plainPassword)
    {
        var table = DB.Query(
            "CALL sp_users_authenticate(@username);",
            ("@username", username)
        );

        if (table.Rows.Count == 0)
            throw new InvalidOperationException("Invalid username or inactive account.");

        var row = table.Rows[0];
        var storedHash = row["password_hash"].ToString()!;

        if (!VerifyPassword(plainPassword, storedHash))
            throw new InvalidOperationException("Invalid password.");

        return MaterializeUser(row);
    }

    // ----------------------------
    // CREATE USER
    // ----------------------------

    public int CreateUser(
        string username,
        string plainPassword,
        UserRole role,
        bool isActive = true
    )
    {
        var hash = Password.Hash(plainPassword);

        var table = DB.Query(
            "CALL sp_users_create(@username, @hash, @role, @active);",
            ("@username", username),
            ("@hash", hash),
            ("@role", role.ToString()),
            ("@active", isActive)
        );

        return Convert.ToInt32(table.Rows[0]["user_id"]);
    }

    // ----------------------------
    // LOOKUPS
    // ----------------------------

    public User GetById(int userId)
    {
        var table = DB.Query(
            "CALL sp_users_get_by_id(@id);",
            ("@id", userId)
        );

        if (table.Rows.Count == 0)
            throw new InvalidOperationException("User not found.");

        return MaterializeUser(table.Rows[0]);
    }

    public User GetByUsername(string username)
    {
        var table = DB.Query(
            "CALL sp_users_get_by_username(@username);",
            ("@username", username)
        );

        if (table.Rows.Count == 0)
            throw new InvalidOperationException("User not found.");

        return MaterializeUser(table.Rows[0]);
    }

    // ----------------------------
    // DEACTIVATE
    // ----------------------------

    public void Deactivate(int userId)
    {
        DB.Execute(
            "CALL sp_users_deactivate(@id);",
            ("@id", userId)
        );
    }

    // ----------------------------
    // PASSWORD MANAGEMENT
    // ----------------------------

    public void ChangePassword(
        int userId,
        string currentPlainPassword,
        string newPlainPassword
    )
    {
        var user = GetById(userId);

        if (!VerifyPassword(currentPlainPassword, user.PasswordHash))
            throw new InvalidOperationException("Current password is incorrect.");

        var newHash = Password.Hash(newPlainPassword);

        DB.Execute(
            "CALL sp_users_update_password(@id, @hash);",
            ("@id", userId),
            ("@hash", newHash)
        );
    }

    // ----------------------------
    // PROFILE MANAGEMENT
    // ----------------------------

    public void UpdateUserProfile(
        int userId,
        string username,
        UserRole role,
        bool isActive
    )
    {
        if (string.IsNullOrWhiteSpace(username))
            throw new InvalidOperationException("Username cannot be empty.");

        DB.Execute(
            "CALL sp_users_update_profile(@id, @username, @role, @active);",
            ("@id", userId),
            ("@username", username),
            ("@role", role.ToString()),
            ("@active", isActive)
        );
    }

    // ----------------------------
    // INTERNAL HELPERS
    // ----------------------------

    private static User MaterializeUser(DataRow row)
    {
        var role = Enum.Parse<UserRole>(row["role"].ToString()!, true);

        User user = role switch
        {
            UserRole.Admin => new Admin(),
            UserRole.RentalAgent => new RentalAgent(),
            _ => throw new InvalidOperationException("Unknown user role.")
        };

        user.Id = Convert.ToInt32(row["id"]);
        user.Username = row["username"].ToString()!;
        user.PasswordHash = row["password_hash"].ToString()!;
        user.Role = role;
        user.IsActive = Convert.ToBoolean(row["is_active"]);

        return user;
    }

    // ----------------------------
    // PASSWORD SECURITY
    // ----------------------------

    private static bool VerifyPassword(string plain, string hash)
    {
        return Password.Verify(plain, hash);
    }

}

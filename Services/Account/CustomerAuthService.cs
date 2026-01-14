using VRMS.Helpers;
using VRMS.Models.Accounts;
using VRMS.Repositories.Accounts;

public class CustomerAuthService
{
    private readonly CustomerAccountRepository _repo;

    public CustomerAuthService(CustomerAccountRepository repo)
    {
        _repo = repo;
    }

    public CustomerAccount Authenticate(string username, string password)
    {
        var account = _repo.GetByUsername(username)
                      ?? throw new InvalidOperationException("Invalid credentials.");

        if (!account.IsEnabled)
            throw new InvalidOperationException("Account is disabled.");

        if (!PasswordHelper.Verify(password, account.PasswordHash))
            throw new InvalidOperationException("Invalid credentials.");

        return account;
    }
}
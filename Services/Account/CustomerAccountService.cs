using System;
using VRMS.Enums;
using VRMS.Helpers;
using VRMS.Models.Accounts;
using VRMS.Repositories.Accounts;
using VRMS.UI.Config.Support;

namespace VRMS.Services.Account;

public class CustomerAccountService
{
    private readonly CustomerAccountRepository _repo;

    public CustomerAccountService(CustomerAccountRepository repo)
    {
        _repo = repo;
    }

    // =====================================================
    // CREATE
    // =====================================================

    public int CreateAccount(
        int customerId,
        string username,
        string plainPassword)
    {
        EnsureAgent();

        if (string.IsNullOrWhiteSpace(username))
            throw new InvalidOperationException(
                "Username cannot be empty.");

        if (string.IsNullOrWhiteSpace(plainPassword))
            throw new InvalidOperationException(
                "Password cannot be empty.");

        var existing =
            _repo.GetByCustomerId(customerId);

        if (existing != null)
            throw new InvalidOperationException(
                "Customer already has a login account.");

        var passwordHash =
            PasswordHelper.Hash(plainPassword);

        var agentId =
            Session.CurrentUser!.Id;

        return _repo.Create(
            customerId,
            username,
            passwordHash,
            agentId);
    }

    // =====================================================
    // READ
    // =====================================================

    public CustomerAccount? GetByCustomerId(int customerId)
    {
        EnsureAgent();
        return _repo.GetByCustomerId(customerId);
    }

    // =====================================================
    // STATUS (UI FRIENDLY)
    // =====================================================

    public AccountStatus GetAccountStatus(int customerId)
    {
        var account = _repo.GetByCustomerId(customerId);

        if (account == null)
            return AccountStatus.NotCreated;

        return account.IsEnabled
            ? AccountStatus.Active
            : AccountStatus.Disabled;
    }

    // =====================================================
    // PASSWORD RESET
    // =====================================================

    public void ResetPassword(
        int accountId,
        string newPlainPassword)
    {
        EnsureAgent();

        if (string.IsNullOrWhiteSpace(newPlainPassword))
            throw new InvalidOperationException(
                "Password cannot be empty.");

        var hash =
            PasswordHelper.Hash(newPlainPassword);

        _repo.UpdatePassword(
            accountId,
            hash);
    }

    // =====================================================
    // DISABLE
    // =====================================================

    public void DisableAccount(int accountId)
    {
        EnsureAgent();
        _repo.Disable(accountId);
    }

    // =====================================================
    // HELPERS
    // =====================================================

    private static void EnsureAgent()
    {
        if (Session.CurrentUser == null)
            throw new InvalidOperationException(
                "User is not logged in.");

        // Only internal users manage customer accounts
        // (Admin or RentalAgent)
    }
}

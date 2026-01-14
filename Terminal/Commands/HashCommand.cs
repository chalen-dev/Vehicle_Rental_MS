using VRMS.Helpers;
using VRMS.Terminal;

namespace VRMS.Terminal.Commands;

public class HashCommand : ICommand
{
    public string Name => "hash";

    public CommandResult Execute(string[] args)
    {
        if (args.Length == 0)
        {
            return new CommandResult(
                false,
                "Usage: dotnet run hash <text>"
            );
        }

        // Support spaces: hash my password here
        var input = string.Join(" ", args);

        try
        {
            var hash = PasswordHelper.Hash(input);
            return new CommandResult(true, hash);
        }
        catch (Exception ex)
        {
            return new CommandResult(false, ex.Message);
        }
    }
}
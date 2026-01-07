using VRMS.Terminal.Commands;

namespace VRMS.Terminal;

public static class CommandDispatcher
{
    private static readonly List<ICommand> Commands = new()
    {
        new MigrateCommand(),
        new DropCommand(),
        new FreshCommand()
    };

    public static bool TryExecute(string[] args, out CommandResult? result)
    {
        result = null;

        if (args.Length == 0)
            return false;

        var command = Commands.FirstOrDefault(c =>
            c.Name.Equals(args[0], StringComparison.OrdinalIgnoreCase));

        if (command == null)
        {
            result = new CommandResult(false, $"Unknown command: {args[0]}");
            return true;
        }

        result = command.Execute();
        return true;
    }

}
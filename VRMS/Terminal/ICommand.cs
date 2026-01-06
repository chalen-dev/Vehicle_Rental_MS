namespace VRMS.Terminal;

public interface ICommand
{
    string Name { get; }
    void Execute();
}
namespace VRMS.Helpers.SqlEscape;

public static class Sql
{
    public static string Esc(string input)
        => input.Replace("'", "''");
}

namespace VRMS.Helpers;

public static class EnumComboHelper
{
    /// <summary>
    /// Converts an enum into a list usable by WinForms ComboBox
    /// with clean, spaced display names.
    /// </summary>
    public static List<EnumComboItem<TEnum>> ToComboItems<TEnum>()
        where TEnum : Enum
    {
        return Enum.GetValues(typeof(TEnum))
            .Cast<TEnum>()
            .Select(e => new EnumComboItem<TEnum>
            {
                Value = e,
                Display = FormatEnumName(e.ToString())
            })
            .ToList();
    }

    /// <summary>
    /// Converts "RoutineService" -> "Routine Service"
    /// </summary>
    private static string FormatEnumName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            return name;

        var result = new System.Text.StringBuilder();
        result.Append(name[0]);

        for (int i = 1; i < name.Length; i++)
        {
            if (char.IsUpper(name[i]) && !char.IsUpper(name[i - 1]))
                result.Append(' ');

            result.Append(name[i]);
        }

        return result.ToString();
    }
}

public class EnumComboItem<TEnum>
    where TEnum : Enum
{
    public TEnum Value { get; set; }
    public string Display { get; set; }
}
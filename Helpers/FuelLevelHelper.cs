using VRMS.Enums;

namespace VRMS.Helpers;

public static class FuelLevelHelper
{
    public static string ToDisplay(FuelLevel level)
    {
        return level switch
        {
            FuelLevel.Empty => "Empty",
            FuelLevel.Quarter => "1/4",
            FuelLevel.Half => "1/2",
            FuelLevel.ThreeQuarters => "3/4",
            FuelLevel.Full => "Full",
            _ => level.ToString()
        };
    }

    public static FuelLevel FromDisplay(string display)
    {
        return display switch
        {
            "Empty" => FuelLevel.Empty,
            "1/4" => FuelLevel.Quarter,
            "1/2" => FuelLevel.Half,
            "3/4" => FuelLevel.ThreeQuarters,
            "Full" => FuelLevel.Full,
            _ => throw new ArgumentOutOfRangeException(
                nameof(display),
                $"Unknown fuel level display value: {display}")
        };
    }
}
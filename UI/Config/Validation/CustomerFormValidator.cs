namespace VRMS.UI.Config.Validation;

public static class CustomerFormValidator
{
    public static void ValidateBasicInfo(
        string firstName,
        string lastName,
        DateTime dob,
        DateTime issueDate,
        DateTime expiryDate)
    {
        if (string.IsNullOrWhiteSpace(firstName))
            throw new InvalidOperationException("First name required");

        if (string.IsNullOrWhiteSpace(lastName))
            throw new InvalidOperationException("Last name required");

        if (GetAge(dob) < 21)
            throw new InvalidOperationException("Customer must be at least 21");

        if (expiryDate <= issueDate)
            throw new InvalidOperationException(
                "License expiry must be after issue date");
    }

    private static int GetAge(DateTime dob)
    {
        var today = DateTime.Today;
        int age = today.Year - dob.Year;
        if (dob > today.AddYears(-age)) age--;
        return age;
    }
}
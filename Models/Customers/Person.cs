namespace VRMS.Models.Customers;

public abstract class Person
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName  { get; set; } = string.Empty;
    
    
    public string FullName => $"{FirstName} {LastName}";
}
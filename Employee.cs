namespace apbd_proj_3;

public class Employee : Person
{
    public Employee(string firstName, string lastName) : base(firstName, lastName)
    {
    }

    public override int MaxRentCount { get; } = 5;
}
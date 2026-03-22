namespace apbd_proj_3;

public class Student : Person

{
    

    public Student(string firstName, string lastName) : base(firstName, lastName)
    {
    }

    public override int MaxRentCount { get; } = 2;
}
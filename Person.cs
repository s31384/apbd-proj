namespace apbd_proj_3;

public abstract class Person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    
    public bool CanRent { get; set; } = true;
    public int Id { get; }
    private static int _nextId = 1;
    public abstract int MaxRentCount { get; }
    public int DelayedReturnsCount { get; set; } = 0;
    public int ActiveRentsCount { get; set; } = 0;

    public Person(string firstName, string lastName)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Id = _nextId++;
    }
}
namespace apbd_proj_3;

public abstract class Device
{
    private static int _nextId = 1;
    public double Price { get; set; }
    public bool IsAvailable { get; set;}
    public string Model { get; set;}    
    public int Id { get; set;}
    public Device(double price, bool isAvailable, string model)
    {
        this.Price = price;
        this.IsAvailable = isAvailable;
        this.Model = model;
        this.Id = _nextId++;
    }
    

}
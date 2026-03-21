namespace apbd_proj_3;

public class Laptop : Device
{
    public double ScreenDiagonal{get; set;}
    public int ScreenFrequency{get; set;}
    public Laptop(double price, bool isAvailable, string model, double screenDiagonal, int screenFrequency) : base(price, isAvailable, model)
    {
        this.ScreenDiagonal = screenDiagonal;
        this.ScreenFrequency = screenFrequency;
    }
}
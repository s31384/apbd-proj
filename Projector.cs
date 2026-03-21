namespace apbd_proj_3;

public class Projector : Device
{
    public double ThrowRatio{get; set;}
    
    public int Brightness{get; set;}
    public Projector(double price, bool isAvailable, string model, double throwRatio, int brightness) : base(price, isAvailable, model)
    {
        this.ThrowRatio = throwRatio;
        this.Brightness = brightness;
    }
    
}
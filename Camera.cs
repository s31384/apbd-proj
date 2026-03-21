namespace apbd_proj_3;

public class Camera : Device
{
    public double DiaphragmSize { get; set; }
    public int Resolution { get; set; }
    public Camera(double price, bool isAvailable, string model, double diaphragmSize, int resolution) : base(price, isAvailable, model)
    {
        this.DiaphragmSize = diaphragmSize;
        this.Resolution = resolution;
    }
}
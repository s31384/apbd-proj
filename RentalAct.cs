namespace apbd_proj_3;

public class RentalAct
{
    public int DeviceId { get; set; }
    public int UserId { get; set; }
    public DateTime RentalStartDate { get; set; }
    public DateTime RentalEndDate { get; set; }
    public bool ReturnedInTime { get; set; } = true;
    public DateTime? ReturnDate { get; set;}

    public RentalAct(int userId, int deviceId, DateTime rentalStartDate, DateTime rentalEndDate)
    {
        this.DeviceId = deviceId;
        this.UserId = userId;   
        this.RentalStartDate = rentalStartDate;
        this.RentalEndDate = rentalEndDate;
    }

    public override string ToString()
    {
        return $"Device ID: {this.DeviceId} User ID: {this.UserId} From: {this.RentalStartDate.ToShortDateString()} To: {this.RentalEndDate.ToShortDateString()} In time: {this.ReturnedInTime}";
    }
}
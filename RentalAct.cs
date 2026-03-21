namespace apbd_proj_3;

public class RentalAct
{
    public int DeviceId { get; set; }
    public int UserId { get; set; }
    public DateTime RentalStartDate { get; set; }
    public DateTime RentalEndDate { get; set; }
    public bool ReturnedInTime { get; set; }
    public DateTime? ReturnDate
    {
        get;
        set
        {
            ReturnDate =  value;
            if ( ReturnDate > RentalEndDate)
            {
                ReturnedInTime = false;
            }else ReturnedInTime = true;
        }
    }

    public RentalAct(int deviceId, int userId, DateTime rentalStartDate, DateTime rentalEndDate)
    {
        this.DeviceId = deviceId;
        this.UserId = userId;   
        this.RentalStartDate = rentalStartDate;
        this.RentalEndDate = rentalEndDate;
    }
    
}
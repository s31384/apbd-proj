namespace apbd_proj_3;

public class RentalService
{
    private List<Device> devices;
    private List<RentalAct>  rentalActs;
    public UserService UserService;
    public RentalService(UserService userService)
    {
        this.UserService = userService;
        devices = new List<Device>();
        rentalActs = new List<RentalAct>();
    }
    public void AddDevice(Device device){
        this.devices.Add(device);}

    public bool IsDeviceAvailaible(int DeviceId)
    {
        if (!this.devices.Any(x => x.Id == DeviceId))
        {
            throw new Exception("Device not found");
        }
        return this.devices.Find(d => d.Id == DeviceId).IsAvailable;
    }

    public void rentDevice(int UserID, int DeviceID, string dateFromString, string dateToSting)
    {
            if (!IsDeviceAvailaible(DeviceID))
            {throw new Exception("Device is not availaible");
            }

            if (!UserService.IsUserCanRent(UserID))
            {
                throw new Exception("User is banned");
            }
            DateTime dateFrom;
            DateTime dateTo;
            try
            {
                dateFrom = DateTime.Parse(dateFromString);
                dateTo = DateTime.Parse(dateToSting);
            }
            catch (FormatException)
            {
                throw new Exception("Invalid date");
            }

            if (dateFrom > dateTo)
            {
                throw new Exception("Date from must be before date to");
            }
            if (!UserService.isThisUserExists(UserID))
            {
                throw new Exception("User not found");
            }

            if (UserService.IsLimitExceeded(UserID))
            {
                throw new Exception("Users limit is exceeded");
            }
            
            devices.Find(d => d.Id == DeviceID).IsAvailable = false;
            rentalActs.Add(new RentalAct(UserID, DeviceID, dateFrom, dateTo));
            UserService.IncreaseRentAct(UserID);
            Console.WriteLine($"{DeviceID} has been rented by {UserID}");
    }
    public void returnDevice(int UserID, int DeviceID, string returnDateString)
    {
        if (!rentalActs.Any(x => x.UserId == UserID && x.DeviceId == DeviceID))
        {
            throw new Exception("No rental acts found from this user or with this device");
        }
        RentalAct rentalAct = rentalActs.Find(x => x.UserId == UserID && x.DeviceId == DeviceID);

        DateTime ReturnDate;
        try
        {
            ReturnDate = DateTime.Parse(returnDateString);
        }catch(FormatException)
        {
            throw new Exception("Invalid date");
        }

        if (ReturnDate < rentalAct.RentalStartDate)
        {
            throw new Exception("Rental start date must cant be before the rental start date");
        }
        rentalAct.ReturnDate = ReturnDate;
        if (!rentalAct.ReturnedInTime)
        {
            UserService.PunishUser(UserID);
        }
        UserService.DecreaseRentAct(UserID);
        devices.Find(x => x.Id == DeviceID).IsAvailable=true;
        rentalActs.Remove(rentalAct);
    }

    public void setRentOverdue(int UserID, int DeviceID)
    {
        if (!rentalActs.Any(x => x.UserId == UserID && x.DeviceId == DeviceID))
        {
            throw new Exception("No rental acts found from this user or with this device");
        }
        rentalActs.Find(x => x.UserId == UserID && x.DeviceId == DeviceID).ReturnedInTime=false;
    }

    public void showOverdueRents()
    {
        foreach (var rental in rentalActs)
        {
            if (!rental.ReturnedInTime)
            {
                Console.WriteLine(rental);
            }
        }
    }

    public void setStatusForDevice(int DeviceId, bool status)
    {
        if (!this.devices.Any(x => x.Id == DeviceId))
        {
            throw new Exception("Device not found");
        }
        devices.Find(x => x.Id == DeviceId).IsAvailable = status;
    }
    
    public void showAllDevices(){
        foreach (var device in devices)
        {
            Console.WriteLine(device);
        }}

    public void showAvailibleDevices()
    {
        foreach (var device in devices)
        {
            if (!device.IsAvailable)
            {
                Console.WriteLine(device);
            }
        }
    }

    public void showAllRentsForUser(int UserID)
    {
        if (!rentalActs.Any(x => x.UserId == UserID))
        {
            Console.WriteLine("No rental acts found");
            
        }
        else
        {
            foreach (var rentalAct in rentalActs)
            {
                if (rentalAct.UserId == UserID)
                {
                    Console.WriteLine(rentalAct);
                }
            }
        }
    }

    public void report()
    {
        Console.WriteLine($"Devices: {this.devices.Count}");
        int availibleDevices = devices.FindAll(x => x.IsAvailable).Count;
        int notAvailibleDevices = devices.FindAll(x => !x.IsAvailable).Count;
        Console.WriteLine($"Available devices: {availibleDevices}");
        Console.WriteLine($"Not available devices: {notAvailibleDevices}");
        Console.WriteLine($"Rental acts: {rentalActs.Count}");
        int overdueRentalActs = rentalActs.FindAll(x => !x.ReturnedInTime).Count;
        Console.WriteLine($"Overdue rental acts: {overdueRentalActs}");
    }
    
    

    
    
    
}
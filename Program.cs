using apbd_proj_3;

UserService userService = new UserService();
RentalService rentalService = new RentalService(userService);

userService.addPerson(new Student("Lisa","Simpson"));
userService.addPerson(new Employee("Bart","Simpson"));
rentalService.AddDevice(new Camera(100,true,"canon",1,54));
rentalService.AddDevice(new Laptop(150,true,"asus",5.6,5400));
rentalService.AddDevice(new Projector(200,true,"sony",3,1000));
rentalService.AddDevice(new Projector(200,true,"sony",3,1000));

rentalService.rentDevice(1,1, "2000-12-12", "2000-12-13");

rentalService.showAllRentsForUser(1);
try
{
    rentalService.rentDevice(2, 1, "2000-12-12", "2000-12-13");
}
catch(Exception ex)
{
    Console.WriteLine(ex.Message);
}

rentalService.returnDevice(1,1,"2000-12-12");

rentalService.showAllRentsForUser(1);

rentalService.rentDevice(2,1, "2000-12-12", "2000-12-13");
rentalService.rentDevice(2,2, "2000-12-12", "2000-12-13");
rentalService.rentDevice(2,3, "2000-12-12", "2000-12-13");
rentalService.rentDevice(2,4, "2000-12-12", "2000-12-13");

rentalService.setRentOverdue(2,1);
rentalService.setRentOverdue(2,2);
rentalService.setRentOverdue(2,3);
rentalService.setRentOverdue(2,4);

rentalService.returnDevice(2,1,"2000-12-15");
rentalService.returnDevice(2,2,"2000-12-15");
rentalService.returnDevice(2,3,"2000-12-15");
rentalService.returnDevice(2,4,"2000-12-15");

try
{
    rentalService.rentDevice(2,1, "2000-12-12", "2000-12-13");

}catch(Exception ex)
{
    Console.WriteLine(ex.Message);
}

rentalService.rentDevice(1,2, "2000-12-12", "2000-12-13");
rentalService.rentDevice(1,3, "2000-12-12", "2000-12-13");

rentalService.setRentOverdue(1,2);

rentalService.report();

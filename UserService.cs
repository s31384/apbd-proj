namespace apbd_proj_3;

public class UserService
{
    private List<Person> users;

    public UserService()
    {
        users = new List<Person>();

    }

    public void addPerson(Person person)
    {
        users.Add(person);
    }
    
    public bool isThisUserExists(int id)
    {
        return users.Any(x => x.Id == id);
    }

    public void IncreaseRentAct(int UserId)
    {
        if (!isThisUserExists(UserId))
        {
            throw new Exception("User not found");
        }
        Person person = users.Find(x => x.Id == UserId);
        person.ActiveRentsCount++;
    }
    public void DecreaseRentAct(int UserId)
    {
        if (!isThisUserExists(UserId))
        {
            throw new Exception("User not found");
        }
        Person person = users.Find(x => x.Id == UserId);
        person.ActiveRentsCount--;
    }

    public bool IsLimitExceeded(int UserId)
    {
        if (!isThisUserExists(UserId))
        {
            throw new Exception("User not found");
        }
        Person person = users.Find(x => x.Id == UserId);
        return person.ActiveRentsCount >= person.MaxRentCount;
    }

    public bool IsUserCanRent(int UserId)
    {
        if (!isThisUserExists(UserId))
        {
            throw new Exception("User not found");}
        Person person = users.Find(x => x.Id == UserId);
        return person.CanRent;
    }

    public void PunishUser(int UserId)
    {
        if (!isThisUserExists(UserId))
        {
            throw new Exception("User not found");
        }
        Person person = users.Find(x => x.Id == UserId);

        if (person.DelayedReturnsCount >= 3)
        {
            person.CanRent = false;
        }
        else
        {
            person.DelayedReturnsCount++;
        }
    }
    

}
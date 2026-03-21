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
}
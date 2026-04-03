using System;
using System.Collections.Generic;
using System.Linq;

// ===== Entity =====
public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
}

// ===== Repository Interface =====
public interface IUserRepository
{
    List<User> GetAll();
    User GetById(int id);
    void Add(User user);
}

// ===== Concrete Repository (In-Memory DB) =====
public class UserRepository : IUserRepository
{
    private List<User> _users = new List<User>();

    public List<User> GetAll()
    {
        return _users;
    }

    public User GetById(int id)
    {
        return _users.FirstOrDefault(u => u.Id == id);
    }

    public void Add(User user)
    {
        _users.Add(user);
    }
}

// ===== Business Layer =====
public class UserService
{
    private readonly IUserRepository _repository;

    public UserService(IUserRepository repository)
    {
        _repository = repository;
    }

    public void AddUser(string name, int age)
    {
        var user = new User
        {
            Id = new Random().Next(1, 1000),
            Name = name,
            Age = age
        };

        _repository.Add(user);
    }

    public List<User> GetAdults()
    {
        return _repository.GetAll().Where(u => u.Age >= 18).ToList();
    }
}

// ===== Main =====
class Program
{
    static void Main()
    {
        IUserRepository repo = new UserRepository();
        UserService service = new UserService(repo);

        service.AddUser("Alice", 20);
        service.AddUser("Bob", 15);

        var adults = service.GetAdults();

        foreach (var user in adults)
        {
            Console.WriteLine(user.Name);
        }
    }
}

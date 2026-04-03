using System;

// ===== Abstract Products =====
public interface IDatabaseConnection
{
    void Connect();
}

public interface IDatabaseCommand
{
    void Execute();
}

// ===== Concrete Products (MySQL) =====
public class MySqlConnection : IDatabaseConnection
{
    public void Connect()
    {
        Console.WriteLine("Connected to MySQL");
    }
}

public class MySqlCommand : IDatabaseCommand
{
    public void Execute()
    {
        Console.WriteLine("Executing MySQL Query");
    }
}

// ===== Concrete Products (MongoDB) =====
public class MongoConnection : IDatabaseConnection
{
    public void Connect()
    {
        Console.WriteLine("Connected to MongoDB");
    }
}

public class MongoCommand : IDatabaseCommand
{
    public void Execute()
    {
        Console.WriteLine("Executing MongoDB Query");
    }
}

// ===== Abstract Factory =====
public interface IDatabaseFactory
{
    IDatabaseConnection CreateConnection();
    IDatabaseCommand CreateCommand();
}

// ===== Concrete Factories =====
public class MySqlFactory : IDatabaseFactory
{
    public IDatabaseConnection CreateConnection()
    {
        return new MySqlConnection();
    }

    public IDatabaseCommand CreateCommand()
    {
        return new MySqlCommand();
    }
}

public class MongoFactory : IDatabaseFactory
{
    public IDatabaseConnection CreateConnection()
    {
        return new MongoConnection();
    }

    public IDatabaseCommand CreateCommand()
    {
        return new MongoCommand();
    }
}

// ===== Client =====
class Program
{
    static void Main()
    {
        IDatabaseFactory factory;

        string dbType = "mysql"; // change to "mongo" to test

        if (dbType == "mysql")
            factory = new MySqlFactory();
        else
            factory = new MongoFactory();

        // Create related objects from the factory
        IDatabaseConnection connection = factory.CreateConnection();
        IDatabaseCommand command = factory.CreateCommand();

        connection.Connect();
        command.Execute();

        Console.ReadLine();
    }
}

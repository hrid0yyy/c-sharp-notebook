using System;

// Existing Strategy Interface
public interface IAIProvider
{
    string GenerateResponse(string prompt);
}

// Existing working provider
public class OpenAIProvider : IAIProvider
{
    public string GenerateResponse(string prompt)
    {
        return "OpenAI response: " + prompt;
    }
}

// ❌ Incompatible class (cannot change it)
public class NewModelProvider
{
    public string GetAnswer(string input)
    {
        return "NewModel says: " + input;
    }
}

// ✅ Adapter
public class NewModelAdapter : IAIProvider
{
    private NewModelProvider _newModel;

    public NewModelAdapter(NewModelProvider newModel)
    {
        _newModel = newModel;
    }

    public string GenerateResponse(string prompt)
    {
        // Convert call to match expected interface
        return _newModel.GetAnswer(prompt);
    }
}

// Context
public class Agent
{
    private IAIProvider _provider;

    public Agent(IAIProvider provider)
    {
        _provider = provider;
    }

    public void Ask(string prompt)
    {
        Console.WriteLine(_provider.GenerateResponse(prompt));
    }
}

// Main
class Program
{
    static void Main()
    {
        var newModel = new NewModelProvider();
        IAIProvider adapter = new NewModelAdapter(newModel);

        Agent agent = new Agent(adapter);
        agent.Ask("Hello");

        Console.ReadLine();
    }
}

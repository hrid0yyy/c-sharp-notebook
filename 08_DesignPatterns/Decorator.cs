using System;
using System.Collections.Generic;

// 1. Interface
public interface IAIProvider
{
    string GenerateResponse(string prompt);
}

// 2. Concrete Class
public class OpenAIProvider : IAIProvider
{
    public string GenerateResponse(string prompt)
    {
        return "Response: " + prompt;
    }
}

// 3. Base Decorator
public abstract class AIProviderDecorator : IAIProvider
{
    protected IAIProvider _provider;

    public AIProviderDecorator(IAIProvider provider)
    {
        _provider = provider;
    }

    public virtual string GenerateResponse(string prompt)
    {
        return _provider.GenerateResponse(prompt);
    }
}

// 4. Logging Decorator
public class LoggingDecorator : AIProviderDecorator
{
    public LoggingDecorator(IAIProvider provider) : base(provider) {}

    public override string GenerateResponse(string prompt)
    {
        Console.WriteLine("[LOG] Prompt: " + prompt);
        return base.GenerateResponse(prompt);
    }
}

// 5. Caching Decorator
public class CachingDecorator : AIProviderDecorator
{
    private Dictionary<string, string> _cache = new Dictionary<string, string>();

    public CachingDecorator(IAIProvider provider) : base(provider) {}

    public override string GenerateResponse(string prompt)
    {
        if (_cache.ContainsKey(prompt))
        {
            Console.WriteLine("[CACHE HIT]");
            return _cache[prompt];
        }

        var response = base.GenerateResponse(prompt);
        _cache[prompt] = response;
        return response;
    }
}

// 6. Main Program
class Program
{
    static void Main()
    {
        // Base provider
        IAIProvider provider = new OpenAIProvider();

        // Add decorators dynamically
        provider = new LoggingDecorator(provider);
        provider = new CachingDecorator(provider);

        Console.WriteLine(provider.GenerateResponse("Hello"));
        Console.WriteLine(provider.GenerateResponse("Hello")); // should hit cache

        Console.ReadLine();
    }
}

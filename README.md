# 🚀 C# Core Concepts – Complete Developer Roadmap

This repository serves as a **comprehensive learning and reference guide** for mastering **C# and .NET**.  
It covers **fundamental to advanced concepts** that every C# developer should know for **real-world projects, interviews, and professional growth**.

## 📌 Who Is This For?

- Beginners learning C# fundamentals  
- Intermediate developers strengthening core concepts  
- Job seekers preparing for **C# / .NET interviews**  
- Developers building **ASP.NET Core applications**

---

## 🧱 1. Core C# Fundamentals

- Data Types (Value vs Reference)
- Variables, Constants, `var`
- Control Flow (`if`, `switch`, loops)
- Methods & Parameters (`ref`, `out`, `in`)
- Exception Handling (`try-catch-finally`)
- `enum`, `struct`, `readonly`
- `null`, `Nullable<T>`, `?.`, `??`

---

## 🧠 2. Object-Oriented Programming (OOP)

- Classes & Objects
- Encapsulation
- Inheritance
- Polymorphism
- Abstraction
- Interfaces vs Abstract Classes
- Method Overloading vs Overriding
- `virtual`, `override`, `sealed`, `base`

---

## 💾 3. Memory Management & Type System

- Stack vs Heap
- Value Types vs Reference Types
- Garbage Collection (GC)
- `IDisposable` & `using`
- `record` vs `class` vs `struct`
- Immutability
- Boxing & Unboxing

---

## 📦 4. Collections & Generics

- `List<T>`, `Dictionary<TKey,TValue>`
- `HashSet<T>`, `Queue<T>`, `Stack<T>`
- `IEnumerable`, `ICollection`, `IList`
- Generics & Constraints
- Custom Collections

---

## 🔍 5. LINQ (Language Integrated Query)

- LINQ to Objects
- `Select`, `Where`, `Join`, `GroupBy`
- Projection & Aggregation
- Deferred vs Immediate Execution
- `IEnumerable` vs `IQueryable`
- Performance Considerations

---

## 🔁 6. Delegates, Events & Functional Programming

- Delegates & Multicast Delegates
- Events
- `Func<>`, `Action<>`, `Predicate<>`
- Lambda Expressions
- Anonymous Methods

---

## ⚡ 7. Asynchronous & Parallel Programming

- `async` / `await`
- `Task` vs `Thread`
- Task Parallel Library (TPL)
- `Parallel.For`, `Parallel.ForEach`
- Thread Safety
- `lock`, `Monitor`, `SemaphoreSlim`
- Deadlocks & Best Practices

---

## 🚨 8. Exception Handling & Logging

- Custom Exceptions
- Global Exception Handling
- Logging (`ILogger`, Serilog, NLog)
- Retry & Fault Tolerance

---

## ⚙️ 9. .NET Runtime & Ecosystem

- CLR (Common Language Runtime)
- CTS & CLS
- Assemblies & DLLs
- JIT Compilation
- NuGet Packages
- SDK vs Runtime

---

## 📁 10. File Handling & Serialization

- File & Directory I/O
- Streams
- JSON Serialization (`System.Text.Json`)
- XML Serialization
- Binary Serialization (Basics)

---

## 🧩 11. Dependency Injection & Clean Code

- Dependency Injection (DI)
- Inversion of Control (IoC)
- SOLID Principles
- Clean Architecture
- Separation of Concerns

---

## 🏗️ 12. Design Patterns

- Singleton
- Factory
- Repository
- Strategy
- Observer
- Unit of Work
- MVC / MVVM

---

## 🌐 13. ASP.NET Core (Web Development)

- Middleware
- MVC vs Minimal APIs
- Web API
- Routing
- Model Binding & Validation
- Authentication & Authorization
- Filters

---

## 🗄️ 14. Entity Framework Core (EF Core)

- DbContext & DbSet
- Code-First vs Database-First
- Migrations
- LINQ to SQL
- Change Tracking
- Performance Optimization

---

## 🧪 15. Testing & Debugging

- Unit Testing (xUnit, NUnit)
- Mocking (Moq)
- Integration Testing
- Debugging in Visual Studio
- Breakpoints & Watch Windows

---

## 🔥 Bonus: Advanced Topics

- `Span<T>` & `Memory<T>`
- Unsafe Code
- Roslyn Compiler
- Performance Optimization
- Microservices
- gRPC
- Docker with .NET

---

## 🧭 Recommended Learning Path

1. C# Fundamentals  
2. OOP & Memory Management  
3. Collections & LINQ  
4. Delegates & Events  
5. Async Programming  
6. ASP.NET Core  
7. EF Core  
8. Design Patterns  
9. Testing & Clean Architecture  

---

# 📂 Project Structure

This project serves as an interactive notebook for learning advanced C# concepts. Each file is a self-contained lesson with a "Story Line" to explain the concept simply, followed by a technical explanation and a runnable code demo.

The concepts are organized into 7 core categories, following the developer roadmap:

### 🧱 1. Core C# Fundamentals (`Concepts.CoreFundamentals`)
*   **`ControlFlow.cs`**: If, Switch, Loops (The Traffic Controller).
*   **`DataTypes.cs`**: Value vs Reference Types (The Photocopy vs Shared Doc).
*   **`NullableTypes.cs`**: Handling nulls safely (The Mystery Box).
*   **`PatternMatching.cs`**: `is` checks, switch expressions (The Smart Security Guard).
*   **`TuplesAndDeconstruction.cs`**: Returning multiple values (The Combo Meal).
*   **`ExtensionMethods.cs`**: Adding methods to existing types (The Backpack Attachment).
*   **`ExceptionHandling.cs`**: Try-Catch-Finally (The Trapeze Artist).
*   **`CodingConventions.cs`**: Best practices for `var`, `using`, etc.
*   **`NamingConventions.cs`**: PascalCase, camelCase rules.

### 🧠 2. OOP (`Concepts.OOP`)
*   **`InterfacesVsAbstract.cs`**: Contracts vs Blueprints (The Job Description).
*   **`SolidPrinciples.cs`**: The 5 pillars of clean architecture (LEGO analogy).
*   **`DesignPatterns.cs`**: Singleton, Factory, and Repository patterns.
*   **`StaticConstructors.cs`**: One-time setup (The Blueprint Office).
*   **`EarlyVsLateBinding.cs`**: Compile-time vs Runtime resolution.

### 💾 3. Memory Management (`Concepts.MemoryManagement`)
*   **`StackVsHeap.cs`**: Memory allocation (The Notebook vs Whiteboard).
*   **`BoxingUnboxing.cs`**: Value types vs Reference types.
*   **`FinalizeVsDispose.cs`**: Cleanup (The Librarian vs The Janitor).
*   **`Records.cs`**: Immutable data types (The Photocopy).
*   **`StringVsStringBuilder.cs`**: Immutable vs Mutable strings.

### 📦 4. Collections & Generics (`Concepts.CollectionsAndGenerics`)
*   **`ArraysVsCollections.cs`**: Fixed vs Dynamic storage.
*   **`Generics.cs`**: Generic Classes & Methods (The Universal Factory).
*   **`CustomCollections.cs`**: Implementing `IEnumerable` (The Playlist).

### 🔍 5. LINQ (`Concepts.LINQ`)
*   **`Linq.cs`**: Language Integrated Query (The Universal Translator).
*   **`DeferredExecution.cs`**: Lazy evaluation (The Pizza Order).
*   **`AnonymousTypes.cs`**: Temporary objects (The Temporary ID Badge).

### 🔁 6. Delegates & Events (`Concepts.DelegatesAndEvents`)
*   **`DelegatesAndEvents.cs`**: Event-driven programming (The Newspaper Subscription).
*   **`FuncActionPredicate.cs`**: Standard delegates (The Pre-made Forms).
*   **`LambdaExpressions.cs`**: Anonymous functions (The Sticky Note).

### ⚡ 7. Async & Parallel (`Concepts.AsyncAndParallel`)
*   **`AsyncMultithreading.cs`**: Async/Await (The Breakfast Chef).
*   **`TaskParallelLibrary.cs`**: Parallel Loops (The Assembly Line).

---

## ▶️ How to Run

Since this is a single Console Application with multiple `Main` methods, you must specify which file (Class) you want to execute.

### Using `dotnet run`

Use the `--property:StartupObject` flag followed by the full namespace and class name.

**Examples:**

```powershell
# 1. Core Fundamentals
dotnet run --property:StartupObject=Concepts.CoreFundamentals.ControlFlow
dotnet run --property:StartupObject=Concepts.CoreFundamentals.PatternMatching

# 2. OOP
dotnet run --property:StartupObject=Concepts.OOP.InterfacesVsAbstract

# 3. Memory Management
dotnet run --property:StartupObject=Concepts.MemoryManagement.StackVsHeap

# 4. Collections
dotnet run --property:StartupObject=Concepts.CollectionsAndGenerics.CustomCollections

# 5. LINQ
dotnet run --property:StartupObject=Concepts.LINQ.DeferredExecution

# 6. Delegates
dotnet run --property:StartupObject=Concepts.DelegatesAndEvents.FuncActionPredicate

# 7. Async
dotnet run --property:StartupObject=Concepts.AsyncAndParallel.TaskParallelLibrary
```

### 📝 Notes
*   **Caching Issue**: If you switch between demos using the command line and see the output of the *previous* demo, run `dotnet clean` first.
*   Each file contains a `Main` method.
*   Read the comments in each file for the "Story Line" and detailed explanations.

---

## 🤝 Contributing

Contributions are welcome!  
Feel free to open issues, submit pull requests, or suggest improvements.

---

## ⭐ Support

If you find this repository helpful, consider giving it a **star ⭐** to support the project.

Happy Coding! 🚀

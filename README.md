# C# Concepts Notebook

This project serves as an interactive notebook for learning advanced C# concepts. Each file is a self-contained lesson with a "Story Line" to explain the concept simply, followed by a technical explanation and a runnable code demo.

## 📂 Project Structure

The concepts are organized into the following categories:

### 🏗️ OOP (Object-Oriented Programming)
*   **`SolidPrinciples.cs`**: The 5 pillars of clean architecture (LEGO analogy).
*   **`DesignPatterns.cs`**: Singleton, Factory, and Repository patterns.
*   **`Records.cs`**: Immutable data types (The Photocopy).
*   **`StaticConstructors.cs`**: One-time setup (The Blueprint Office).
*   **`ConstVsReadonly.cs`**: Compile-time vs Runtime constants.
*   **`FinalizeVsDispose.cs`**: Memory management (The Librarian vs The Janitor).
*   **`BoxingUnboxing.cs`**: Value types vs Reference types.
*   **`EarlyVsLateBinding.cs`**: Compile-time vs Runtime resolution.
*   **`RefVsOut.cs`**: Parameter passing modifiers.

### 📦 Collections & Data
*   **`ArraysVsCollections.cs`**: Fixed vs Dynamic storage.
*   **`StringVsStringBuilder.cs`**: Immutable vs Mutable strings.
*   **`Linq.cs`**: Language Integrated Query (The Universal Translator).

### 🚀 Advanced Concepts
*   **`AsyncMultithreading.cs`**: Async/Await and Threading (The Breakfast Chef).
*   **`DelegatesAndEvents.cs`**: Event-driven programming (The Newspaper Subscription).
*   **`LambdaExpressions.cs`**: Anonymous functions (The Sticky Note).
*   **`LazyLoading.cs`**: Deferred initialization (The Heavy Backpack).
*   **`ExtensionMethods.cs`**: Adding methods to existing types (The Backpack Attachment).
*   **`ExceptionHandling.cs`**: Try-Catch-Finally (The Trapeze Artist).
*   **`NullableTypes.cs`**: Handling nulls safely (The Mystery Box).
*   **`PatternMatching.cs`**: `is` checks, switch expressions, and property patterns (The Smart Security Guard).
*   **`TuplesAndDeconstruction.cs`**: Returning multiple values, deconstruction, and discards (The Combo Meal).
*   **`AnonymousTypes.cs`**: Temporary objects for local scope (The Temporary ID Badge).

### ⚙️ Generics
*   **`Generics.cs`**: Generic Classes, Methods, Interfaces, and Delegates (The Universal Factory).

---

## ▶️ How to Run

Since this is a single Console Application with multiple `Main` methods, you cannot simply run `dotnet run`. You must specify which file (Class) you want to execute.

### Option 1: Using `dotnet run` (Recommended)
Use the `--property:StartupObject` flag followed by the full namespace and class name.

**Examples:**

```powershell
# Run the Async/Await Demo
dotnet run --property:StartupObject=Concepts.AdvancedConcepts.AsyncMultithreading

# Run the Generics Demo
dotnet run --property:StartupObject=Concepts.Generics.GenericsDemo

# Run the SOLID Principles Demo
dotnet run --property:StartupObject=Concepts.SolidPrinciples
```

### Option 2: Modify `.csproj` (Permanent Switch)
If you want to run the same file repeatedly without typing the flag, you can edit the `demo.csproj` file and add a `<StartupObject>` tag:

```xml
<PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net8.0</TargetFramework>
    <!-- Change this value to switch the active file -->
    <StartupObject>Concepts.AdvancedConcepts.AsyncMultithreading</StartupObject>
</PropertyGroup>
```

Then you can just run:
```powershell
dotnet run
```

## 📝 Notes
*   **Caching Issue**: If you switch between demos using the command line and see the output of the *previous* demo, run `dotnet clean` first.
*   Each file contains a `Main` method.
*   Read the comments in each file for the "Story Line" and detailed explanations.

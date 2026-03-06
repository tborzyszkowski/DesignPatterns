# Singleton — Problemy: Dziedziczenie i Serializacja

---

## Wprowadzenie

Singleton jest łatwy do zaimplementowania w podstawowej formie, ale ma kilka pułapek,  
które ujawniają się przy próbie rozszerzenia klas lub utrwalenia stanu obiektów.

---

## Problem 1: Dziedziczenie

### Na czym polega problem?

Bazowy Singleton kontroluje tworzenie instancji przez prywatny konstruktor i statyczne pole.  
Gdy próbujemy stworzyć podklasę, napotykamy na fundamentalną sprzeczność:

1. Konstruktor bazowego Singletona jest `private` → podklasa nie może go wywołać.
2. Jeśli zmienimy na `protected` → kilka podklas może "konkurować" o to samo statyczne pole.
3. Statyczne pole `_instance` w klasie bazowej jest **wspólne** dla wszystkich podklas.

```csharp
// PROBLEM: Dziedziczenie singletona
public class Logger
{
    protected static Logger? _instance;   // wspólne pole!

    protected Logger() { }

    public static Logger GetInstance()
    {
        _instance ??= new Logger();        // zawsze tworzy Logger, nie podklasę!
        return _instance;
    }
}

public class FileLogger : Logger
{
    protected FileLogger() { }
    // Nie ma własnej metody GetInstance() — problematyczne!
}

public class DatabaseLogger : Logger
{
    protected DatabaseLogger() { }
}

// Wywołanie:
var a = FileLogger.GetInstance();      // zwraca Logger, NIE FileLogger!
var b = DatabaseLogger.GetInstance();  // zwraca ten sam Logger co powyżej
Console.WriteLine(a.GetType().Name);   // "Logger" !
```

**Diagram:** [`diagrams/inheritance_problem.puml`](diagrams/inheritance_problem.puml)

---

### Rozwiązanie 1: Rejestr Singletonów (Registry of Singletons)

GoF sugeruje użycie rejestru, który mapuje nazwy na instancje:

```csharp
public class Logger
{
    private static readonly Dictionary<string, Logger> _registry = new();

    protected Logger() { }

    public static Logger GetInstance(string type = "default")
    {
        if (!_registry.ContainsKey(type))
        {
            Logger instance = type switch
            {
                "file"     => new FileLogger(),
                "database" => new DatabaseLogger(),
                _          => new Logger()
            };
            _registry[type] = instance;
        }
        return _registry[type];
    }

    public virtual void Log(string msg) => Console.WriteLine($"[LOG] {msg}");
}
```

---

### Rozwiązanie 2: Każda podklasa jest własnym Singletonem

```csharp
public class Logger
{
    protected Logger() { }
    public virtual void Log(string msg) => Console.WriteLine($"[LOG] {msg}");
}

public sealed class FileLogger : Logger
{
    public static FileLogger Instance { get; } = new FileLogger();
    private FileLogger() { }
    public override void Log(string msg) => Console.WriteLine($"[FILE] {msg}");
}

public sealed class DatabaseLogger : Logger
{
    public static DatabaseLogger Instance { get; } = new DatabaseLogger();
    private DatabaseLogger() { }
    public override void Log(string msg) => Console.WriteLine($"[DB] {msg}");
}
```

Pełna implementacja: [`code/Problems/InheritanceProblem.cs`](code/Problems/InheritanceProblem.cs)

---

## Problem 2: Serializacja

### Na czym polega problem?

Serializacja i deserializacja mogą naruszyć gwarancję jedynej instancji:

```csharp
[Serializable]
public class Config
{
    private static readonly Config _instance = new Config();
    private Config() { }
    public static Config Instance => _instance;
    public string Value { get; set; } = "default";
}

// Naruszenie Singletona przez deserializację!
var json = JsonSerializer.Serialize(Config.Instance);
var deserialized = JsonSerializer.Deserialize<Config>(json);
// deserialized != Config.Instance  ← DWIE INSTANCJE!
```

**Diagram:** [`diagrams/serialization_problem.puml`](diagrams/serialization_problem.puml)

---

### Rozwiązanie: ISerializable z ReadResolve

W C# rozwiązujemy to przez `ISerializable` lub zwracając istniejącą instancję w specjalnej metodzie.  
Dla `System.Text.Json` można użyć konwertera:

```csharp
// Podejście 1: Własny JsonConverter zwracający singleton zamiast nowego obiektu
public class SingletonConverter<T> : JsonConverter<T> where T : class
{
    private readonly Func<T> _getInstance;

    public SingletonConverter(Func<T> getInstance) => _getInstance = getInstance;

    public override T? Read(ref Utf8JsonReader reader, Type typeToConvert,
        JsonSerializerOptions options)
    {
        // Deserializuj do anonimowego obiektu, ale zwróć singleton
        using var doc = JsonDocument.ParseValue(ref reader);
        return _getInstance();  // zawsze zwraca tę samą instancję
    }

    public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
        => JsonSerializer.Serialize(writer, value, options);
}
```

---

### Rozwiązanie 2: Serializacja BinaryFormatter (legacy) z IObjectReference

```csharp
[Serializable]
public class LegacyConfig : ISerializable, IObjectReference
{
    private static readonly LegacyConfig _instance = new LegacyConfig();
    private LegacyConfig() { }

    public static LegacyConfig Instance => _instance;
    public string Value { get; set; } = "default";

    // Wymagane do deserialization
    protected LegacyConfig(SerializationInfo info, StreamingContext context) { }

    public void GetObjectData(SerializationInfo info, StreamingContext context) { }

    // Kluczowa metoda: deserializator wywołuje ją zamiast używać deserializowanego obiektu
    public object GetRealObject(StreamingContext context) => _instance;
}
```

Pełna implementacja: [`code/Problems/SerializationProblem.cs`](code/Problems/SerializationProblem.cs)

---

## Problem 3: Refleksja

### Na czym polega problem?

Refleksja pozwala na obejście prywatnego konstruktora:

```csharp
// Naruszenie Singletona przez refleksję!
var constructor = typeof(LazySingleton)
    .GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, null, [], null);

var hackedInstance = constructor?.Invoke(null);
Console.WriteLine(hackedInstance == LazySingleton.Instance); // false !
```

### Rozwiązanie: Guard w konstruktorze

```csharp
public sealed class HardenedSingleton
{
    private static int _instanceCount = 0;
    private static readonly HardenedSingleton _instance = new HardenedSingleton();

    private HardenedSingleton()
    {
        if (Interlocked.Increment(ref _instanceCount) > 1)
            throw new InvalidOperationException(
                "Próba stworzenia drugiej instancji Singletona przez refleksję!");
    }

    public static HardenedSingleton Instance => _instance;
}
```

Pełna implementacja: [`code/Problems/ReflectionProblem.cs`](code/Problems/ReflectionProblem.cs)

---

## Podsumowanie problemów

| Problem | Symptom | Rozwiązanie |
|---------|---------|-------------|
| Dziedziczenie | `GetInstance()` w podklasie zwraca typ bazowy | Rejestr singletonów lub osobne singletony w podklasach |
| Serializacja | Deserializacja tworzy nową instancję | `IObjectReference.GetRealObject()` lub własny `JsonConverter` |
| Refleksja | `GetConstructor` + `Invoke` łamie singleton | Guard w konstruktorze z licznikiem instancji |

---

## Kod źródłowy

| Plik | Opis |
|------|------|
| [`InheritanceProblem.cs`](code/Problems/InheritanceProblem.cs) | Demonstracja problemu I rozwiązań — dziedziczenie |
| [`SerializationProblem.cs`](code/Problems/SerializationProblem.cs) | Demonstracja problemu i rozwiązań — serializacja |
| [`ReflectionProblem.cs`](code/Problems/ReflectionProblem.cs) | Demonstracja problemu i rozwiązań — refleksja |
| [`Program.cs`](code/Problems/Program.cs) | Uruchamialny przykład demonstracyjny |

```bash
cd code/Problems
dotnet run
```

---

## Literatura i źródła

- Gamma et al. (1994). *Design Patterns*. Addison-Wesley. **s. 133–134** — rejestr singletonów.
- [Prevent Breaking a Singleton Class Pattern — DZone](https://dzone.com/articles/prevent-breaking-a-singleton-class-pattern)
- [Singleton and Serialization — Stack Overflow](https://stackoverflow.com/questions/2855741/why-is-the-singleton-pattern-not-thread-safe-and-how-to-make-it-thread-safe)
- [IObjectReference Interface — Microsoft Docs](https://learn.microsoft.com/en-us/dotnet/api/system.runtime.serialization.iobjectreference)

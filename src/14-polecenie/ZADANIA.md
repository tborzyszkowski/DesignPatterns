# Zadania — Wzorzec Polecenie

## Zadanie 1 — Podstawowy wzorzec (poziom: łatwy)

### Treść

Zaimplementuj prosty system obsługi zamówień w restauracji używając wzorca Polecenie:

- Interfejs `ICommand` z metodą `Execute()`.
- `Order` (Odbiorca) z metodami `CookPasta()`, `CookPizza()`, `CookSalad()`.
- `CookPastaCommand`, `CookPizzaCommand`, `CookSaladCommand` — konkretne polecenia.
- `Waiter` (Invoker) który przechowuje listę zamówień i wywołuje je wszystkie naraz (`PlaceOrders()`).
- `Client` (klasa główna) który składa kilka zamówień przez kelnera.

Wymagane wyjście:
```
Przygotowuję: Makaron carbonara
Przygotowuję: Pizza margherita
Przygotowuję: Sałatka grecka
```

---

### Rozwiązanie

```csharp
// Interfejs polecenia
public interface ICommand
{
    void Execute();
}

// Odbiorca
public class Order
{
    public void CookPasta() => Console.WriteLine("Przygotowuję: Makaron carbonara");
    public void CookPizza() => Console.WriteLine("Przygotowuję: Pizza margherita");
    public void CookSalad() => Console.WriteLine("Przygotowuję: Sałatka grecka");
}

// Konkretne polecenia
public class CookPastaCommand(Order order) : ICommand
{
    public void Execute() => order.CookPasta();
}

public class CookPizzaCommand(Order order) : ICommand
{
    public void Execute() => order.CookPizza();
}

public class CookSaladCommand(Order order) : ICommand
{
    public void Execute() => order.CookSalad();
}

// Invoker — kelner
public class Waiter
{
    private readonly List<ICommand> _orders = [];

    public void TakeOrder(ICommand command) => _orders.Add(command);

    public void PlaceOrders()
    {
        foreach (var order in _orders)
            order.Execute();
        _orders.Clear();
    }
}

// Użycie
var order = new Order();
var waiter = new Waiter();

waiter.TakeOrder(new CookPastaCommand(order));
waiter.TakeOrder(new CookPizzaCommand(order));
waiter.TakeOrder(new CookSaladCommand(order));
waiter.PlaceOrders();
```

**Wyjaśnienie:** `Waiter` (Invoker) nie wie, jak gotować — jedynie przechowuje polecenia i uruchamia je. `Order` (Receiver) zawiera faktyczną logikę gotowania. Polecenia łączą Invoker z Receiver.

---

## Zadanie 2 — Undo/Redo (poziom: średni)

### Treść

Zaimplementuj prosty edytor tekstu z obsługą cofania i ponawiania operacji:

- Interfejs `ICommand` z metodami `Execute()` i `Undo()`.
- `TextEditor` (Odbiorca) z właściwością `Text` i metodami `Append(string)` oraz `Delete(int count)`.
- `AppendCommand` — polecenie dopisania tekstu.
- `DeleteCommand` — polecenie usunięcia ostatnich n znaków.
- `EditorHistory` (Invoker) zarządzający stosem Undo i stosem Redo.
  - `Execute(ICommand)` — wykonaj i zapamiętaj.
  - `Undo()` — cofnij ostatnią operację.
  - `Redo()` — ponów ostatnio cofniętą operację.

Sprawdź działanie dla sekwencji:
1. Dopisz "Hello"
1. Dopisz " World"
1. Cofnij (Undo)
1. Dopisz "!"
1. Cofnij (Undo)
1. Ponów (Redo)

---

### Rozwiązanie

```csharp
public interface ICommand
{
    void Execute();
    void Undo();
}

public class TextEditor
{
    private readonly StringBuilder _buffer = new();
    public string Text => _buffer.ToString();

    public void Append(string text)
    {
        _buffer.Append(text);
        Console.WriteLine($"  [Edytor] Tekst: \"{Text}\"");
    }

    public void Delete(int count)
    {
        if (count > _buffer.Length) count = _buffer.Length;
        _buffer.Remove(_buffer.Length - count, count);
        Console.WriteLine($"  [Edytor] Tekst: \"{Text}\"");
    }
}

public class AppendCommand(TextEditor editor, string text) : ICommand
{
    public void Execute() => editor.Append(text);
    public void Undo() => editor.Delete(text.Length);
}

public class DeleteCommand(TextEditor editor, int count) : ICommand
{
    private string _deleted = "";

    public void Execute()
    {
        // Zapamiętaj usunięte znaki, żeby móc je przywrócić
        string current = editor.Text;
        int actualCount = Math.Min(count, current.Length);
        _deleted = current[^actualCount..];
        editor.Delete(actualCount);
    }

    public void Undo() => editor.Append(_deleted);
}

public class EditorHistory
{
    private readonly Stack<ICommand> _undoStack = new();
    private readonly Stack<ICommand> _redoStack = new();

    public void Execute(ICommand cmd)
    {
        cmd.Execute();
        _undoStack.Push(cmd);
        _redoStack.Clear(); // nowa operacja kasuje stos redo
    }

    public void Undo()
    {
        if (_undoStack.TryPop(out var cmd))
        {
            Console.WriteLine("  [Undo]");
            cmd.Undo();
            _redoStack.Push(cmd);
        }
        else Console.WriteLine("  [Undo] Brak operacji do cofnięcia");
    }

    public void Redo()
    {
        if (_redoStack.TryPop(out var cmd))
        {
            Console.WriteLine("  [Redo]");
            cmd.Execute();
            _undoStack.Push(cmd);
        }
        else Console.WriteLine("  [Redo] Brak operacji do ponowienia");
    }
}

// Użycie
var editor = new TextEditor();
var history = new EditorHistory();

Console.WriteLine("Dopisz 'Hello':");
history.Execute(new AppendCommand(editor, "Hello"));

Console.WriteLine("Dopisz ' World':");
history.Execute(new AppendCommand(editor, " World"));

Console.WriteLine("Cofnij:");
history.Undo();  // cofa " World"

Console.WriteLine("Dopisz '!':");
history.Execute(new AppendCommand(editor, "!"));

Console.WriteLine("Cofnij:");
history.Undo();  // cofa "!"

Console.WriteLine("Ponów:");
history.Redo();  // ponawia "!"
```

---

## Zadanie 3 — Makropolecenie (poziom: średni)

### Treść

Zbuduj system automatyzacji domu (smart home). Zaimplementuj:

- `ICommand` z `Execute()` i `Undo()`.
- Odbiorniki: `Light` (włącz/wyłącz), `Fan` (włącz/wyłącz), `Thermostat` (ustaw temperaturę).
- Konkretne polecenia dla każdego odbiornika.
- `MacroCommand` — polecenie złożone, które wykonuje listę poleceń (Composite Command).
- Scenariusz "Wychodzę z domu" = wyłącz światła + wyłącz wentylator + ustaw termostat 15°C.
- Scenariusz "Wracam do domu" = włącz światła + ustaw termostat 22°C.

---

### Rozwiązanie (szkielet — pełna implementacja w temacie 04)

```csharp
public class MacroCommand(ICommand[] commands) : ICommand
{
    public void Execute()
    {
        foreach (var cmd in commands)
            cmd.Execute();
    }

    public void Undo()
    {
        // Cofanie w odwrotnej kolejności!
        foreach (var cmd in commands.Reverse())
            cmd.Undo();
    }
}

// Scenariusz "Wychodzę":
ICommand leaveHome = new MacroCommand([
    new LightOffCommand(livingRoomLight),
    new LightOffCommand(bedroomLight),
    new FanOffCommand(ceilingFan),
    new SetTemperatureCommand(thermostat, 15)
]);

remoteContról.SetCommand(0, leaveHome);
```

---

## Zadanie 4 — Kolejka poleceń (poziom: trudny)

### Treść

Zaimplementuj system kolejki zadań (`CommandQueue`) który:

- Przyjmuje polecenia metodą `Enqueue(ICommand)`.
- Przetwarza je w tle w osobnym wątku (`Thread` lub `Task`).
- Umożliwia zatrzymanie przetwarzania (`Stop()`).
- Loguje każde wykonane polecenie wraz że znacznikiem czasu.

**Wskazówka:** użyj `BlockingCollection<ICommand>` z przestrzeni `System.Collections.Concurrent`.

---

### Rozwiązanie

```csharp
public class CommandQueue : IDisposable
{
    private readonly BlockingCollection<ICommand> _queue = new();
    private readonly Task _processor;
    private readonly CancellationTokenSource _cts = new();

    public CommandQueue()
    {
        _processor = Task.Run(ProcessLoop);
    }

    public void Enqueue(ICommand command) => _queue.Add(command);

    public void Stop()
    {
        _queue.CompleteAdding();
        _processor.Wait();
    }

    private void ProcessLoop()
    {
        foreach (var cmd in _queue.GetConsumingEnumerable())
        {
            try
            {
                Console.WriteLine($"[{DateTime.Now:HH:mm:ss.fff}] Wykonuję: {cmd.GetType().Name}");
                cmd.Execute();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"  [BŁĄD] {ex.Message}");
            }
        }
    }

    public void Dispose()
    {
        _cts.Cancel();
        _queue.Dispose();
    }
}

// Użycie:
using var queue = new CommandQueue();
queue.Enqueue(new PrintCommand("Zadanie 1"));
queue.Enqueue(new PrintCommand("Zadanie 2"));
queue.Enqueue(new PrintCommand("Zadanie 3"));
queue.Stop();
```

---

## Zadanie 5 — Pytania teoretyczne

1. Czym różni się wzorzec Polecenie od wzorca Strategia? Kiedy użyjesz którego?
1. Dlaczego przy cofaniu złożonego polecenia (`MacroCommand`) należy wykonywać operacje Undo w **odwrotnej** kolejności?
1. Jakie są zalety i wady przechowywania historii poleceń jako listy obiektów vs. logu operacji (event sourcing)?
1. Opisz, jak wzorzec Polecenie ułatwia implementację transakcji bazodanowych.
1. Porównaj wzorzec Polecenie z mechanizmem `Action<T>` / delegatami w C#. Kiedy delegat wystarczy, a kiedy potrzebny jest pełny wzorzec?

### Odpowiedzi wzorcowe

**1.** Strategia konfiguruje algorytm obiektu (wie, JAK coś zrobić), a Polecenie enkapsuluje żądanie operacji (wie, ŻE i CO zrobić, kiedy i wobec kogo). Strategii używasz gdy chcesz wymieniać algorytmy; Polecenia gdy chcesz kolejkować, rejestrować lub cofać operacje.

**2.** Ponieważ każde polecenie mogło zmienić stan potrzebny przez następne polecenie. Cofanie musi przywracać stan w dokładnie odwrotnej kolejności — jak zwijanie stosu.

**3.** Lista obiektów poleceń umożliwia undo/redo, ale zajmuje pamięć i wymaga pełnych obiektów. Event sourcing jest czytelniejszy dla audytu i skalowalny, ale undo wymaga odtwarzania całego stanu od początku lub snapshot-ów.

**4.** Każda operacja bazodanowa to polecenie; historia poleceń to log transakcji; Undo to rollback; zatwierdzenie (commit) to opróżnienie kolejki; transakcja to MacroCommand.

**5.** Delegat/`Action<T>` wystarczy gdy nie potrzebujesz Undo, parametryzacji, serializacji ani logowania. Pełny wzorzec stosuj gdy potrzebujesz historii poleceń, kolejkowania, cofania lub gdy polecenie niesie stan (co, kiedy, wobec kogo).

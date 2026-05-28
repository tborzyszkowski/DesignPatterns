// =============================================================================
// Wzorzec Mediator — 01. Idea i kontekst
// Problem: siatka powiązań vs rozwiązanie: mediator
// =============================================================================

Console.WriteLine("═══ PROBLEM: komponenty bez mediatora ═══\n");

var buttonDirect  = new ButtonDirect("Zaloguj");
var inputDirect   = new InputDirect("Login");
var messageDirect = new MessageDirect();
var checkboxDirect = new CheckboxDirect("Zapamiętaj mnie");

// Każdy komponent zna inne komponenty bezpośrednio
buttonDirect.SetDependencies(inputDirect, messageDirect, checkboxDirect);
inputDirect.SetDependencies(buttonDirect, messageDirect);

Console.WriteLine("Wpisz login: jan");
inputDirect.SetText("jan");

Console.WriteLine("\nKliknij przycisk:");
buttonDirect.Click();

Console.WriteLine("\n═══ ROZWIĄZANIE: komponenty z mediatorem ═══\n");

// Komponenty znają TYLKO mediator — nie znają się nawzajem
var button  = new Button("Zaloguj");
var input   = new TextInput("Login");
var message = new MessageLabel();
var checkbox = new Checkbox("Zapamiętaj mnie");

// Mediator zna wszystkich uczestników i koordynuje ich
IDialogMediator mediator = new LoginDialogMediator(button, input, message, checkbox);

Console.WriteLine("Wpisz login: (pusty)");
input.SetText("");

Console.WriteLine("\nWpisz login: jan");
input.SetText("jan");

Console.WriteLine("\nKliknij 'Zapamiętaj mnie':");
checkbox.Toggle();

Console.WriteLine("\nKliknij przycisk 'Zaloguj':");
button.Click();

// =============================================================================
// PROBLEM: bezpośrednie zależności (anty-wzorzec)
// =============================================================================

class ButtonDirect(string label)
{
    private InputDirect? _input;
    private MessageDirect? _msg;
    private CheckboxDirect? _cb;

    public void SetDependencies(InputDirect input, MessageDirect msg, CheckboxDirect cb)
    {
        _input = input; _msg = msg; _cb = cb;
    }

    public void Click()
    {
        // Przycisk bezpośrednio ZNA i ZALEŻY od każdego komponentu UI
        if (string.IsNullOrEmpty(_input?.Text))
        {
            _msg?.Show("Błąd: login jest wymagany");
            return;
        }
        var remember = _cb?.IsChecked ?? false;
        _msg?.Show($"Zalogowano: {_input.Text} (zapamiętaj={remember})");
    }
}

class InputDirect(string placeholder)
{
    public string Text { get; private set; } = "";
    private ButtonDirect? _button;
    private MessageDirect? _msg;

    public void SetDependencies(ButtonDirect button, MessageDirect msg)
    {
        _button = button; _msg = msg;
    }

    public void SetText(string text)
    {
        Text = text;
        // Wejście bezpośrednio steruje przyciskiem
        Console.WriteLine($"  [InputDirect] tekst='{text}'");
    }
}

class MessageDirect
{
    public void Show(string msg) => Console.WriteLine($"  [MessageDirect] {msg}");
}

class CheckboxDirect(string label)
{
    public bool IsChecked { get; private set; }
    public void Toggle() { IsChecked = !IsChecked; Console.WriteLine($"  [CheckboxDirect] {label}={IsChecked}"); }
}

// =============================================================================
// ROZWIĄZANIE: Mediator
// =============================================================================

/// <summary>GoF: Mediator — interfejs komunikacji</summary>
interface IDialogMediator
{
    void Notify(object sender, string @event);
}

/// <summary>GoF: Colleague — komponent znający tylko mediatora</summary>
abstract class UIComponent(string name)
{
    protected IDialogMediator? Mediator { get; private set; }
    public string Name => name;

    public void SetMediator(IDialogMediator mediator) => Mediator = mediator;

    protected void NotifyMediator(string @event)
        => Mediator?.Notify(this, @event);
}

class Button(string label) : UIComponent(label)
{
    public void Click() => NotifyMediator("click");
}

class TextInput(string placeholder) : UIComponent(placeholder)
{
    public string Text { get; private set; } = "";

    public void SetText(string text)
    {
        Text = text;
        NotifyMediator("input");
    }
}

class MessageLabel : UIComponent("message")
{
    public void Show(string text) => Console.WriteLine($"  [Komunikat] {text}");
}

class Checkbox(string label) : UIComponent(label)
{
    public bool IsChecked { get; private set; }

    public void Toggle()
    {
        IsChecked = !IsChecked;
        NotifyMediator("toggle");
    }
}

/// <summary>GoF: ConcreteMediator — cała logika koordynacji w jednym miejscu</summary>
class LoginDialogMediator : IDialogMediator
{
    private readonly Button _button;
    private readonly TextInput _input;
    private readonly MessageLabel _message;
    private readonly Checkbox _checkbox;

    public LoginDialogMediator(Button button, TextInput input,
        MessageLabel message, Checkbox checkbox)
    {
        _button   = button;
        _input    = input;
        _message  = message;
        _checkbox = checkbox;

        // Mediator rejestruje się u wszystkich uczestników
        button.SetMediator(this);
        input.SetMediator(this);
        message.SetMediator(this);
        checkbox.SetMediator(this);
    }

    public void Notify(object sender, string @event)
    {
        Console.WriteLine($"  [Mediator] {sender.GetType().Name} → '{@event}'");

        switch (sender, @event)
        {
            case (TextInput, "input"):
                // Tekst się zmienił — włącz/wyłącz przycisk
                var isEmpty = string.IsNullOrEmpty(_input.Text);
                Console.WriteLine($"  [Mediator] Przycisk {(isEmpty ? "dezaktywowany" : "aktywowany")}");
                break;

            case (Button, "click"):
                // Kliknięto przycisk — waliduj i zaloguj
                if (string.IsNullOrEmpty(_input.Text))
                    _message.Show("Błąd: login jest wymagany");
                else
                    _message.Show($"Zalogowano: {_input.Text} | zapamiętaj={_checkbox.IsChecked}");
                break;

            case (Checkbox, "toggle"):
                Console.WriteLine($"  [Mediator] Checkbox zmieniony na {_checkbox.IsChecked}");
                break;
        }
    }
}

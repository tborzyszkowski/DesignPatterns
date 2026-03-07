// =========================================================================
// Simple Factory — demonstracja wzorca i jego ograniczeń
// =========================================================================

using SimpleFactory;
using SimpleFactory.Notifications;

Console.WriteLine("╔════════════════════════════════════════════╗");
Console.WriteLine("║    SIMPLE FACTORY — przykłady              ║");
Console.WriteLine("╚════════════════════════════════════════════╝");

// ----- Przykład 1: Pizzeria -------------------------------------------
Console.WriteLine("\n═══ Przykład 1: Pizzeria (Head First) ═══\n");

var factory = new SimplePizzaFactory();
var store = new PizzaStore(factory);

store.OrderPizza("cheese");
store.OrderPizza("pepperoni");
store.OrderPizza("veggie");
store.OrderPizza("hawaii");   // nieznany typ

// ----- Przykład 2: Powiadomienia -------------------------------------------
Console.WriteLine("\n═══ Przykład 2: System powiadomień ═══\n");

var notifFactory = new NotificationFactory();
var notifService = new NotificationService(notifFactory);

notifService.Notify("email", "user@example.com", "Twoje zamówienie jest gotowe");
notifService.Notify("sms",   "+48123456789",     "Odbiór możliwy od 15:00");
notifService.Notify("push",  "device-token-abc", "Nowa wiadomość");
notifService.Notify("slack", "zamowienia",       "Zamówienie #1234 wymaga uwagi");

// ----- Przykład 3: Problematyczne rozszerzenie ------------------------------
Console.WriteLine("\n═══ Problem OCP w Simple Factory ═══\n");
Console.WriteLine("Aby dodać nowy typ pizzy (np. 'buffalo'),");
Console.WriteLine("musimy ZMODYFIKOWAĆ SimplePizzaFactory.CreatePizza().");
Console.WriteLine("Ryzjko: możemy zepsuć obsługę istniejących typów.");
Console.WriteLine("\nRozwiązanie: Factory Method lub Abstract Factory");
Console.WriteLine("(patrz katalogi 03-factory-method i 04-abstract-factory)");

# Materiały do wykładu — Clean Architecture

## Plan wykładu (90 minut)

| Czas | Segment | Treść |
|------|---------|-------|
| 0–10 min | Motywacja | Problem z N-Tier: ścisłe sprzężenie, brak testowalności, zależność od bazy danych |
| 10–20 min | Historia | Uncle Bob 2012, Onion Architecture (2008), Hexagonal Architecture (2005) |
| 20–35 min | Cztery warstwy | Entities → Use Cases → Interface Adapters → Frameworks & Drivers |
| 35–50 min | Zasada Zależności | Dependency Rule, DIP, porty i adaptery, Composition Root |
| 50–65 min | Testowanie | Piramida testów, izolacja, testy bez frameworku |
| 65–75 min | Porównanie | N-Tier vs Onion vs Hexagonal vs Clean, kiedy co wybrać |
| 75–90 min | Demo + Q&A | Temat 06 — większy przykład, pytania |

---

## Kluczowe pojęcia

### 1. Problem z klasyczną architekturą N-Tier

```csharp
// PROBLEM: warstwa biznesowa zna szczegóły bazy danych
class OrderService {
    private SqlConnection _db = new("server=prod;..."); // ścisłe sprzężenie!
    public void CreateOrder(Order order) {
        _db.Open();
        // ... SQL ...
    }
    // Niemożliwy do przetestowania bez prawdziwej bazy!
}
```

**Pytanie do dyskusji:** Dlaczego trudno testować ten kod?

---

### 2. Zasada Zależności (Dependency Rule)

> Kod może zależeć TYLKO od warstw głębszych (bliżej centrum).
> Nic w warstwie wewnętrznej nie może wiedzieć o warstwie zewnętrznej.

```
Frameworks & Drivers
    │
    ▼
Interface Adapters
    │
    ▼
Use Cases
    │
    ▼
Entities          ← centrum, zero zależności zewnętrznych
```

---

### 3. Cztery warstwy — szczegółowo

**Warstwa 1 — Entities (Domain Layer):**
- Obiekty biznesowe z regułami biznesowymi
- Niezależne od frameworków, baz danych, UI
- Mogą być użyte w wielu aplikacjach

```csharp
public class Order {          // Encja — czysta logika biznesowa
    private List<OrderLine> _lines = [];
    public decimal TotalAmount => _lines.Sum(l => l.Subtotal);

    public void AddLine(Product product, int qty) {
        if (qty <= 0) throw new ArgumentException("Ilość musi być dodatnia");
        if (_lines.Any(l => l.ProductId == product.Id))
            throw new InvalidOperationException("Produkt już w zamówieniu");
        _lines.Add(new OrderLine(product.Id, qty, product.Price));
    }
}
```

**Warstwa 2 — Use Cases (Application Layer):**
- Scenariusze biznesowe aplikacji
- Orchestruje encje
- Definiuje porty (interfejsy)

```csharp
public class CreateOrderUseCase(IOrderRepository repo, IEmailService email) {
    public async Task<Order> ExecuteAsync(CreateOrderCommand cmd) {
        var order = new Order(OrderId.New(), cmd.CustomerId);
        foreach (var item in cmd.Items)
            order.AddLine(item.Product, item.Quantity);
        await repo.SaveAsync(order);
        await email.SendConfirmationAsync(cmd.CustomerId, order.Id);
        return order;
    }
}
```

**Warstwa 3 — Interface Adapters:**
- Kontrolery HTTP, CLI, gRPC
- Prezentory (formatowanie odpowiedzi)
- Bramki danych (Repository implementations)

**Warstwa 4 — Frameworks & Drivers:**
- ASP.NET Core, Entity Framework Core
- Zewnętrzne API, kolejki wiadomości
- Konfiguracja, DI container

---

### 4. Porty i Adaptery

```
         ┌──────────────────────────┐
         │      Application Layer   │
         │                          │
         │  IOrderRepository  ◄───────── Port (interfejs)
         │  IEmailService     ◄───────── Port (interfejs)
         │                          │
         └──────────────────────────┘
                    │
                    │ implementują
                    ▼
         ┌──────────────────────────┐
         │   Infrastructure Layer   │
         │                          │
         │  EfOrderRepository       │ ◄── Adapter
         │  SmtpEmailService        │ ◄── Adapter
         │                          │
         └──────────────────────────┘
```

---

### 5. Testowanie bez infrastruktury

```csharp
// Test jednostkowy — zero zależności od DB, SMTP, itp.
[Fact]
public async Task CreateOrder_ValidData_SavesOrder() {
    // Arrange
    var fakeRepo = new FakeOrderRepository();   // stub
    var fakeEmail = new FakeEmailService();     // stub
    var useCase = new CreateOrderUseCase(fakeRepo, fakeEmail);

    // Act
    var order = await useCase.ExecuteAsync(new CreateOrderCommand(...));

    // Assert
    Assert.Single(fakeRepo.SavedOrders);
    Assert.Single(fakeEmail.SentEmails);
}
```

**Dlaczego to możliwe?** Bo `CreateOrderUseCase` zależy od interfejsów, nie od implementacji.

---

## Diagramy do omówienia

1. [Warstwy Clean Architecture](01-idea-i-warstwy/diagrams/ca_warstwy.png)
2. [Zasada Zależności](01-idea-i-warstwy/diagrams/ca_zasada.png)
3. [Encje i Value Objects](02-encje-i-przypadki-uzycia/diagrams/ca_encje.png)
4. [Use Cases](02-encje-i-przypadki-uzycia/diagrams/ca_usecases.png)
5. [Dependency Inversion](03-zaleznosci-i-di/diagrams/ca_dip.png)
6. [Porty i Adaptery](03-zaleznosci-i-di/diagrams/ca_porty.png)
7. [Piramida testów](04-testowanie/diagrams/ca_piramida.png)
8. [Testowanie warstw](04-testowanie/diagrams/ca_testy.png)
9. [Porównanie architektur](05-porownanie-architektur/diagrams/ca_porownanie.png)
10. [Kiedy stosować](05-porownanie-architektur/diagrams/ca_kiedy.png)
11. [Architektura systemu zadań](06-wiekszy-przyklad/diagrams/ca_arch.png)
12. [Sekwencja: Utwórz zadanie](06-wiekszy-przyklad/diagrams/ca_sekwencja.png)

---

## Pytania do dyskusji

1. W jakim scenariuszu Clean Architecture jest nadmiarowa?
2. Jakie są różnice między Onion Architecture a Clean Architecture?
3. Jak obsłużyć transakcje bazodanowe przekraczające granice Use Case?
4. Co to jest Composition Root i gdzie powinien się znajdować?
5. Jak Clean Architecture wpływa na czas refaktoryzacji aplikacji?

---

## Kody do omówienia na wykładzie

- `01-idea-i-warstwy/Examples/Program.cs` — kontrast N-Tier vs Clean
- `03-zaleznosci-i-di/Examples/Program.cs` — porty i adaptery, Composition Root
- `06-wiekszy-przyklad/` — pełna implementacja 4-warstwowa

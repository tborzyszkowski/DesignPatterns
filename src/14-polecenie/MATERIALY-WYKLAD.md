# Materiały prowadzącego — Wzorzec Polecenie

Szczegółowy scenariusz wykładu z podziałem na sekcje i wskazówkami dla prowadzącego.

---

## Plan wykładu (90 min)

| Czas | Temat | Materiały |
| --- | --- | --- |
| 0–10 min | Motywacja — problem pilota | Demo `01-idea-i-kontekst` |
| 10–25 min | Struktura GoF — diagram klas | `03-struktura-gof-i-jak-dziala/diagrams/` |
| 25–40 min | Undo/Redo — kalkulator | Demo `04-typy-implementacji` |
| 40–55 min | Makropolecenia | Demo `04-typy-implementacji` |
| 55–75 min | Duży przykład: Smart Home | Demo `05-duzy-przyklad` |
| 75–85 min | Alternatywy i kiedy NIE używać | Slajdy + dyskusja |
| 85–90 min | Q&A i zadania | `ZADANIA.md` |

---

## Kluczowe pytania na wykładzie

1. **„Który obiekt NAPRAWDĘ wie, jak wykonać operację?"** → to jest Receiver.
1. **„Kto inicjuje operację?"** → Invoker — nie musi wiedzieć, CO robi.
1. **„Co mamy zyskać, zapamiętując polecenie jako obiekt?"** → undo, queue, log, macro.

---

## Pułapki i częste błędy studentów

- Mylenie Invoker z Client: Client *tworzy* polecenia; Invoker *wykonuje* je.
- Umieszczanie logiki biznesowej w `Execute()` zamiast w Receiver.
- Zapominanie o czyszczeniu stosu Redo po każdej nowej operacji.
- Nieodwracanie kolejności Undo w MacroCommand.

---

## Połączenia z innymi wzorcami

| Wzorzec | Związek |
| --- | --- |
| Composite | MacroCommand to de facto Composite poleceń |
| Memento | Polecenie + Memento = pełny snapshot undo |
| Strategia | Podobna struktura, inny cel — brak historii |
| Dekorator | Można owijać polecenia (logowanie, autoryzacja) |
| Observer | Zdarzenia (event) to lekka forma Polecenia |

---

## Pytania kontrolne (quiz)

1. Podaj trzy przypadki użycia wzorca Polecenie z życia wzięte.
1. Narysuj diagram sekwencji dla `Undo()` z dwoma poleceniami na stosie.
1. Dlaczego delegat `Action` nie zawsze zastępuje pełny wzorzec?
1. Co to jest „null object command" i kiedy go stosujemy?

---

## Referencje prowadzącego

- GoF (1994) str. 233–242 — oryginalny opis wzorca.
- Freeman & Freeman *Head First* (2021) rozdz. 6 — doskonałe intro „pilot zdalnego sterowania".
- [.NET `ICommand` w WPF/MAUI](https://docs.microsoft.com/en-us/dotnet/maui/fundamentals/data-binding/commanding) — gotowa implementacja w ekosystemie .NET.

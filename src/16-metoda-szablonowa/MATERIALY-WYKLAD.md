# Materiały Prowadzącego — Wzorzec Metoda Szablonowa

## Ogólna koncepcja modułu

Moduł składa się z **6 bloków tematycznych** (ok. 90 min łącznie).  
Prowadzący może wybrać pełną sekwencję lub skupić się na blokach 01, 03 i 06.

---

## Blok 01 — Idea i kontekst (15 min)

**Cel:** Uczniowie rozumieją problem duplikacji kodu w algorytmach o tej samej strukturze.

**Przebieg:**
1. Pokaż kod z duplikacją (dwa eksportery CSV i JSON — ta sama kolejność kroków).
2. Zapytaj: "Co jest identyczne? Co się różni?"  
3. Wprowadź Template Method jako sposób na wyodrębnienie szkieletu.

**Kluczowe pytania do studentów:**
- Dlaczego kopiowanie i modyfikowanie kodu jest niebezpieczne?
- Co jeśli zmieni się kolejność kroków? (trzeba edytować wszystkie klasy)

**Typowe błędy studentów:**
- Mylenie Template Method z interfejsem — interfejs nie ma implementacji kroków wspólnych.

---

## Blok 02 — Kiedy stosować (10 min)

**Cel:** Studenci potrafią rozpoznać sytuację wymagającą Template Method.

**Sygnały alarmowe (code smells) wskazujące na Template Method:**
- Dwie klasy z metodami o identycznej strukturze, ale różniących się detalami
- Copy-paste kodu z drobnymi modyfikacjami
- Klasa zawiera metodę z sekwencją kroków, gdzie część kroków może się różnić

**Pytania dyskusyjne:**
- Kiedy Template Method jest nadużyciem? (gdy mamy tylko 1-2 klasy)
- Porównaj: JUnit (`setUp/tearDown`), ASP.NET Core Middleware pipeline, `Stream` w Java

---

## Blok 03 — Struktura i działanie (20 min)

**Cel:** Studenci znają rolę GoF i rozumieją przepływ sterowania.

**Rolę GoF:**

| Rola | W C# | Opis |
|------|------|------|
| `AbstractClass` | `abstract class` | Definiuje metodę szablonową i kroki |
| `ConcreteClass` | klasa dziedzicząca | Implementuje konkretne kroki |
| Template Method | `public sealed void Execute()` | Szkielet algorytmu |
| Primitive Operations | `protected abstract void Step()` | Obowiązkowe kroki |
| Hooks | `protected virtual void Hook()` | Opcjonalne punkty rozszerzenia |

**Zasada Hollywood Principle — wyjaśnienie (5 min):**  
> "Nie dzwoń do nas — my zadzwonimy do ciebie"

Klasa bazowa wywołuje metody podklas, a nie odwrotnie. IoC (Inversion of Contról).

**Diagram sekwencji — omów krok po kroku:**  
Client → AbstractClass.Execute() → krok1() (konkretna klasa) → krok2() (konkretna klasa) → hook() (opcjonalny)

---

## Blok 04 — Typy implementacji (20 min)

**Cel:** Studenci znają 4 warianty i potrafią wybrać odpowiedni.

**Wariant 1 — czysto abstrakcyjny:** wszystkie kroki są `abstract`. Prosty, wymaga implementacji wszystkiego.

**Wariant 2 — z haczykami:** część kroków jest `virtual` z pustą lub domyślną implementacją. Klient może, ale nie musi przesłonić.

**Wariant 3 — z domyślnymi implementacjami:** domyślne implementacje wszystkich kroków, podklasy przesłaniają to co chcą.

**Wariant 4 — hybrydowy z Delegatem/Strategią:** klasa bazowa przyjmuje `Func<>` lub interfejs jako parametr konstruktóra — eliminuje konieczność tworzenia podklas.

**Ćwiczenie (5 min):** Który wariant wybrać dla:
- systemu logowania (różne destynacje: plik, DB, sieć)?
- procesu zamawiania (wszyscy walidują, tylko VIP ma rabat)?
- parsera formatów (każdy format ma inną składnię)?

---

## Blok 05 — Wady i zalety (10 min)

**Cel:** Studenci znają ograniczenia wzorca.

**Kluczowe problemy:**
1. **Fragile Base Class Problem** — zmiana w klasie bazowej może zepsuć podklasy.
2. **LSP naruszenie** — podklasy mogą zdefiniować `virtual` metody niezgodnie z oczekiwaniami.
3. **Testa jest trudna** — wymaga tworzenia podklas lub mockowania klasy abstrakcyjnej.
4. **Głęboka hierarchia** — łańcuch `A → B → C → D` staje się nieczytelny.

**Alternatywy do omówienia:**
- Strategia (kompozycja > dziedziczenie)
- `Func<>` delegaty (najprostsza alternatywa)
- Builder (dla złożonych procesów wieloetapowych)

---

## Blok 06 — Duży przykład (15 min)

**Cel:** Studenci widzą wzorzec w kontekście realnego systemu.

**Scenariusz:** System generowania raportów (HTML, PDF, CSV, Markdown)  
Wspólne kroki: zbierz dane, filtruj, formatuj nagłówek, formatuj wiersze, zapisz.

**Demonstracja live-coding (opcjonalna):**  
Zacznij od kodu z duplikacją, następnie refaktoryzuj do Template Method krok po kroku.

**Dyskusja końcowa (5 min):**
- Gdzie widzieliście Template Method w .NET? (Stream, TextWriter, DbConnection)
- Kiedy użylibyście alternatywy?

---

## Powiązania z innymi wzorcami

| Wzorzec | Relacja |
|---------|---------|
| Strategia | Alternatywa — dziedziczenie vs kompozycja |
| Fabryka Metoda (Factory Method) | Specjalizacja — Template Method z jednym krokiem tworzącym obiekty |
| Budowniczy (Builder) | Uzupełnienie — do konstruowania złożonych obiektów krok po kroku |
| Dekorator | Kontrast — dodaje zachowanie bez dziedziczenia |
| Łańcuch Zobowiązań | Podobieństwo — też definiuje pipeline, ale kroki są dynamiczne |

---

## Częste pytania studentów

**P: Dlaczego nie użyć interfejsu zamiast klasy abstrakcyjnej?**  
O: Interfejs nie może zawierać metody szablonowej z implementacją kroków wspólnych (pre-C# 8). Wzorzec wymaga kodu wspólnego w klasie bazowej.

**P: Czy można używać Template Method z interfejsami w C# 8+?**  
O: Tak, `default interface methods` pozwalają na implementację domyślną w interfejsach. Ale klasa abstrakcyjna jest nadal idiomatyczna dla tego wzorca.

**P: Jaka jest różnica między `abstract` a `virtual`?**  
O: `abstract` — podklasa MUSI zaimplementować (= primitive operation). `virtual` — podklasa MOŻE przesłonić (= hook).

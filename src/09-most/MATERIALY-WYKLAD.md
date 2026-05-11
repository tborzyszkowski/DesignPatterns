# Materiały wykladowe - Wzorzec Most (Bridge)

## Cel wykładu

Przekazac wiedze o wzorcu Most: motywacje, strukturę GoF, kryteria decyzji i
najczestsze pulapki implementacyjne.

## Plan wykładu (90 minut)

1. Motywacja i problem eksplozji klas (15 min).
2. Idea rozdzialu abstrakcji i implementacji (15 min).
3. Formalna struktura GoF (20 min).
4. Warianty implementacji: statyczny, dynamiczny, factory (15 min).
5. Duzszy przykład (system notyfikacji) i alternatywy (15 min).
6. Most w bibliotekach standardowych (10 min).

## Material do tablicy / slajdow

### Slajd 1 — Problem eksplozji

Bez Mostu (dziedziczenie):

1. BasicRemoteTv, BasicRemoteRadio, BasicRemoteProjector
2. AdvancedRemoteTv, AdvancedRemoteRadio, AdvancedRemoteProjector
3. n pilotów * m urządzeń = n*m klas

Z Mostem:

1. BasicRemote, AdvancedRemote (2 klasy abstrakcji)
2. TvDevice, RadioDevice, ProjectorDevice (3 klasy implementacji)
3. razem: n + m klas, nie n*m

### Slajd 2 — Formalna struktura GoF

Cztery role:

1. Abstraction — interfejs domenowy dla klienta, trzyma referencje do Implementora.
2. RefinedAbstraction — rozszerza Abstraction o dodatkowe operacje biznesowe.
3. Implementor — kontrakt techniczny, niezależny od Abstraction.
4. ConcreteImplementor — konkretne wykonanie Implementora.

Zasada: Abstraction deleguje do Implementora, nie dziedziczy go.

### Slajd 3 — Trzy warianty implementacji

1. Statyczny — implementor podawany przez konstruktor, nie zmieniany.
   Kiedy: stabilny deployment, mala skala.

2. Dynamiczny — implementor może byc podmieniany w runtime.
   Kiedy: tryby dzialania (np. offline/online), feature flags.

3. Factory + Bridge — fabrykę wybiera implementor na podstawie konfiguracji.
   Kiedy: pluginy, wiele srodowisk, DI container.

### Slajd 4 — Kryterium decyzji: Most vs Adapter vs Strategia

Pytanie klucz:

1. Integrujesz obce API? -> Adapter.
2. Podmiana algorytmu w jednej osi? -> Strategią.
3. Dwie niezależne osie zmienności? -> Most.

### Slajd 5 — Najczestsze pulapki

1. Leakage: if (implementor is ConcreteX) wewnatrz Abstraction — przenieс branch do implementora.
2. Przedwczesne Most: jesli klient nigdy nie podmienia implementora, wystarczy Strategia lub DI.
3. Mylenie z Adaptera: Adapter laczy niekompatybilne API, Most projektuje nowe niezależne osie.
4. Hard-coded implementor: new Concrete() w Abstraction — zawsze wstrzykuj przez konstruktor lub fabrykę.

## FAQ

### Czy Most to tylko "zdublowany polimorfizm"?

Nie. Most rozdziela dwie niezależne osie zmienności tak, że każda może się rozwijac
bez wiedzy o drugiej. Polimorfizm jest mechanizmem, Most jest architektoniczna decyzja
projektowa dotyczaca podzialu odpowiedzialnosci.

### Kiedy Most jest overengineering?

Gdy istnieje tylko jedna oś zmienności lub gdy problem jest stabilny i maly.
W takim przypadku wystarczy Strategia (jedna oś że zmieniajacym się algorytmem)
albo prosty DI.

### Jak Most wspolpracuje z DI Container?

Implementor jest rejestrowany w kontenerze jako interfejs (IDevice, IChannel itd.).
Abstraction wstrzykuje go przez konstruktor, nie tworzac bezpośrednio instancji.
Factory + Bridge to wariant, gdzie fabryka opakowuje kontener lub konfiguracje.

### Czym Most rozni się od Dekoratora?

Dekorator owija ten sam interfejs, dodajac zachowanie warstw.
Most posiada dwa roznei interfejsy: domenowy (Abstraction) i techniczny (Implementor).
Dekorator jest jednoosiowy, Most jest dwojosiowy.

### Czym Most rozni się od Strategii w runtime?

Oba wzorce umozliwiaja podmiane zachowania w runtime.
Roznica jest semantyczna: Strategia podmienia algorytm w jednej osi.
Most rozdziela dwa calkowicie niezależne wymiary, gdzie każdy może miec wiele wariantow.

## Literatura

1. GoF, Design Patterns, rozdział Bridge.
2. Refactoring.Guru (Bridge): https://refactoring.guru/design-patterns/bridge
3. Martin Fowler, Patterns of Enterprise Application Architecture.
4. Microsoft Docs, ILogger: https://learn.microsoft.com/dotnet/api/microsoft.extensions.logging.ilogger

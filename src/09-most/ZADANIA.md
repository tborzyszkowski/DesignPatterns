# ZADANIA - Wzorzec Most

## Zadanie 1 - Dodaj nowego implementora

Masz działający kod Mostu: RemoteControl -> DeviceImplementor.

Wymagania:

1. Dodaj nowy implementor VideoDevice.
2. Nie modyfikuj klasy Abstraction.

Rozwiązanie (skrót):

1. Dodaj klasę VideoDevice : IDevice.
2. Wstrzyknij ją do istniejącej Abstraction przez konstruktor.

## Zadanie 2 - Most vs Adapter

Wymagania:

1. Rozwiąż ten sam problem Mostem i Adaptorem.
2. Porównaj koszt dodania nowej osi zmienności.

Rozwiązanie (skrót):

1. Adapter pomogą przy integracji istniejącego API.
2. Most wygrywa przy niezależnym rozwoju dwóch osi.

## Zadanie 3 - Wykryj leakage

W kodzie Abstraction pojawiło się if (implementor is ConcreteX).

Wymagania:

1. Usuń przeciek implementacji.
2. Zostaw decyzję po stronie implementora.

Rozwiązanie (skrót):

1. Dodaj metode kontraktowa do interfejsu implementora.
2. Przenieś branch do konkretnych klas implementora.

## Zadanie 4 - Factory + Bridge

Wymagania:

1. Dodaj fabrykę implementorów na podstawie konfiguracji.
2. Klient ma tworzyć tylko abstrakcje i podawać typ.

Rozwiązanie (skrót):

1. DeviceFactory.Create(kind) zwraca IDevice.
2. Abstraction pozostaje czysta, bez new Concrete... .

## Zadanie 5 - Kryterium decyzji

Dla trzech scenariuszy wybierz: Most / Adapter / Strategia.

Rozwiązanie (skrót):

1. Most: dwie osie zmienności rozwijane niezależnie.
2. Adapter: integracja niekompatybilnych API.
3. Strategia: podmiana algorytmu w jednej osi.

### Szablon checklisty decyzyjnej (do wypełnienia)

Użyj szablonu dla każdego scenariusza. Oznacz TAK/NIE i wpisz decyzję.

Scenariusz: ______________________________

1. Czy glowny problem to integracja obcego API? [ ] TAK [ ] NIE
2. Czy model domenowy ma zostać bez zmian? [ ] TAK [ ] NIE
3. Czy zmienia się głównie algorytm? [ ] TAK [ ] NIE
4. Czy masz tylko jedna oś zmienności? [ ] TAK [ ] NIE
5. Czy masz co najmniej dwie osie zmienności? [ ] TAK [ ] NIE
6. Czy osie będą rozwijane niezależnie? [ ] TAK [ ] NIE
7. Czy grozi eksplozja klas typu XViaY? [ ] TAK [ ] NIE

Wniosek (zaznacz jedno):

## Pytania kontrolne

1. Co odroznia Most od Adaptera — jaki jest glowny kryterium wyboru?
2. Czym jest oś zmienności w kontekście wzorca Most i podaj przykład dwóch osi?
3. Co to jest leakage implementacji w Abstraction i jak go wyeliminowac?
4. Kiedy Most jest overengineering — wymien dwa sygnały ostrzegawcze?
5. Jakie sa trzy warianty implementacji Mostu i kiedy stosować każdy z nich?
6. Czym rozni się Most od Strategii przy podmianach runtime?

1. [ ] Adapter
2. [ ] Strategia
3. [ ] Most

Uzasadnienie (2-3 zdania):

____________________________________________________________
____________________________________________________________

Szybka podpowiedz:

1. Integracja obcego API -> Adapter.
2. Jedna oś i podmiana algorytmu -> Strategią.
3. Dwie osie rozwijane niezależnie -> Most.

# ZADANIA - Wzorzec Most

## Zadanie 1 - Dodaj nowego implementora

Masz dzialajacy kod Mostu: RemoteControl -> DeviceImplementor.

Wymagania:

1. Dodaj nowy implementor VideoDevice.
2. Nie modyfikuj klasy Abstraction.

Rozwiazanie (skrot):

1. Dodaj klase VideoDevice : IDevice.
2. Wstrzyknij ja do istniejacej Abstraction przez konstruktor.

## Zadanie 2 - Most vs Adapter

Wymagania:

1. Rozwiaz ten sam problem Mostem i Adaptorem.
2. Porownaj koszt dodania nowej osi zmiennosci.

Rozwiazanie (skrot):

1. Adapter pomoga przy integracji istniejacego API.
2. Most wygrywa przy niezaleznym rozwoju dwoch osi.

## Zadanie 3 - Wykryj leakage

W kodzie Abstraction pojawilo sie if (implementor is ConcreteX).

Wymagania:

1. Usun przeciek implementacji.
2. Zostaw decyzje po stronie implementora.

Rozwiazanie (skrot):

1. Dodaj metode kontraktowa do interfejsu implementora.
2. Przenies branch do konkretnych klas implementora.

## Zadanie 4 - Factory + Bridge

Wymagania:

1. Dodaj fabryke implementorow na podstawie konfiguracji.
2. Klient ma tworzyc tylko abstrakcje i podawac typ.

Rozwiazanie (skrot):

1. DeviceFactory.Create(kind) zwraca IDevice.
2. Abstraction pozostaje czysta, bez new Concrete... .

## Zadanie 5 - Kryterium decyzji

Dla trzech scenariuszy wybierz: Most / Adapter / Strategia.

Rozwiazanie (skrot):

1. Most: dwie osie zmiennosci rozwijane niezaleznie.
2. Adapter: integracja niekompatybilnych API.
3. Strategia: podmiana algorytmu w jednej osi.

### Szablon checklisty decyzyjnej (do wypelnienia)

Uzyj szablonu dla kazdego scenariusza. Oznacz TAK/NIE i wpisz decyzje.

Scenariusz: ______________________________

1. Czy glowny problem to integracja obcego API? [ ] TAK [ ] NIE
2. Czy model domenowy ma zostac bez zmian? [ ] TAK [ ] NIE
3. Czy zmienia sie glownie algorytm? [ ] TAK [ ] NIE
4. Czy masz tylko jedna os zmiennosci? [ ] TAK [ ] NIE
5. Czy masz co najmniej dwie osie zmiennosci? [ ] TAK [ ] NIE
6. Czy osie beda rozwijane niezaleznie? [ ] TAK [ ] NIE
7. Czy grozi eksplozja klas typu XViaY? [ ] TAK [ ] NIE

Wniosek (zaznacz jedno):

## Pytania kontrolne

1. Co odroznia Most od Adaptera — jaki jest glowny kryterium wyboru?
2. Czym jest os zmiennosci w kontekscie wzorca Most i podaj przyklad dwoch osi?
3. Co to jest leakage implementacji w Abstraction i jak go wyeliminowac?
4. Kiedy Most jest overengineering — wymien dwa sygnaly ostrzegawcze?
5. Jakie sa trzy warianty implementacji Mostu i kiedy stosowac kazdy z nich?
6. Czym rozni sie Most od Strategii przy podmianach runtime?

1. [ ] Adapter
2. [ ] Strategia
3. [ ] Most

Uzasadnienie (2-3 zdania):

____________________________________________________________
____________________________________________________________

Szybka podpowiedz:

1. Integracja obcego API -> Adapter.
2. Jedna os i podmiana algorytmu -> Strategia.
3. Dwie osie rozwijane niezaleznie -> Most.

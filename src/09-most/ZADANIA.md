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

# Zadania dla studentów - Adapter

## Zadanie 1 - Adapter bazowy

Treść:
W [03-struktura-gof/Examples/Program.cs](03-struktura-gof/Examples/Program.cs) dodaj drugą klasę Adaptee z innym formatem danych i stwórz drugi adapter do tego samego Target.

Rozwiązanie (skrót):

1. Dodaj nowy interfejs źródłowy.
2. Zaimplementuj adapter mapujący do `ITarget`.
3. Uruchom scenariusz z dwoma adapterami w tej samej logice klienta.

Omówienie:
To ćwiczenie pokazuje zasadę Open/Closed i separację klienta od dostawcy API.

## Zadanie 2 - Metryki decyzji

Treść:
W [02-kiedy-stosowac/Examples/Program.cs](02-kiedy-stosowac/Examples/Program.cs) zmień parametry kosztu integracji i policz, kiedy adaptacja staje się opłacalna.

Rozwiązanie (skrót):

1. Zmień `legacyCallMs` i `mappingMs`.
2. Porównaj czas całkowity i odsetek błędów.
3. Uzasadnij decyzję: adapter czy refaktoryzacja klienta.

Omówienie:
Adapter to decyzja ekonomiczna, nie tylko techniczna.

## Zadanie 3 - Two Way Adapter

Treść:
W [06-two-way-adapter/Examples/Program.cs](06-two-way-adapter/Examples/Program.cs) dodaj walidację, żeby adapter odrzucał niepoprawny stan wejścia z obu kierunków.

Rozwiązanie (skrót):

1. Dodaj walidację w metodach obu interfejsów.
2. Zwracaj czytelny wyjątek domenowy.
3. Pokryj przypadki testowymi danymi wejściowymi.

Omówienie:
Two Way Adapter zwiększa elastyczność, ale też ryzyko błędów semantycznych.

## Zadanie 4 - Pluggable Adapter

Treść:
W [07-pluggable-adapter/Examples/Program.cs](07-pluggable-adapter/Examples/Program.cs) dodaj nowy plugin adaptera i zarejestruj go bez zmian kodu klienta.

Rozwiązanie (skrót):

1. Utwórz nową klasę implementującą `IMessageAdapter`.
2. Dodaj wpis do rejestru.
3. Udowodnij, że klient działa bez modyfikacji.

Omówienie:
To praktyczny wzorzec dla architektury pluginowej i integracji zewnętrznych.

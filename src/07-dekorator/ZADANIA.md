# ZADANIA - Wzorzec Dekorator

## Zadanie 1 (podstawowe)

Temat: [01-idea-i-kontekst](01-idea-i-kontekst/README.md)

Polecenie:

Dodaj dekorator `UppercaseDecorator` do `IMessageSender`.

Rozwiązanie (skrót):

1. Utwórz klasę dziedziczącą po `SenderDecorator`.
2. W `Send` przekształć wiadomość do `ToUpperInvariant()`.
3. Owiń nią istniejący łańcuch dekoratorów.

Wyjaśnienie:

To ćwiczenie utrwala najważniejszą cechę wzorca: rozszerzanie zachowania przez kompozycję.

## Zadanie 2 (decyzyjne)

Temat: [02-kiedy-stosowac](02-kiedy-stosowac/README.md)

Polecenie:

Porównaj narzut dla łańcucha 1-warstwowego, 2-warstwowego i 4-warstwowego.

Rozwiązanie (skrót):

1. Zbuduj trzy warianty dekorowania eksportera.
2. Dla każdego policz czas i `overhead`.
3. Zestaw wyniki w tabeli.

Wyjaśnienie:

Wzorzec jest wartościowy, gdy koszt warstw jest mniejszy niż zysk architektoniczny.

## Zadanie 3 (struktura GoF)

Temat: [03-struktura-gof](03-struktura-gof/README.md)

Polecenie:

Dodaj `UnderlineDecorator` oraz `ColorDecorator`.

Rozwiązanie (skrót):

1. Obie klasy dziedziczą po `TextDecorator`.
2. Każda modyfikuje `Render()` i deleguje do `Inner.Render()`.

Wyjaśnienie:

Każdy dekorator powinien realizować pojedynczą odpowiedzialność (SRP).

## Zadanie 4 (warianty implementacji)

Temat: [04-implementacje-i-typy](04-implementacje-i-typy/README.md)

Polecenie:

Przepisz wariant funkcyjny na pipeline konfigurowany z tablicy kroków.

Rozwiązanie (skrót):

1. Utwórz listę funkcji `Func<string,string>`.
2. Iteruj po krokach i akumuluj wynik.

Wyjaśnienie:

To pokazuje przejście od klasycznego Decoratora do stylu pipeline/DI.

## Zadanie 5 (Starbuzz)

Temat: [05-kawiarnia-starbuzz](05-kawiarnia-starbuzz/README.md)

Polecenie:

Dodaj dodatek `Caramel` i dekorator `HappyHour` (-10%).

Rozwiązanie (skrót):

1. `Caramel` zwiększa koszt i opis.
2. `HappyHour` modyfikuje wynik `Cost()` po delegacji.

Wyjaśnienie:

Dekoratory mogą zarówno dodawać, jak i modyfikować końcowy wynik.

## Zadanie 6 (BCL Stream)

Temat: [06-dekoratory-bcl-stream](06-dekoratory-bcl-stream/README.md)

Polecenie:

Podmień `GZipStream` na `BrotliStream` i porównaj rozmiar danych.

Rozwiązanie (skrót):

1. Zamień typ strumienia kompresującego.
2. Uruchom program dla tego samego payloadu.
3. Porównaj rozmiar `byte[]`.

Wyjaśnienie:

To ćwiczenie łączy teorię Dekoratora z praktyką bibliotek standardowych .NET.

## Pytania kontrolne

1. Czym różni się Dekorator od dziedziczenia i kiedy kompozycja jest lepszym wyborem?
2. Jakie są cztery role GoF we wzorcu Dekorator i za co każda jest odpowiedzialna?
3. Co to jest efekt eksplozji klas i jak Dekorator go eliminuje?
4. Jakie są trzy typy implementacji Dekoratora w C# i kiedy stosować każdy z nich?
5. Dlaczego kolejność zagnieżdżania dekoratorów ma znaczenie — podaj przykład z kodem?
6. W jaki sposób `GZipStream(BufferedStream(MemoryStream))` realizuje wzorzec Dekorator w BCL?

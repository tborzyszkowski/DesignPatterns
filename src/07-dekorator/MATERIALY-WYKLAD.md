# Materialy wykladowe - Wzorzec Dekorator (Decorator)

## Cel wykladu

Przekazac wiedze o wzorcu Dekorator: motywacje, role GoF, typy implementacji w C#,
kryteria decyzji i zwiazek z bibliotekami standardowymi.

## Plan wykladu (90 minut)

1. Problem eksplozji klas przez dziedziczenie (10 min).
2. Idea Dekoratora: kompozycja zamiast dziedziczenia (15 min).
3. Formalna struktura GoF: role, diagram klas i sekwencji (20 min).
4. Trzy typy implementacji: klasyczny, funkcyjny, pipeline (20 min).
5. Wiekszy przyklad Starbuzz Coffee (15 min).
6. Dekoratory w BCL: Stream i jego warianty (10 min).

## Material do tablicy / slajdow

### Slajd 1 - Problem eksplozji klas

Bez Dekoratora (dziedziczenie):

1. EmailSender, LoggingEmailSender, SignatureEmailSender
2. LoggingSignatureEmailSender, SignatureLoggingEmailSender
3. n cech ortogonalnych = 2^n kombinacji klas

Z Dekoratorem (kompozycja):

1. EmailSender (baza)
2. LoggingDecorator (1 klasa)
3. SignatureDecorator (1 klasa)
4. Kombinacje skladamy w runtime: n klas, nie 2^n

### Slajd 2 - Idea wzorca

Kluczowa zasada: dekorator implementuje ten sam interfejs co opakowywany obiekt.

1. Client <- IMessageSender
2. EmailSender implementuje IMessageSender
3. SenderDecorator implementuje IMessageSender i trzyma IMessageSender
4. LoggingDecorator extends SenderDecorator - dodaje logowanie

Efekt: klient nie wie ile warstw opakowuje obiekt bazowy.

### Slajd 3 - Formalna struktura GoF

Cztery role:

1. Component - wspolny kontrakt (interfejs lub klasa abstrakcyjna).
2. ConcreteComponent - bazowa implementacja.
3. Decorator - klasa abstrakcyjna opakowujaca Component przez kompozycje.
4. ConcreteDecorator - konkretne rozszerzenie zachowania.

Zasada: Decorator IS-A Component i HAS-A Component.

### Slajd 4 - Kolejnosc dekoratorow ma znaczenie

Przyklad:

```
LoggingDecorator(SignatureDecorator(EmailSender))
-> LOG: "Hello\n-- Podpis" -> EMAIL: "Hello\n-- Podpis"

SignatureDecorator(LoggingDecorator(EmailSender))
-> SIGN("Hello" -> LOG("Hello") -> EMAIL("Hello")) -> doda podpis po zalogowaniu
```

Kolejnosc to czesc logiki biznesowej - dokumentuj ja.

### Slajd 5 - Trzy typy implementacji w C#

1. Klasyczny (GoF): interfejs + klasy dekoratorow.
   Zaleta: jawna struktura, testowalnosc.
   Wada: wiele klas.

2. Funkcyjny (Func<T,T>): lambda opakowuje lambde.
   Zaleta: zwiezlosc, lambda inline.
   Wada: trudny debuggging, brak nazw warstw.

3. Pipeline / DI (lista krokow): `List<Func<string,string>>`.
   Zaleta: konfigurowalny runtime, latwy DI.
   Wada: utrata statycznej struktury.

### Slajd 6 - Dekoratory w BCL .NET

```
MemoryStream (ConcreteComponent)
    <- BufferedStream (Decorator: buforowanie odczytow/zapisow)
        <- GZipStream (Decorator: kompresja)
            <- StreamWriter (ConcreteDecorator: encoding)
```

Kazdy stream implementuje Stream i opakowuje inny Stream.
To wzorzec Dekoratora w czysto obiektowym wydaniu.

## FAQ

### Czym Dekorator rozni sie od Strategii?

Strategia podmienia jeden algorytm w jednej osi zmiennosci.
Dekorator skladuje warstwy ortogonalnych zachowan, kazda niezalezna.
Mozna laczyc: Dekorator jako warstwa moze delegowac do Strategii wewnatrz.

### Czym Dekorator rozni sie od Lancucha Zobowiazan?

W Lancuchu zobowiazan kazde ogniwo decyduje czy przekazac dalej - jest to
jednokierunkowy przepyw z mozliwoscia zatrzymania.
W Dekoratorze kazda warstwa zawsze wywoluje nastepna I przetwarza wynik.

### Kiedy uzyc interfejsu a kiedy klasy abstrakcyjnej jako Component?

Interfejs: gdy nie ma wspolnego kodu wspoldzielonego miedzy dekoratorami.
Klasa abstrakcyjna: gdy masz wspolna logike w Decorator (np. przechowywanie inner).
W C# czesciej: interfejs dla Component + abstrakcyjna klasa bazowa dla Decorator.

### Jak testowac dekoratory?

1. Testuj kazdy dekorator z fake/stub obiektu wewnetrznego.
2. Testuj lancuch jako calosci - zachowanie stacked przez kontrakt.
3. Nie testuj przez refleksje ile warstw jest w lancuchu.

### Jak unikac god-decorator?

Jeden dekorator = jedna odpowiedzialnosc.
Jezeli dekorator ma if/else w kilku odpowiedzialnosciach - podziel na wiecej klas.

## Literatura

1. GoF, Design Patterns, rozdzial Decorator.
2. Refactoring.Guru (Decorator): https://refactoring.guru/design-patterns/decorator
3. Head First Design Patterns, rozdzial Starbuzz Coffee.
4. Microsoft Docs, Stream: https://learn.microsoft.com/dotnet/api/system.io.stream
5. Microsoft Docs, GZipStream: https://learn.microsoft.com/dotnet/api/system.io.compression.gzipstream

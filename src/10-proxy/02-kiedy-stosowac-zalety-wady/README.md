# 02. Kiedy stosowac Proxy - zalety i wady

## Cel tematu

Nauczyc sie podejmowac decyzje: kiedy Proxy rozwiazuje problem, jaki typ Proxy wybrac, a kiedy lepiej wybrac inny wzorzec.

## Krok 1 - czy w ogole Proxy?

Pytania filtrujace:

1. Chcesz zachowac ten sam kontrakt co RealSubject dla klienta? **[jesli TAK - Proxy kandyduje]**
1. Chcesz dodac logike kontrolna/infrastrukturalna bez zmiany kodu klienta? **[jesli TAK - Proxy kandyduje]**
1. Chcesz zmienic interfejs obcego API? **[jesli TAK - Adapter, nie Proxy]**
1. Chcesz warstwowo nakladac zachowania (dekorowanie)? **[jesli TAK - Dekorator, nie Proxy]**
1. Chcesz zmienic algorytm obliczen? **[jesli TAK - Strategia, nie Proxy]**

## Krok 2 - jaki typ Proxy?

Jesli przeszles krok 1 i wybrales Proxy, dobierz typ:

```
Potrzebujesz kontroli uprawnien przed wywolaniem?
  TAK => Protection Proxy
  NIE => kontynuuj

Tworzenie RealSubject jest kosztowne i moze byc niepotrzebne?
  TAK => Virtual Proxy
  NIE => kontynuuj

RealSubject jest na innym hoscie (siec, RPC, REST)?
  TAK => Remote Proxy
  NIE => kontynuuj

Wyniki sa stabilne i chcesz zaoszczedzic na wielokrotnych wywolaniach?
  TAK => Caching Proxy
  NIE => rozważ Logging/Monitoring Proxy (cross-cutting concerns)
```

![Proxy decision map](diagrams/proxy_decision_map.png)

Zrodlo: [diagrams/01-decision-map.puml](diagrams/01-decision-map.puml)

## Krok 3 - Proxy vs inne wzorce (pelna tabela)

| Pytanie kluczowe | Wzorzec | Uzasadnienie |
|---|---|---|
| Zmieniasz kontrakt obcego API? | **Adapter** | Adapter transluje sygnature - Proxy jej nie zmienia |
| Ten sam kontrakt + kontrola uprawnien? | **Protection Proxy** | Pilnuje polityk bez wiedzy klienta |
| Ten sam kontrakt + lazy init? | **Virtual Proxy** | Odklada koszt tworzenia do momentu uzycia |
| Ten sam kontrakt + ukrycie sieci? | **Remote Proxy** | Klient mysli, ze wywoluje lokalny obiekt |
| Ten sam kontrakt + cache wynikow? | **Caching Proxy** | Zwraca zapamietany wynik zamiast delegowac |
| Ten sam kontrakt + warstwowe rozszerzanie? | **Dekorator** | Dekorator naklada nowe zachowanie addytywnie |
| Podmiana algorytmu w jednej osi? | **Strategia** | Strategia zmienia co sie oblicza, nie kto ma dostep |

![Proxy vs patterns](diagrams/proxy_vs_patterns.png)

Zrodlo: [diagrams/02-proxy-vs-patterns.puml](diagrams/02-proxy-vs-patterns.puml)

## Scenariusze decyzyjne - przyklady z zycia

### Scenariusz A: serwis raportow - kto moze usuwac?

Masz `IReportService`. Chcesz, zeby `DeleteAllReports()` bylo dostepne tylko dla admina.

1. Czy zmieniasz kontrakt? [NIE]
1. Czy to kontrola uprawnien? [TAK]
1. Decyzja: **Protection Proxy**.

Koszt rozszerzenia: 1 klasa `ReportServiceProxy`, klient bez zmian.

### Scenariusz B: galeria obrazow - ladowanie tylko gdy potrzebne

Masz `IImage`. Obraz wazy 50 MB. Uzytkownik moze nigdy nie otworzyc galerii.

1. Czy zmieniasz kontrakt? [NIE]
1. Czy tworzenie jest kosztowne i moze byc odlozone? [TAK]
1. Decyzja: **Virtual Proxy**.

Koszt rozszerzenia: 1 klasa `ImageProxy`, klient bez zmian.

### Scenariusz C: zewnetrzny serwis platnosci - ukrycie HTTP

Masz kontrakt `IPaymentGateway`. Implementacja to wywolanie REST API.

1. Czy zmieniasz kontrakt? [NIE - tworzysz wlasny kontrakt i ukrywasz HTTP]
1. Czy RealSubject jest zdalny? [TAK]
1. Decyzja: **Remote Proxy**.

Klient wywoluje `IPaymentGateway.Pay()` jak lokalny obiekt.

### Scenariusz D: wyszukiwarka produktow - wyniki sie powtarzaja

Masz `IProductSearch`. Zapytanie do bazy trwa 300 ms. Te same frazy wyszukiwane wielokrotnie.

1. Czy zmieniasz kontrakt? [NIE]
1. Czy wyniki sa stabilne w czasie? [TAK - TTL 5 min]
1. Decyzja: **Caching Proxy**.

Koszt rozszerzenia: 1 klasa z `Dictionary<string, Product[]>`, klient bez zmian.

### Scenariusz E: nowy dostawca kuriera - inny interfejs

Masz `IDeliveryService`. Nowy kurier ma API z innymi metodami i typami.

1. Czy zmieniasz kontrakt? [TAK - translacja sygnatury]
1. Decyzja: **Adapter**, nie Proxy.

## Checklista decyzyjna - szablon 10 sekund

```
Pytanie                                    TAK/NIE  Wzorzec
------------------------------------------------------
Zmieniam kontrakt obcego API?              [ ]      Adapter
Ten sam kontrakt + kontrola uprawnien?     [ ]      Protection Proxy
Ten sam kontrakt + lazy init?              [ ]      Virtual Proxy
Ten sam kontrakt + ukrycie sieci?          [ ]      Remote Proxy
Ten sam kontrakt + cache wynikow?          [ ]      Caching Proxy
Ten sam kontrakt + nakladam warstwy?       [ ]      Dekorator
Podmiana algorytmu (jedna os)?             [ ]      Strategia
```

## Kiedy nie stosowac Proxy

1. Logika posrednia jest minimalna i jednorazowa - prosta kompozycja wystarczy.
1. Masz juz middleware (np. ASP.NET pipeline) realizujacy ten cel.
1. Narzut na debugowanie i wydajnosc przewyzsza zysk.
1. Liczba interfejsow jest duza - rozważ Dynamic Proxy zamiast Static.

## Zalety

1. Separacja odpowiedzialnosci infrastrukturalnych od domenowych.
1. Lepsza kontrola dostepu i obserwowalnosc.
1. Zachowanie jednego kontraktu dla klienta.
1. Latwa wymiana Proxy bez zmian klienta lub RealSubject.

## Wady

1. Wiecej klas i poziomow wywolan.
1. Trudniejsza diagnostyka bledow (szczegolnie Dynamic Proxy).
1. Potencjalny narzut runtime.
1. Ryzyko logiki biznesowej w Proxy zamiast w RealSubject.

## Typowe bledy

1. Uzywanie Proxy do zmiany interfejsu - to Adapter.
1. Wkladanie logiki domenowej do Proxy - SRP naruszone.
1. Wiele warstw proxy bez metryk - trudny debugging.
1. Brak testow dla sciezki dostepu zabronionego.

## Kod przykladu

Kod: [Examples/Program.cs](Examples/Program.cs)

Program demonstruje Virtual Proxy z leniwym ladowaniem obrazu. Obiekt `ImageProxy` nie tworzy `RealImage`
dopoki klient nie wywola `Display()` po raz pierwszy. Drugie wywolanie nie powoduje ponownego ladowania.

```bash
cd src/10-proxy/02-kiedy-stosowac-zalety-wady/Examples
dotnet run
```

## Dalsze kroki

1. Static Proxy z kontrola uprawnien: [../04-static-proxy/README.md](../04-static-proxy/README.md)
1. Dynamic Proxy i interception runtime: [../05-dynamic-proxy-csharp/README.md](../05-dynamic-proxy-csharp/README.md)

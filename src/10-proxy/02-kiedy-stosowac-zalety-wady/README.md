# 02. Kiedy stosowac Proxy - zalety i wady

## Cel tematu

Nauczyc sie podejmowac decyzje, kiedy Proxy rozwiazuje problem, a kiedy lepiej wybrac inny wzorzec.

## Sygnaly, ze warto

1. Potrzebujesz kontroli dostepu do operacji.
2. Tworzenie obiektu jest kosztowne i chcesz lazy init.
3. Chcesz dodac cache/logowanie bez zmian klienta.
4. Chcesz ukryc zdalne wywolanie za lokalnym interfejsem.

## Diagram decyzji

![Proxy decision map](diagrams/proxy_decision_map.png)

Zrodlo: [diagrams/01-decision-map.puml](diagrams/01-decision-map.puml)

Interpretacja mapy:

1. Jesli kontrakt ma pozostac ten sam i chcesz kontrolowac dostep, zwykle wybierasz Proxy.
2. Jesli musisz zmienic kontrakt obcego API, zwykle wybierasz Adapter.
3. Jesli chcesz glownie nakladac zachowania warstwowo, sprawdz Dekorator.

## Kiedy nie

1. Logika posrednia jest minimalna i jednorazowa.
2. Prostsza kompozycja lub middleware wystarczy.
3. Narzut na debugging i wydajnosc przewyzsza zysk.

## Zalety

1. Separacja odpowiedzialnosci infrastrukturalnych.
2. Lepsza kontrola dostepu i obserwowalnosc.
3. Zachowanie jednego kontraktu dla klienta.

## Wady

1. Wiecej klas i poziomow wywolan.
2. Trudniejsza diagnostyka bledow.
3. Potencjalny narzut runtime (szczegolnie dynamiczny proxy).

## Typowe bledy decyzyjne

1. Uzywanie Proxy do zmiany interfejsu (to zwykle Adapter).
2. Wkladanie logiki biznesowej do Proxy zamiast do RealSubject.
3. Dodawanie wielu warstw proxy bez monitoringu i metryk.
4. Brak testow dla scenariuszy dostepu zabronionego i bledow.

## Krotka checklista decyzyjna

Scenariusz: obce API, inny kontrakt -> **Adapter**.

Scenariusz: ta sama umowa, kontrola dostepu/lazy/cache -> **Proxy**.

Scenariusz: jedna os podmiany algorytmu -> **Strategia**.

Scenariusz: rozszerzanie odpowiedzialnosci obiektu warstwowo -> **Dekorator**.

## Przykladowy program C# (Virtual Proxy)

Ponizej prosty przyklad pokazuje, kiedy Proxy jest lepszy niz bezposredni dostep: ciezki obiekt tworzony jest dopiero przy pierwszym uzyciu.

```csharp
interface IImage
{
	void Display();
}

sealed class RealImage : IImage
{
	private readonly string _path;

	public RealImage(string path)
	{
		_path = path;
		Console.WriteLine($"Loading image from disk: {_path}");
		Thread.Sleep(300); // symulacja kosztu I/O
	}

	public void Display()
	{
		Console.WriteLine($"Displaying {_path}");
	}
}

sealed class ImageProxy : IImage
{
	private readonly string _path;
	private RealImage? _realImage;

	public ImageProxy(string path)
	{
		_path = path;
	}

	public void Display()
	{
		_realImage ??= new RealImage(_path);
		_realImage.Display();
	}
}

IImage image = new ImageProxy("hero-banner.png");

Console.WriteLine("Proxy created. No disk load yet.");
image.Display(); // tutaj dopiero lazy init RealImage
image.Display(); // drugi raz bez kosztu tworzenia
```

### Co ten przyklad udowadnia?

1. Klient pracuje na tym samym kontrakcie (`IImage`).
2. Koszt tworzenia ciezkiego obiektu jest odlozony do momentu potrzeby.
3. Decyzja o lazy loading jest zamknieta w Proxy, nie w kliencie.
4. Ten scenariusz to klasyczny przypadek dla Virtual Proxy.

## Przykladowy program C#

Kod: [Examples/Program.cs](Examples/Program.cs)

Program demonstruje Virtual Proxy z leniwym ladowaniem obrazu. Obiekt `ImageProxy` nie tworzy `RealImage`
dopoki klient nie wywoula `Display()` po raz pierwszy. Drugie wywolanie nie powoduje ponownego ladowania.

```bash
cd src/10-proxy/02-kiedy-stosowac-zalety-wady/Examples
dotnet run
```

## Dalsze kroki

1. Static Proxy z kontrola uprawnien: [../04-static-proxy/README.md](../04-static-proxy/README.md)
2. Dynamic Proxy i interception runtime: [../05-dynamic-proxy-csharp/README.md](../05-dynamic-proxy-csharp/README.md)

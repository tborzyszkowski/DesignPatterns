# Observer

[Opis wzorca Observer](https://www.oodesign.com/observer-pattern.html)

## Zadania

1. Do każdej z prezentowanych implementacji wzorca obserwator dodać obserwatora wyliczającego 
	[Heat Index](https://en.wikipedia.org/wiki/Heat_index) wg wzoru:
	```
	// rh - humidity
	// t  - temperature
	heatIndex = (float)
				(
				(16.923 + (0.185212 * t)) + 
				(5.37941 * rh) - 
				(0.100254 * t * rh) + 
				(0.00941695 * (t * t)) + 
				(0.00728898 * (rh * rh)) + 
				(0.000345372 * (t * t * rh)) - 
				(0.000814971 * (t * rh * rh)) +
				(0.0000102102 * (t * t * rh * rh)) - 
				(0.000038646 * (t * t * t)) + 
				(0.0000291583 * (rh * rh * rh)) +
				(0.00000142721 * (t * t * t * rh)) + 
				(0.000000197483 * (t * rh * rh * rh)) - 
				(0.0000000218429 * (t * t * t * rh * rh)) +
				(0.000000000843296 * (t * t * rh * rh * rh)) -
				(0.0000000000481975 * (t * t * t * rh * rh * rh)));
	```
2. Na giełdzie notowanie są akcje. Każda akcja posiada nazwę oraz cenę. Inwestorzy kupują akcje i śledzą ich notowania.
	Bazując na wzorcu obserwator zaimplementować klasy ``Share`` oraz ``Investor`` pozwalające modelować tę sytuację.

## Bibliografia

1. [Implement Observer Pattern in .NET (3 Techniques)](https://www.codeproject.com/Articles/796075/Implement-Observer-Pattern-in-NET-3-Techniques).
2. [Microsoft Docs: Observer Design Pattern](https://docs.microsoft.com/pl-pl/dotnet/standard/events/observer-design-pattern)
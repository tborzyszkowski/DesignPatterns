# 04. Implementacje i warianty

## Cel rozdziału

Po tym rozdziale student powinien umieć dobrać wariant implementacji do wymagań systemu.

---

## Główne warianty w .NET

1. **Manualny pool (`lock` + `Queue`)**

- prosty didaktycznie,
- słaby przy dużej współbieżności.

1. **Pool oparty o `ConcurrentBag`/`ConcurrentQueue`**

- mniejszy narzut blokad,
- nadal wymaga poprawnego resetu stanu.

1. **`Microsoft.Extensions.ObjectPool`**

- produkcyjne API,
- polityki tworzenia i zwrotu (`IPooledObjectPolicy<T>`),
- integracja z ASP.NET Core.

Jak czytać te warianty w praktyce:

1. Wariant manualny jest dobry do nauki wzorca i zrozumienia cyklu życia obiektu.
2. Wariant `ConcurrentBag` jest pomostem między dydaktyką a produkcją.
3. Wariant biblioteczny jest zwykle najlepszym punktem startowym w nowym projekcie.

Najczęstsze błędy implementacyjne:

1. Brak resetu stanu obiektu przy zwrocie do puli.
2. Brak limitu retencji i niekontrolowany wzrost pamięci.
3. Mieszanie obiektów współdzielonych między wątkami bez kontraktu thread-safe.

---

## Diagramy

### Eager vs Lazy

![Eager vs Lazy](diagrams/01-eager-vs-lazy.png)

Źródło: [diagrams/01-eager-vs-lazy.puml](diagrams/01-eager-vs-lazy.puml)

### Mapa wariantów

![Mapa wariantów](diagrams/02-variants-map.png)

Źródło: [diagrams/02-variants-map.puml](diagrams/02-variants-map.puml)

---

## Przykład C Sharp

Kod: [VariantsSample/Program.cs](VariantsSample/Program.cs)

Przykład uruchamia trzy warianty w tym samym scenariuszu:

1. `new StringBuilder` (baseline bez puli),
2. manualny pool oparty o `ConcurrentBag`,
3. `DefaultObjectPool<StringBuilder>` z własną polityką resetu.

Kluczowy fragment porównania:

```csharp
var noPoolMs = MeasureNoPool();
var manualMs = MeasureManualPool(manualPool);
var dotnetMs = MeasureDotnetPool(dotnetPool);

Console.WriteLine($"new StringBuilder   : {noPoolMs,5} ms");
Console.WriteLine($"manual ConcurrentBag: {manualMs,5} ms");
Console.WriteLine($"ObjectPool<T>       : {dotnetMs,5} ms");
```

Co to daje dydaktycznie:

1. Studenci widzą, że sam wzorzec to za mało, liczy się jakość implementacji.
2. Mają punkt odniesienia, czy pooling faktycznie poprawia wynik względem `new`.
3. Łatwo pokazać, że biblioteka platformowa często upraszcza kod i bywa szybsza.

Uruchom:

```bash
cd src/05-object-pool/04-implementacje-warianty/VariantsSample
dotnet run
```

---

## Rys historyczny (skrót)

| Okres | Dominujące podejście |
| --- | --- |
| .NET Framework (wczesne) | manualne pule i `lock` |
| .NET Core | `Concurrent*` + custom pools |
| ASP.NET Core | `Microsoft.Extensions.ObjectPool` |

---

## Jak interpretować wyniki

1. Jeśli `new` jest porównywalne z pulą, obiekt może być zbyt tani, aby uzasadnić pooling.
2. Jeśli manualny pool przegrywa z biblioteką, problemem jest narzut i jakość synchronizacji.
3. Jeśli pool wygrywa dopiero przy wyższej współbieżności, opłacalność zależy od ruchu produkcyjnego.

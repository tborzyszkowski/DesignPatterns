# 06. Dekorator w standardowych bibliotekach: Stream

## Cel tematu

Pokazać, że Dekorator jest realnie używany w .NET BCL i nie jest wyłącznie wzorcem akademickim.

## Co oznacza BCL

BCL (Base Class Library) to podstawowy zestaw bibliotek platformy .NET.
To warstwa, która dostarcza najważniejsze typy i API, m.in.:

1. kolekcje (`List<T>`, `Dictionary<TKey,TValue>`),
2. I/O (`Stream`, `FileStream`, `StreamReader`),
3. tekst i kodowanie (`String`, `Encoding`),
4. sieć, serializację, współbieżność i kryptografię.

Dlaczego to ważne w tym temacie:

- jeśli Dekorator występuje w BCL, to znaczy, że jest używany w realnym, produkcyjnym API,
- architektura strumieni w .NET jest jednym z najbardziej praktycznych przykładów wzorca Dekorator.

## Rys historyczny podejścia strumieniowego

1. Lata 80/90: systemy operacyjne i biblioteki języków zaczynają standaryzować pojęcie strumienia jako abstrakcji źródła/sinku bajtów.
2. Java (JDK 1.0, 1996): silna popularyzacja łańcuchów strumieni i opakowań (np. buforowanie, kodowanie, kompresja), czyli praktyczny mainstream dla podejścia dekoratorowego.
3. .NET Framework 1.0 (2002): `Stream` i klasy pochodne przenoszą ten styl do ekosystemu Microsoft.
4. .NET Core / .NET 5+: ten sam model jest kontynuowany i rozszerzany o nowoczesne API wydajnościowe oraz dodatkowe dekoratory (np. w kompresji i kryptografii).

Wniosek historyczny: to podejście przetrwało dekady, bo pozwala łączyć funkcje warstwowo bez mnożenia wariantów klas bazowych.

## Diagram klas Stream

![Stream class](diagrams/bcl_stream_class.png)

Źródło: [diagrams/01-stream-class.puml](diagrams/01-stream-class.puml)

## Diagram sekwencji zapisu

![Stream sequence](diagrams/bcl_stream_sequence.png)

Źródło: [diagrams/02-stream-sequence.puml](diagrams/02-stream-sequence.puml)

## Wyjaśnienie

Przykładowy łańcuch:

`MemoryStream -> BufferedStream -> GZipStream -> StreamWriter`

Każda warstwa dodaje odpowiedzialność:

1. `MemoryStream`: nośnik danych w pamięci.
2. `BufferedStream`: buforowanie I/O.
3. `GZipStream`: kompresja/dekompresja.
4. `StreamWriter` / `StreamReader`: konwersja tekst <-> bajty.

Dlaczego to jest Dekorator:

- każda kolejna warstwa przyjmuje obiekt wewnętrzny i rozszerza jego zachowanie,
- klient nadal pracuje z abstrakcją strumienia, ale zyskuje nowe funkcje (bufor, kompresja, kodowanie tekstu),
- kolejność warstw ma znaczenie semantyczne i wydajnościowe.

Praktyczna uwaga o kolejności:

1. zapis: tekst -> kompresja -> bufor -> nośnik,
2. odczyt: nośnik -> bufor -> dekompresja -> tekst.

Odwrócenie kolejności może dać błędny wynik albo nieefektywny przepływ danych.

## Kod C#

Kod: [Examples/Program.cs](Examples/Program.cs)

Program:

1. kompresuje tekst do `byte[]`,
2. dekompresuje z powrotem,
3. pokazuje rozmiar oryginału i payloadu.

To praktyczny, produkcyjny przykład Dekoratora.

### Szczegółowe wyjaśnienie programu

Metoda `Main`:

1. definiuje tekst wejściowy,
2. uruchamia `Compress`,
3. uruchamia `Decompress`,
4. porównuje długości i wypisuje wynik końcowy.

Metoda `Compress` krok po kroku:

1. `MemoryStream output` przechowuje wynikowy payload w pamięci,
2. `BufferedStream(output, 4096)` dodaje warstwę buforowania, aby ograniczyć liczbę małych operacji I/O,
3. `GZipStream(buffered, CompressionLevel.Optimal, leaveOpen: true)` dodaje kompresję i pozostawia otwarty strumień bazowy,
4. `StreamWriter(gzip, Encoding.UTF8)` zamienia tekst na bajty UTF-8 i zapisuje je do łańcucha,
5. po zamknięciu warstw `output.ToArray()` zwraca gotowe skompresowane bajty.

Dlaczego `leaveOpen: true` jest istotne:

- zamknięcie `GZipStream` finalizuje format gzip (nagłówki i stopka),
- ale nie chcemy automatycznie zamykać `output`, bo jeszcze odczytujemy z niego wynik przez `ToArray()`.

Metoda `Decompress` krok po kroku:

1. `MemoryStream input` tworzy źródło bajtów ze skompresowanego payloadu,
2. `BufferedStream` buforuje odczyt,
3. `GZipStream(..., CompressionMode.Decompress)` odtwarza oryginalny strumień bajtów,
4. `StreamReader(..., Encoding.UTF8)` zamienia bajty z powrotem na tekst,
5. `ReadToEnd()` zwraca odzyskaną treść.

Wniosek praktyczny:

- ten sam kod biznesowy (tekst wejściowy/wyjściowy) działa niezależnie od liczby i typu warstw,
- można wymienić jeden dekorator (np. kompresję) bez przepisywania całego mechanizmu.

## Uruchom

```bash
cd src/07-dekorator/06-dekoratory-bcl-stream/Examples
dotnet run
```

## Zadania z rozwiązaniami

1. Zadanie: zamień `GZipStream` na `BrotliStream` i porównaj rozmiar.
Rozwiązanie: użyj `BrotliStream` z `CompressionLevel.Optimal`.

Wyjaśnienie BrotliStream:

- `BrotliStream` to dekorator kompresji oparty o algorytm Brotli,
- często daje lepszy współczynnik kompresji niż GZip dla danych tekstowych,
- bywa wolniejszy przy najwyższej jakości kompresji, więc wybór zależy od scenariusza (CPU vs rozmiar transferu),
- w .NET używa się go analogicznie do `GZipStream`, czyli jako warstwę na istniejącym strumieniu.

Minimalna zamiana w kodzie:

`using var brotli = new BrotliStream(buffered, CompressionLevel.Optimal, leaveOpen: true);`

Następnie `StreamWriter` powinien pisać do `brotli` zamiast do `gzip`.

2. Zadanie: dodaj warstwę szyfrowania (np. `CryptoStream`) po kompresji.
Wyjaśnienie: Dekorator umożliwia dokładanie funkcji warstwowo.

Wariant łańcucha dla tego zadania:

`MemoryStream -> BufferedStream -> GZip/Brotli -> CryptoStream -> StreamWriter`

Dlaczego taka kolejność:

1. najpierw kompresja (na danych „surowych” działa najlepiej),
2. potem szyfrowanie (zaszyfrowane dane zwykle nie kompresują się dobrze).

## Literatura

- Stream: https://learn.microsoft.com/dotnet/api/system.io.stream
- GZipStream: https://learn.microsoft.com/dotnet/api/system.io.compression.gzipstream
- BrotliStream: https://learn.microsoft.com/dotnet/api/system.io.compression.brotlistream
- BufferedStream: https://learn.microsoft.com/dotnet/api/system.io.bufferedstream

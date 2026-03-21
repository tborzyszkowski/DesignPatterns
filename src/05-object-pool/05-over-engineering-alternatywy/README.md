# Object Pool - Over-engineering i alternatywy

Wzorzec Object Pool często bywa nadużywany, szczególnie w językach zarządzanych (managed languages) takich jak C# lub Java, które korzystają z automatycznego odśmiecania pamięci (Garbage Collector).

## Kiedy Object Pool to Over-Engineering (Antywzorzec):
1. **Lekkie obiekty w platformach z systemem GC:** Generacja 0 (młode, małe obiekty alokowane krótko) w systemie .NET ma mniejszy narzut na rezerwację nowej pamięci niż koszty synchronizacji wątków (lock / Interlocked / ConcurrentBag), które musielibyśmy zapłacić pytając pulę o obiekt. Alokacja `new Object()` jest ekstremalnie szybka.
2. **Krótki czas życia:** Zwrócenie małego obiektu do puli i "wyczyszczenie" go kosztuje więcej zasobów procesora, niż pozwolenie Garbage Collectorowi po prostu o nim zapomnieć. 
3. **Złudna kontrola pamięci:** Konstrukcja Object Pooli tworzy silne referencje do obiektów w pamięci w samej Puli; zabezpiecza je to przed zebraniem przez Garbage Collector w momentach, w których program by tego potrzebował. Powoduje to, że pula często zajmuje całą zadeklarowaną pamięć i trzyma ją dopóki program działa, obniżając faktyczną przestrzeń na użytek.

## Alternatywy:
- **Zostaw to Garbage Collectorowi:** Standardowe klasy nie potrzebują pulowania. 
- **Wzorzec Pyłek (Flyweight):** Jeśli tworzysz tysiące obiektów i potrzebują one trzymać te same dane "tylko do odczytu", wystarczy wydzielić te same części do klas / struktur czytanych globalnie (współdzielony wskaźnik do Flyweight).
- **Fabryka + Interfejsy (Abstract Factory):** W przypadku wstrzykiwania zależności (`Dependency Injection`), możesz polegać na wbudowanym mechanizmie IoC (od C#/.NET Core), wybierając na starcie np. Scoped / Transient objects zamist zarządzać pulą manualnie.
- **Struktury typu `ref struct` / `Span<T>` i `ArrayPool<T>` :** Dla programowania ułamków sekund, np, analizatorów w C#, wystarczy obiekty zamienić na stosowe zamiast korzystać ze sterty. A dla tablic z alokacją w LOH, Microsoft wbudował i sugeruje `System.Buffers.ArrayPool<T>`.

## Przykład negatywny - gdzie pula przegrywa wydajnościowo

W podkatalogu `OverEngineeringSample` stworzyliśmy przykład pokazujący, jak zdefiniowanie "małego, szybkiego" obiektu w Puli obiektów pochłania dużo więcej czasu w scenariuszu współbieżnym z powodu synchronizacji wątków, w odniesieniu do prostej alokacji `new`.

Analizę wydajności można łatwo odtworzyć uruchamiając kod:
```bash
cd OverEngineeringSample
dotnet run -c Release
```

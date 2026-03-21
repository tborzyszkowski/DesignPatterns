# Wzorzec Projektowy: Object Pool (Pula Obiektów)

Wzorzec **Object Pool** to kreacyjny wzorzec projektowy, który pozwala na kontrolowanie instancjonowania obiektów poprzez ponowne wykorzystanie już raz utworzonych obiektów zamiast ich tworzenia za każdym razem nowych. Ten plik służy jako podstawa do zajęć/wykładu.

Ten katalog zawiera materiały dydaktyczne uporządkowane w następujące sekcje:

1. [Idea i kontekst (01-idea-i-kontekst)](01-idea-i-kontekst/README.md) - Podstawowe założenia i historia struktury, kontekst ewolucji oprogramowania i powstania wzorca.
2. [Kiedy stosować (02-kiedy-stosowac)](02-kiedy-stosowac/README.md) - Wskazania do użycia puli obiektów. Wymogi biznesowe i techniczne.
3. [Struktura, działanie i przykłady (03-struktura-dzialanie)](03-struktura-dzialanie/README.md) - Diagramy klas i sekwencji. Omówienie ról struktur we wzorcu.
4. [Różne implementacje i warianty (04-implementacje-warianty)](04-implementacje-warianty/README.md) - Jak ewoluował wzorzec i przykłady klasycznych vs nowoczesnych implementacji w ekosystemie .NET.
5. [Over-engineering i alternatywy (05-over-engineering-alternatywy)](05-over-engineering-alternatywy/README.md) - Gdzie uważać przed nadużyciem puli obiektów i co można użyć zamiennie (np. fabryki/GC).
6. [Asynchroniczne workery (06-asynchroniczne-workery)](06-asynchroniczne-workery/README.md) - Duży biznesowy przykład obrazujący faktyczną korzyść, np. wykorzystanie złączeń obfitych w I/O, pomiar wydajności.

Wszystkie katalogi pod spodem używają C# najnowszego typu (C# 10+) i korzystają wprost z testów na udowodnienie działania pojęć.

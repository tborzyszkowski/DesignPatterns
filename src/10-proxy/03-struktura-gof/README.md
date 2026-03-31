# 03. Struktura GoF - Proxy

## Role

1. Subject - wspolny kontrakt.
2. RealSubject - docelowa implementacja.
3. Proxy - implementuje Subject i deleguje do RealSubject.
4. Client - pracuje na Subject, bez wiedzy o szczegolach.

## Przeplyw

1. Client wywoluje metode przez Subject.
2. Proxy wykonuje logike pre/post (autoryzacja, cache, log, lazy).
3. Proxy deleguje do RealSubject (albo zwraca dane z cache).

## Warianty implementacyjne

1. Static Proxy - osobna klasa proxy na interfejs.
2. Dynamic Proxy - generowany runtime i oparty o interception.

## Ryzyka projektowe

1. Proxy zaczyna zawierac logike biznesowa.
2. Brak transparentnosci wyjatkow i opakowan bledow.
3. Nadmiarowa liczba warstw proxy.

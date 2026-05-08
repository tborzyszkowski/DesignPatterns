# MATERIALY WYKLAD - Proxy

## Cele uczenia

1. Umieć odróżnić Proxy od Adaptera, Dekoratora i Strategii.
2. Rozpoznac typy Proxy i dobrac je do scenariusza.
3. Zaimplementować Static Proxy i Dynamic Proxy.
4. Umieć wskazać ryzyka: overengineering, debugging, wydajność.

## Proponowany zestaw slajdów

1. Po co Proxy: kontrola dostępu, lazy loading, zdalne wywołania.
2. Problem bez Proxy: klient zna za dużo szczegółów.
3. Definicja i intencja wzorca.
4. Diagram klas GoF.
5. Diagram sekwencji wywołania przez Proxy.
6. Typy Proxy i ich cele.
7. Virtual Proxy (duży obiekt, lazy init).
8. Protection Proxy (rolę i uprawnienia).
9. Remote Proxy (komunikacja sieciowa).
10. Caching Proxy (cache + invalidacja).
11. Static Proxy - plusy i minusy.
12. Dynamic Proxy - plusy i minusy.
13. Dynamic Proxy w C# (DispatchProxy).
14. Dynamic Proxy w Javie (InvocationHandler).
15. Proxy vs Adapter.
16. Proxy vs Dekorator.
17. Proxy vs Strategia.
18. Case study 1: raporty z autoryzacja.
19. Case study 2: API klienta z retry i telemetry.
20. Podsumowanie + mini quiz.

## Live coding

1. Static Proxy: kontrola roli + logowanie wywołania.
2. Dynamic Proxy C#: intercept wszystkich metod interfejsu.
3. Dynamic Proxy Java: to samo z InvocationHandler.

## Mini quiz (na koniec)

1. Kiedy wybrac Dynamic Proxy zamiast Static Proxy?
2. Dlaczego Proxy nie jest Adapterem?
3. Co odróżnią Proxy od Dekoratora?
4. Który typ Proxy pasuje do lazy loading obrazu?
5. Jaki koszt operacyjny wnosi Dynamic Proxy?

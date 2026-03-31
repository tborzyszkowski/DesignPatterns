# ZADANIA - Wzorzec Proxy

## Zadanie 1 - Protection Proxy

Wymagania:

1. Dodaj role User i Admin.
2. Zablokuj metode DeleteAll dla User.

Rozwiazanie (skrot):

1. Proxy sprawdza role przed delegacja.
2. Przy braku uprawnien rzuca UnauthorizedAccessException.

## Zadanie 2 - Virtual Proxy

Wymagania:

1. Zasymuluj ciezki obiekt (np. duzy raport).
2. Inicjalizuj go dopiero przy pierwszym wywolaniu.

Rozwiazanie (skrot):

1. Proxy trzyma nullable RealSubject.
2. Tworzy RealSubject lazily na pierwszym call.

## Zadanie 3 - Caching Proxy

Wymagania:

1. Dodaj cache dla GetById.
2. Pokaz hit/miss w logach.

Rozwiazanie (skrot):

1. Proxy trzyma Dictionary/ConcurrentDictionary.
2. Przy trafieniu zwraca cache, bez delegacji.

## Zadanie 4 - Dynamic Proxy C#

Wymagania:

1. Dodaj pomiar czasu dla wszystkich metod IOrderService.
2. Zaloguj wyjatki i przepusc je dalej.

Rozwiazanie (skrot):

1. Uzyj DispatchProxy i override Invoke.
2. W finally zapisz czas wykonania.

## Zadanie 5 - Most vs Adapter vs Proxy vs Strategia

Wymagania:

1. Dla 4 scenariuszy wybierz wlasciwy wzorzec.
2. Uzasadnij decyzje 2-3 zdaniami.

### Szablon checklisty decyzyjnej (do wypelnienia)

Scenariusz: ______________________________

1. Czy zmieniasz kontrakt obcego API? [ ] TAK [ ] NIE
2. Czy chcesz ten sam kontrakt i kontrolowany dostep? [ ] TAK [ ] NIE
3. Czy zmienia sie glownie algorytm? [ ] TAK [ ] NIE
4. Czy rozwijasz 2 osie niezaleznie? [ ] TAK [ ] NIE

Wniosek (zaznacz jedno):

1. [ ] Adapter
2. [ ] Proxy
3. [ ] Strategia
4. [ ] Most

Uzasadnienie:

____________________________________________________________
____________________________________________________________

## Pytania kontrolne

1. Co odroznia Proxy od Adaptera — zachowaj jeden kontrakt vs zmien kontrakt?
2. Czym rozni sie Virtual Proxy od Protection Proxy?
3. Dlaczego Dynamic Proxy utrudnia debugowanie?
4. Kiedy Static Proxy jest lepszy niz Dynamic Proxy?
5. Co sie stanie, kiedy wlozysz logike biznesowa do Proxy zamiast do RealSubject?
6. Jak zabezpieczyc sie przed niekontrolowanym rozrostem warstw proxy?

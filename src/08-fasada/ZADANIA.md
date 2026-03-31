# ZADANIA - Wzorzec Fasada

Ten plik zbiera zadania przekrojowe do całego modułu i może być używany jako materiał na laboratorium lub pracę domową.

## Zadanie 1 - Refaktoryzacja do fasady

Masz kod klienta, który samodzielnie wywołuje 7 usług (`AuthService`, `PricingService`, `InventoryService`, `TaxService`, `PaymentService`, `ShippingService`, `NotificationService`).

Wymagania:

1. Zaprojektuj i zaimplementuj `CheckoutFacade`.
2. Klient ma wywoływać tylko jedną metodę: `PlaceOrder`.
3. Błędy z warstw wewnętrznych mają zostać przekształcone do prostego modelu `CheckoutResult`.

Rozwiązanie (skrót):

1. Utwórz kontrakt wejścia/wyjścia: `CheckoutRequest` i `CheckoutResult`.
2. Przenieś orkiestrację do fasady i ukryj kolejność kroków.
3. Dodaj walidację i spójne komunikaty błędów na poziomie fasady.

## Zadanie 2 - Facade + ACL

Kontekst: integrowany system zewnętrzny zwraca statusy `OK`, `WARN`, `HARD_FAIL`, `SOFT_FAIL`.

Wymagania:

1. Dodaj warstwę ACL mapującą statusy do domenowych wartości (`Accepted`, `Retryable`, `Rejected`).
2. Fasada ma zwracać tylko model domenowy i nie może ujawniać statusów zewnętrznych.

Rozwiązanie (skrót):

1. `PartnerAclTranslator` mapuje kontrakty zewnętrzne na model domeny.
2. Fasada używa tłumacza przed zwróceniem odpowiedzi.
3. Klient nie zna kontraktu partnera.

## Zadanie 3 - Bezpieczeństwo

Kontekst: operacje administracyjne powinny być dostępne tylko dla roli `Admin`.

Wymagania:

1. Dodaj `SecureAdminFacade`.
2. Wszystkie metody fasady muszą wykonywać kontrolę uprawnień.
3. Loguj próby nieautoryzowanego dostępu.

Rozwiązanie (skrót):

1. Wstrzyknij `IAuthorizationService` i `ILogger`.
2. Sprawdzenie uprawnień wykonuj na początku metody fasady.
3. Rzucaj jeden spójny wyjątek domenowy lub zwracaj `Result.Fail("Unauthorized")`.

## Zadanie 4 - Testy jednostkowe

Napisz testy do fasady zamówień:

1. ścieżka sukcesu,
2. brak dostępności towaru,
3. odrzucona płatność,
4. błąd transportu,
5. przekroczenie timeout dla partnera.

Rozwiązanie (skrót):

1. Mockuj wszystkie subsystemy.
2. Testuj kontrakt fasady, a nie szczegóły implementacji subsystemów.
3. Sprawdź także czy fasada nie przecieka wyjątków technicznych.

# 02. Kiedy stosowac Proxy - zalety i wady

## Sygnaly, ze warto

1. Potrzebujesz kontroli dostepu do operacji.
2. Tworzenie obiektu jest kosztowne i chcesz lazy init.
3. Chcesz dodac cache/logowanie bez zmian klienta.
4. Chcesz ukryc zdalne wywolanie za lokalnym interfejsem.

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

## Krotka checklista decyzyjna

Scenariusz: obce API, inny kontrakt -> **Adapter**.

Scenariusz: ta sama umowa, kontrola dostepu/lazy/cache -> **Proxy**.

Scenariusz: jedna os podmiany algorytmu -> **Strategia**.

Scenariusz: rozszerzanie odpowiedzialnosci obiektu warstwowo -> **Dekorator**.

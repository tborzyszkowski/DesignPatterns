# System zarządzania pokojami gier planszowych.

## Cel:
Celem projektu było stworzenie systemu do tworzenia pokoi i zarządzania dostępnymi pokojami dla graczy. System pozwala na zalogowanie się jako unikalny gracz gość. Gość posiada możliwość  stworzenia pokoju dla wybranej gry. Obecnie system zawiera parametry dla trzech gier : go, szachy, warcaby.  System kontroluje dostęp do pokoju na podstawie ilości graczy.

## Zastosowane wzorce projektowe:

### Wzorce konstrukcyjne :
- Singleton
Zastosowanie wzorca pozwala na utworzenie unikalnej instancji gracza.
- Budowniczy
Zastosowanie wzorca umożliwia stworzenie pokoju wraz ze zmianą jego parametrów. Zostały utworzone trzy typy budowniczego do różnych pokoi.

### Wzorce Strukturalne:
- Kompozyt
Wzorzec umożliwił stworzenie struktury drzewiastej pokoju. Źródłem jest instancja gry, która odpowiada za przechowywanie pokoi. Zadaniem pokoi jest kontrola ilości graczy 

- Fasada
Zastosowanie wzorca umożliwiło ukrycie etapu inicjacji (tworzenia) pokoju i kontrolowanie statusu pokoju.
  
### Wzorce Czynnościowe:
- Stan
Zastosowanie wzorca umożliwiło wyznaczenie dwóch różnych stanów dla pokoju: „otwarty” i „zamknięty” oraz jego zmianę za pomocą żądania (request).

- Obserwator
Zastosowanie wzorca umożliwiło połączenie obserwatora z pokojem i monitorowanie statusu pokoju.  Dzięki temu można reagować na zmianę statusu.


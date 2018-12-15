# Design Patterns

## Przestrzeń wzorców projektowych (przykłady)
1. Konstrukcyjne
    1. singleton
    1. fabryka
    1. budowniczy
    1. prototyp
1. Strukturalne
    1. adapter
    1. dekorator
    1. fasada
    1. most
1. Operacyjne (czynnościowe)
    1. polecenie
    1. mediator
    1. obserwator
    1. odwiedzający

## Projekt

### Zadanie
Do każdego z punktów należy zaprezentować i użyć po dwa różne wzorce:
1. wytwarzania obiektów – konstrukcyjne (budowniczy [x], fabryki [x]),
1. organizowania ich w użyteczne struktury obiektów – strukturalne (dekorator [x], adapter [x]),
1. modelowania zachowania obiektów/(struktur obiektów) – czynnościowe (obserwator [x], polecenie [x]).


### Plan pracy – Centrala telefoniczna
1. Centrala telefoniczna - wytwarzanie przez budowniczego
    1. Alcatel 4400 (nagrywanie: false)
    1. Alcatel OmniPCX (nagrywanie: true)
1. Zestawianie połączeń - wytwarzanie przez fabryki
    1. Połączenie wewnętrzne - produkowane przez fabrykę
    1. Połączenia przychodzące - produkowane przez fabrykę i obsługiwane przez obserwator
    1. Połączenie wychodzące - produkowane przez fabrykę
    1. Połączenia premium - dekorowane połączenia wychodzące
1. Bilinigi i statystyki - (obserwator)
1. Połączenie serwisowe - (polecenie)

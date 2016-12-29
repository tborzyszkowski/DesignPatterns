Prosta implementacja fasady. 

By wybrać pieniądze **Cash Machine** potrzebuje jedynie naszej karty, pinu oraz ile tej gotówki chcemy. 

Magia w metodzie getCash(), na podstawie danych z karty, sprawdza:

- czy możemy tej karty w ogóle użyć u dostawcy karty, 

- czy na koncie w banku w ogóle mamy jakieś środki.


Następnie, jeśli warunki są spełnione, w systemie naszego banku, który zna z danych karty, wykonuje operację, a następnie wydaje nam kasę. 
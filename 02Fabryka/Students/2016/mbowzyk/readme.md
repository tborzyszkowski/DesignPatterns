W paczkach `simpleFabric` i `fabricMethod` znajdują się najprostsze implementacje.

W paczkach `abstractFabric` i `anotherAbstractFabric` znajdują się ciekawsze rozwiązania:
* w pierwszej jest najprostsza implementacja fabryki abstrakcji, która wymaga podania odpowiedniej fabryki w celu wyplucia odpowiedniej klasy,
* w drugiej, podajemy, jaką klasę chcemy otrzymać, po czym dokładnie to jest nam zwracane.

W drugim przypadku metoda do zwrócenia zwierzaka zachowuje sie statycznie, dzięki wykorzystaniu `companion object`, gdzię użyciu `reinfied` i `inline function` mogliśmy mu podać klasę jako parametr. 
Więcej na temat companion object [tutaj](https://kotlinlang.org/docs/reference/object-declarations.html#companion-objects), a inline functions [tutaj](https://kotlinlang.org/docs/reference/inline-functions.html).
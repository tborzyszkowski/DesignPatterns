W części napisanej Javą znajduje się przykład z wykorzystaniem biblioteki `Lombok` do wygenerowania buildera do danej klasy. Dodatkowo klasa **VehicleConstructor** pozwala stworzyć predefiniowane obiekty z danymi.
Dodatkowo wykorzystana jest adnotacja `@Value`, która tworzy metody `get` do wszystkich pól oraz dodaje do pól modyfikator `private`. 
Więcej na temat biblioteki Lombok można poczytać [tutaj](https://projectlombok.org/).

W części napisanej w Kotlinie, całość jest podzielona na dwie części, w jednej wykorzystywane są `data class`, specjalny feature języka, w drugiej, zwykła klasa jest zbudowana. 
W drugim przypadku, tworzymy buildera, do którego musimy się dostać przez dodatkowy obiekt ze względu na prywatny konstruktor. 
Kotlin pozwala na tworzenie specjalnych funkcji przy inicjalizacji obiektu, poprzez dodanie ich do działań w `init {}`, wykorzystując lambdę. 

W paczce `usingDataClass` znajdują się 2 przykłady z wykorzystaniem tej właściwości języka. **Person** jest budowany przez **PeopleBuilder**, który realizuje przy okazji założenie, że nie trzeba podawać opcjonalnych wartości. 
Jednak w Kotlinie występuje coś, co jest określane jako `named parameters`, dzięki czemu klasyczny powód powstania wzorca builderów w tym języku nie istnieje - możemy wprost napisać `parametr = 0`, zamiast pisania **magicznych konstruktorów** z kilkoma parametrami.
Dodatkowo `data class` posiadają własne metody `toString`, `hashCode` i `copy`, oraz można podać im defaultowe wartości, co jest widoczne w klasie **Alien**.
Więcej o data class można przeczytać [tutaj](https://kotlinlang.org/docs/reference/data-classes.html).
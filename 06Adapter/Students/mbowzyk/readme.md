W paczce `twoWayAdapter` znajduje się implementacja przykładu z **Seabird**, również znajduje się rozwiązanie w drugą stronie na przykładzie latającego holendra.

W paczkach `pluggableAdapter` i `usbcAdapter` znajduje się podobny przykład, z tą różnicą, że w tej drugiej, adapter implementuje interfejs typu, do którego ma adaptować, dzięki czemu nie trzeba się przejmować, jaki obiekt ostatecznie tworzymy. 

Kotlin ma ciekawą właściwość nazwaną `smart cast`, dzięki której tylko raz wystarczy wskazać, na jaki obiekt rzutujemy, po czym język sam a nas to pamięta i pozwala skorzystać z metod, które obiekt po zrzutowaniu powinien posiadać. Dobre przykłady tego są w testach do `twoWayAdapter` i w klasie **AnotherAdapter**.
Więcej o tej właściwości można poczytać [tutaj](https://kotlinlang.org/docs/reference/typecasts.html).
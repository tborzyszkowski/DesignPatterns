

### Used design patterns
- Creational
    - [Singleton](#singleton)
    - [FactoryMethod](#factorymethod)
- Structural
    - [Proxy](#proxy)
    - [Facade](#fasada)
- Behavioral
    - [State](#state)
    - [Observer](#observer)

### Singleton
- jego celem jest ograniczenie możliwości tworzenia obiektów danej klasy do jednej instancji oraz zapewnienie globalnego dostępu do stworzonego obiektu.
- jako singletony zaimplementowane zostały fabryki potraw,  fasada  oraz proxy restauracji

### FactoryMethod
- dostarcza interfejs do tworzenia obiektów. Tworzeniem egzemplarzy zajmują się podklasy.
- wzorzec został wykorzystany przy tworzeniu potraw przez odpowiednie fabryki potraw

### Proxy
- stosowany jest w celu kontrolowanego tworzenia na żądanie kosztownych obiektów oraz kontroli dostępu do nich. Zapewnia placeholder dla kontrolowanego obiektu.
- wzorzec został użyty do sprawdzenia godzin otwarcia sklepu. Jeśli sklep jest zamknięty to obiekt, który go reprezentuje nie jest tworzony.

### Facade
- definiuje interfejs wyższego poziomu, który ułatwia korzystanie z podsystemu. Fasada wykonuje tylko potrzebne operacje, nie ujawniając przed klientem całego systemu.
- fasada została wykorzystana do stworzenie łatwego w obsłudzie interfejsu dla klienta. Klient nie musi znać szczegółów implememntacji, np. wiedzieć jak przebiega komunikacja pomiędzy proxy, a fabryką

### State
- uzależnia sposób działania obiektu od stanu w jakim się aktualnie znajduje.
- wzorzec został użyty do wprowadzenia różnych zniżek w zależności od dnia tygodnia. Został zaimplementowany dla obiektu klasy "store".

### Observer
- wzorzec używany do powiadamiania zainteresowane obiekty o zmianie stanu pewnego innego obiektu.
- w projekcie wzorzec został zastosowany do powiadomienia kelnera, że zamówienie jest już gotowe i może zostać przez niego podane klientowi.
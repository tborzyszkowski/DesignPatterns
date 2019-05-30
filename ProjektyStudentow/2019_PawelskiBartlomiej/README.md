# PESEL Generator

Załóżmy, że jesteśmy urzędem, którego zadaniem jest generowanie numerów PESEL. Chcemy je generować na podstawie plików wysłanych ze szpitala (format *.json lub *.csv), lub ręcznie, na podstawie danych wprowadzonych w konsoli.


## Zastosowane wzorce projektowe
- Singleton (w danej chwili program może obsługiwać jeden plik tekstowy - obsługiwany jest on przez instancję singletona implementującego interfejs iFileSingleton)
- Budowniczy (do tworzenia numeru PESEL na podstawie daty urodzenia oraz płci)
- Fasada - wyżej wspomniany budowniczy jest ukryty przed użytkownikiem za fasadą, którą jest metoda generate() z interfejsu iPesel
- Dekorator - służący do "dekorowania" dziecka numerem PESEL
- Adapter - pozwala na wykorzystanie zarówno pliku z rozszerzeniem *.json jak i *.csv
- Iterator - zaimplementowany za pomocą wyrażenia lambda - służy do finalnego drukowania listy osób, dla których wygenerowano PESEL
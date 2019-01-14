## Design Patterns – projekt

## Wstęp

### Opis
Domeną projektu jest pojęcie centrali telefonicznej. Nie chodzi tu o dokładne odwzorowanie pracy całej centrali, czy stworzenie całego systemu na zasadzie takiej jak robi to asterisk czy nawet freepbx, głównym zadaniem całego projektu  jest symulacja działania systemu telekomunikacji w przykładowej instytucji.

### Wzorce
W projekcie wykorzystane zostało sześć wzorców projektowych, po dwa konstrukcyjne, strukturalne i czynnościowe. Spośród wzorców konstrukcyjnych wybrałem budowniczego do tworzenia obiektów central oraz metodę fabrykującą do produkcji obiektów połączeń telefonicznych i trybu serwisowego. Ze wzorców strukturalnych wykorzystałem dekorator do zwiększania kosztu połączeń na numery premium o połączeń zagranicznych oraz adapter do zestawiania połączeń zagranicznych. Wzorce czynnościowe takie jak obserwator i polecenie, zostały użyte w kontekście tworzenia bilingów, pierwszy z wymienionych oraz drugi jako generowanie poleceń podczas połączeń serwisowych.

## Szczegóły

### Centrale
Na początku utworzone zostają dwie centrale Alcatel 4400 i Alcatel OmniPCX, każda z nich ma kilka parametrów i funkcji takich jak model, funkcja bilingów i nagrywania oraz rodzaj protokołu wykorzystywanego do konfiguracji. Po uruchomieniu centrali wyświetla się komunikat potwierdzający wykonanie operacji.

### Połączenia
Tworzenie obiektu połączenia telefonicznego odbywa się za pomocą metody fabrykującej, przekazując przy tym kierunek połączenia, numer abonenta i numer wywoływany. W rozwiązaniu wyróżniamy pięć rodzajów połączeń z czego trzy główne, czyli wewnętrzne, przychodzące oraz wychodzące, które dodatkowo możemy podzielić na premium i zagraniczne. Podczas połączenia premium za pomocą wzorca dekorator zwiększony zostaje koszt połączenia. Połączenie zagraniczne tworzone jest przez wzorzec adapter z metody fabrykującej połączenia wychodzące.

### Bilingi
Rachunki połączeń, czyli bilingi powstają dzięki metodzie fabrykującej, używane są za pomocą wzorca obserwator w momencie wykonywania połączenia.

### Serwis
Obiekty serwisu centrali generowane są za pomocą metody fabrykującej, natomiast same polecenia używane podczas połączenia serwisowego, w zadaniu przykładowo tworzenia nowego abonenta z użyciem wzorca polecenie.

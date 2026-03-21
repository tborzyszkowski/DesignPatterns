# Idea i kontekst powstania wzorca Object Pool

Wzorzec projektowy **Object Pool** pozwala ograniczać koszt tworzenia nowych instancji obiektów drogowych, czyli takich, których alokacja w pamięci lub konstrukcja (np. połączenia z bazą danych, gniazda sieciowe, kosztowna inicjalizacja klas, zasoby sprzętowe GPU) pociąga za sobą wysoką karę wydajnościową lub ich liczba jest fizycznie limitowana (np. pula fizycznych maszyn / połączeń z serwerową licencją). 

## Zarys problemu: 
Początkowo (lata 80-90 z językami np. C/C++), tworzenie nowych, złożonych w obiekty struktur pamięciowych wymagało sporej pracy samej alokacji ze sterty, a także skomplikowanych funkcji inicjalizujących. Systemy były ubogie w zasoby i procesory, dlatego "wydzierżawianie" z raz wytworzonej puli było bardzo powszechną techniką optymalizacyjną znaną z inżynierii gier i systemów wbudowanych. 

W systemach z **Garbage Collector (GC)** takich jak Java i .NET, optymalizacje związane ze stertą są dość agresywne, a pamięci jest sporo, lecz alokacja obiektów wielkogabarytowych (Large Object Heap - LOH) lub silnie powiązanych z natywnym we/wy nadal uchodzi za wąskie gardło. Gdy dochodzi wielowątkować, problemem staje się "przepustowość".

## Kontekst biznesowy / technologiczny:
- Połączenia bazodanowe (DB Connection Pooling): np. popularne mechanizmy wprost zaszyte w bibliotekach ADO.NET (SqlConnection).
- Zarządzanie bitmapami, grafiką i audiami wielkiej rozdzielczości (Game Dev, Unity3D).
- Pule zasobów API: limitowana ilość żądań lub dedykowanych workerów API. 
- Pule instancji serwerów, pul proxy, czy też kontenery wielowątkowe i Web Serwery (np. Kestrel trzyma swoją pulę prealokowanych obiektów do obsługi HTTP). 

## Najważniejsze cechy:
- **Przewidywalność użycia (Performance)**: Minimalizacja skoków narzutu GC (tzw. _GC Pauses_ lub _GC Spikes_) na systemy Real-Time.
- **Stała konsumpcja pamięci (Memory footprint limit)**: Ograniczenie ilości RAM używanej przez Twoją architekturę, nie dopuszczając do wysycenia jej przez niekontrolowany napływ wejść sieciowych, itp.

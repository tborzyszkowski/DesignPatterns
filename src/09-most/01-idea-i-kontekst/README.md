# 01. Idea i kontekst wzorca Most

## Cel tematu

Zrozumieć dlaczego Most powstał i jakie problemy rozwiązuje w projektowaniu klas.

## Problem: eksplozja klas przez dziedziczenie

Mamy dwie niezależne osie zmienności:

- Oś A (abstrakcja/zachowanie): BasicRemote, AdvancedRemote, VoiceRemote
- Oś B (implementacja/technologia): TvDevice, RadioDevice, ProjectorDevice, SmartSpeakerDevice

Przy podejściu czystego dziedziczenia każda kombinacja to osobna klasa:

| | TvDevice | RadioDevice | ProjectorDevice | SmartSpeakerDevice |
|---|---|---|---|---|
| BasicRemote | BasicRemoteTv | BasicRemoteRadio | BasicRemoteProjector | BasicRemoteSpeaker |
| AdvancedRemote | AdvancedRemoteTv | AdvancedRemoteRadio | AdvancedRemoteProjector | AdvancedRemoteSpeaker |
| VoiceRemote | VoiceRemoteTv | VoiceRemoteRadio | VoiceRemoteProjector | VoiceRemoteSpeaker |

**3 piloty x 4 urządzenia = 12 klas.** Dodanie jednego nowego pilota lub urządzenia to dodanie kolejnego wiersza lub kolumny do tabeli — N + M nowych klas zamiast N lub M.

![Bridge history](diagrams/bridge_history.png)

Źródło: [diagrams/01-history.puml](diagrams/01-history.puml)

## Rozwiązanie: Most rozdziela osie

Most rozdziela:

1. **Abstraction** — co klient chce zrobić (pilot: włącz, ustaw głośność),
2. **Implementor** — jak to technicznie wykonać (urządzenie: TV, Radio, Projektor).

Abstraction przechowuje referencje do Implementora przez interfejs i deleguje do niego operacje niskopoziomowe.

![Bridge idea](diagrams/bridge_idea.png)

Źródło: [diagrams/02-idea.puml](diagrams/02-idea.puml)

## Niezależny rozwój dwóch osi — scenariusz zespołowy

Kluczową zaletą Mostu jest to, że oba wymiary mogą być rozwijane bez wiedzy o sobie nawzajem:

```
Sprint 1 — Team A (Piloty):
  + BasicRemote    [abstraction]
  + AdvancedRemote [refined abstraction]

Sprint 1 — Team B (Urzadzenia):
  + TvDevice       [implementor]
  + RadioDevice    [implementor]

Sprint 2 — Team A (nowy pilot, bez zmian w Team B):
  + VoiceRemote    [refined abstraction]
  Brak dotknięć klas TvDevice, RadioDevice.

Sprint 2 — Team B (nowe urzadzenie, bez zmian w Team A):
  + ProjectorDevice [implementor]
  Brak dotknięć klas BasicRemote, AdvancedRemote, VoiceRemote.
```

Dodanie `VoiceRemote` i `ProjectorDevice` to **2 nowe klasy**, a nie 2*N lub M*2.

> **Dlaczego 2*N lub M*2 bez Mostu?**
>
> Przy czystym dziedziczeniu każda kombinacja pilota i urządzenia to osobna klasa (N × M łącznie).
> Dodanie **1 nowego pilota** wymaga dopisania całego wiersza w tabeli — po jednej klasie dla każdego urządzenia, czyli **M nowych klas**.
> Dodanie **1 nowego urządzenia** to nowa kolumna — **N nowych klas**.
>
> | Podejście | Dodanie VoiceRemote | Dodanie ProjectorDevice | Razem |
> |---|---|---|---|
> | Dziedziczenie | M = 4 klasy | N = 3 klasy | **7 klas** |
> | Most (Bridge) | 1 klasa | 1 klasa | **2 klasy** |
>
> Wzorzec Most rozdziela obie osie, więc każda nowa klasa istnieje samodzielnie po swojej stronie i łączy się z drugą stroną w runtime przez referencję/interfejs — bez żadnych kombinacji.

![Bridge independent evolution](diagrams/bridge_independent_evolution.png)

Źródło: [diagrams/04-independent-evolution.puml](diagrams/04-independent-evolution.puml)

## Cykl życia

![Bridge lifecycle](diagrams/bridge_lifecycle_topic01.png)

Źródło: [diagrams/03-lifecycle.puml](diagrams/03-lifecycle.puml)

## Kod C#

Kod: [Examples/Program.cs](Examples/Program.cs)

Program pokazuje:

1. BasicRemote i AdvancedRemote jako dwie abstrakcje,
2. TvDevice, RadioDevice, ProjectorDevice jako implementory,
3. runtime switching implementora (podmiana urządzenia bez zmiany pilota),
4. rozszerzenie abstrakcji (Mute tylko w AdvancedRemote) bez zmian implementorów,
5. rozszerzenie implementacji (ProjectorDevice) bez zmian pilotów.

## Uruchom

```bash
cd src/09-most/01-idea-i-kontekst/Examples
dotnet run
```

## Zadania z rozwiązaniami

1. Dodaj `SmartSpeakerDevice` (oś implementacji).
   Rozwiązanie: nowy implementor `IDevice`, bez zmian w `BasicRemote` ani `AdvancedRemote`.

1. Dodaj `Mute` tylko po stronie `AdvancedRemote` (oś abstrakcji).
   Rozwiązanie: `RefinedAbstraction` rozszerza API bez naruszania implementorów.

1. Policz, ile klas trzeba by napisać bez Mostu dla 4 pilotów i 5 urządzeń.
  Rozwiązanie: 4×5 = 20 klas vs 4 + 5 = 9 klas z Mostem.

## Literatura

1. Refactoring.Guru: https://refactoring.guru/design-patterns/bridge
2. GoF, Design Patterns.

# 01. Idea i kontekst wzorca Most

## Cel tematu

Zrozumiec dlaczego Most powstal i jakie problemy rozwiazuje w projektowaniu klas.

## Problem

Gdy mamy dwie osie zmiennosci, np.:

1. rodzaj pilota (BasicRemote, AdvancedRemote),
2. rodzaj urzadzenia (TvDevice, RadioDevice, ProjectorDevice),

to dziedziczenie prowadzi do eksplozji kombinacji klas.

## Rys historyczny

![Bridge history](diagrams/bridge_history.png)

Zrodlo: [diagrams/01-history.puml](diagrams/01-history.puml)

## Idea Mostu

Most rozdziela:

1. Abstraction (co klient chce zrobic),
2. Implementor (jak to technicznie wykonac).

Dzieki temu obie osie rozwijaja sie niezaleznie.

![Bridge idea](diagrams/bridge_idea.png)

Zrodlo: [diagrams/02-idea.puml](diagrams/02-idea.puml)

## Cykl zycia

![Bridge lifecycle](diagrams/bridge_lifecycle_topic01.png)

Zrodlo: [diagrams/03-lifecycle.puml](diagrams/03-lifecycle.puml)

## Kod C#

Kod: [Examples/Program.cs](Examples/Program.cs)

Program pokazuje:

1. jedna abstrakcje pilota,
2. dwa implementory urzadzen,
3. runtime switching implementora.

## Uruchom

```bash
cd src/09-most/01-idea-i-kontekst/Examples
dotnet run
```

## Zadania z rozwiazaniami

1. Dodaj SmartSpeakerDevice.
Rozwiazanie: nowy implementor IDevice, bez zmian w BasicRemote.

2. Dodaj Mute tylko po stronie AdvancedRemote.
Rozwiazanie: RefinedAbstraction rozszerza API bez naruszania implementorow.

## Literatura

1. Refactoring.Guru: https://refactoring.guru/design-patterns/bridge
2. GoF, Design Patterns.

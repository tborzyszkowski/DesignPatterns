# 05. Wiekszy przyklad i alternatywy

## Cel tematu

Przepracowac pelny scenariusz i podjac decyzje wzorcowa swiadomie.

## Scenariusz

System notyfikacji:

1. Os abstrakcji: Alert, Marketing, Incident.
2. Os implementacji: EmailProvider, SmsProvider, PushProvider.

Bez Mostu roslaby liczba klas typu AlertViaEmail, IncidentViaSms itd.

![Big case class](diagrams/bridge_big_case_class.png)

Zrodlo: [diagrams/01-big-class.puml](diagrams/01-big-class.puml)

![Big case sequence](diagrams/bridge_big_case_sequence.png)

Zrodlo: [diagrams/02-big-sequence.puml](diagrams/02-big-sequence.puml)

## Cykl zycia use-case

![Big lifecycle](diagrams/bridge_lifecycle_topic05.png)

Zrodlo: [diagrams/03-lifecycle.puml](diagrams/03-lifecycle.puml)

## Alternatywy

1. Adapter - gdy laczysz niekompatybilne API.
2. Strategia - gdy zmienia sie glownie algorytm.
3. Fasada - gdy upraszczasz wejscie do subsystemu.

## Kod C#

Kod: [Examples/Program.cs](Examples/Program.cs)

Program pokazuje 3 typy notyfikacji x 3 providerow.

## Uruchom

```bash
cd src/09-most/05-wiekszy-przyklad-i-alternatywy/Examples
dotnet run
```

## Zadania z rozwiazaniami

1. Dodaj WhatsAppProvider.
Rozwiazanie: nowy implementor, bez zmian klas Alert/Incident.

2. Dodaj SecurityIncidentAlert.
Rozwiazanie: nowa abstrakcja, bez zmian providerow.

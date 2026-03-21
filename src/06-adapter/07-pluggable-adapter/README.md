# 07. Pluggable Adapter

## O co chodzi

Pluggable Adapter polega na dynamicznym doborze adaptera na podstawie typu źródła danych lub konfiguracji. Klient korzysta z jednego interfejsu, a adapter wybierany jest z rejestru.

## Zastosowanie

- integracja wielu dostawców API,
- architektura pluginowa,
- stopniowe podpinanie nowych źródeł danych bez zmiany klienta.

## Historia

Wariant popularyzował się wraz z systemami ETL i middleware, gdzie źródła danych zmieniały się częściej niż logika biznesowa klienta.

## Diagramy

![Pluggable class](diagrams/01-pluggable-class.png)

Źródło: [diagrams/01-pluggable-class.puml](diagrams/01-pluggable-class.puml)

![Pluggable sequence](diagrams/02-pluggable-sequence.png)

Źródło: [diagrams/02-pluggable-sequence.puml](diagrams/02-pluggable-sequence.puml)

## Przykład C Sharp

Kod: [Examples/Program.cs](Examples/Program.cs)

W przykładzie klient wybiera adapter po `sourceType` (`json`, `xml`) z rejestru.

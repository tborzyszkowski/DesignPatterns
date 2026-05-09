# 04. Implementacje i warianty Mostu

## Cel tematu

Pokazać praktyczne style implementacji Mostu i kryteria wyboru.

## Warianty

1. Statyczny (klasyczny) - implementor podawany raz.
2. Dynamiczny - mozliwa podmiana runtime.
3. Factory + Bridge - wybor implementora przez fabrykę.

![Implementation variants](diagrams/bridge_variants.png)

Źródło: [diagrams/01-variants.puml](diagrams/01-variants.puml)

![Factory bridge](diagrams/bridge_factory.png)

Źródło: [diagrams/02-factory.puml](diagrams/02-factory.puml)

## Cykl implementacji

![Implementation lifecycle](diagrams/bridge_lifecycle_topic04.png)

Źródło: [diagrams/03-lifecycle.puml](diagrams/03-lifecycle.puml)

## Jak wybrac wariant

1. Statyczny: mala skala i znane implementory.
2. Dynamiczny: potrzeba runtime switch.
3. Factory: konfiguracja lub pluginy.

## Kod C#

Kod: [Examples/Program.cs](Examples/Program.cs)

Program porównuje trzy warianty na tym samym use-case.

## Uruchom

```bash
cd src/09-most/04-implementacje-i-warianty/Examples
dotnet run
```

## Zadania z rozwiązaniami

1. Dodaj variant RegistryBridge.
Rozwiązanie: slownik string -> implementor tworzony lazily.

2. Dodaj walidacje konfiguracji fabryki.
Rozwiązanie: fallback + jasny blad domenowy.

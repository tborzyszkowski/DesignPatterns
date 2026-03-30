# 05. Kiedy nie stosować Adaptera i jakie są alternatywy

## Kiedy Adapter to zły wybór

1. Gdy oba systemy możesz zmienić i prościej ujednolicić kontrakt.
2. Gdy pojawia się wielowarstwowy łańcuch adapterów.
3. Gdy mapowanie zaciera semantykę danych i utrudnia testowanie.

W praktyce oznacza to, że adapter przestaje być cienką warstwą translacji, a staje się ukrytą logiką biznesową. To sygnał, że należy się zatrzymać i zmienić kierunek architektury.

## Czerwone flagi over-engineeringu

1. Adapter ma więcej kodu niż klient i adaptee razem.
2. Jedno pole wejściowe jest mapowane przez wiele reguł warunkowych.
3. Każda nowa wersja API wymaga zmian w wielu adapterach naraz.
4. Testy adaptera są kruche i zależne od kolejności mapowań.

Jeśli widzisz kilka z tych sygnałów jednocześnie, rozważ uproszczenie granicy integracji.

## Alternatywy

- Facade: uproszczenie API bez translacji semantycznej.
- Anti-Corruption Layer: większa warstwa izolacji między bounded contexts.
- Refaktoryzacja kontraktu: najczystsza opcja, jeśli obie strony są pod kontrolą.

## Jak podjąć decyzję

1. Oszacuj koszt zmiany klienta i koszt zmiany dostawcy API.
2. Oceń ryzyko semantyczne mapowania (czy znaczenie danych pozostanie czytelne).
3. Sprawdź horyzont czasowy: tymczasowa migracja czy wieloletnia integracja.
4. Porównaj koszt utrzymania po 6-12 miesiącach, a nie tylko koszt startu.

Krótka heurystyka:

- jeśli integracja jest tymczasowa i API zewnętrzne jest poza kontrolą zespołu: Adapter,
- jeśli granica domen jest trwała i złożona: Anti-Corruption Layer,
- jeśli oba moduły są pod Twoją kontrolą: refaktoryzacja kontraktu.

## Diagramy

![Decyzja adapter czy nie](diagrams/decision_not_use_adapter.png)

Źródło: [diagrams/01-decision-not-use.puml](diagrams/01-decision-not-use.puml)

![Alternatywy](diagrams/alternatives_map.png)

Źródło: [diagrams/02-alternatives-map.puml](diagrams/02-alternatives-map.puml)

## Studium przypadku (bez kodu)

Program demonstracyjny: [Examples/Program.cs](Examples/Program.cs)

### Szczegółowe założenia programu

Program porównuje trzy opcje integracji:

1. `Adapter`
2. `Facade`
3. `Refactor`

Dla każdej opcji modeluje:

- koszt startowy (`InitialCostPoints`),
- miesięczny koszt utrzymania (`MonthlyMaintenancePoints`),
- współczynnik ryzyka semantycznego (`SemanticRiskFactor`),
- horyzont czasowy analizy (w przykładzie: `12` miesięcy).

Model kosztu całkowitego:

$$Total = (Initial + Monthly \cdot Months) \cdot RiskFactor$$

Interpretacja modelu:

1. Wysoki koszt startowy nie zawsze oznacza gorszą decyzję, jeśli utrzymanie jest tanie.
2. Ryzyko semantyczne zwiększa koszt całkowity, bo oznacza większe prawdopodobieństwo błędów i poprawek.
3. Przy dłuższym horyzoncie utrzymanie zwykle dominuje nad kosztem wejścia.

### Tabela wyników i wyjaśnienie

Założenia z programu: `Months = 12`.

| Opcja | Initial | Monthly | RiskFactor | Baseline = Initial + Monthly*12 | Total po ryzyku | Wyjaśnienie |
| --- | ---: | ---: | ---: | ---: | ---: | --- |
| Adapter | 8.0 | 2.5 | 1.30 | 38.0 | 49.4 | Niski koszt wejścia, ale najwyższy koszt utrzymania i największe ryzyko semantyczne. |
| Facade | 6.0 | 2.0 | 1.10 | 30.0 | 33.0 | Dobry kompromis, gdy chcesz uprościć API bez ciężkiej translacji znaczenia danych. |
| Refactor | 14.0 | 0.9 | 1.00 | 24.8 | 24.8 | Najdroższy start, ale najtańsze utrzymanie i brak narzutu ryzyka semantycznego. |

Wniosek z tabeli:

1. Dla 12 miesięcy najlepszy wynik daje `Refactor` (`24.8`), mimo najwyższego kosztu początkowego.
2. `Adapter` przegrywa w koszcie całkowitym, bo płaci się za niego co miesiąc i dodatkowo za ryzyko translacji.
3. `Facade` bywa rozsądnym wyborem pośrednim, gdy pełna refaktoryzacja nie jest jeszcze możliwa.

### Kontrprzykład: kiedy Adapter nie jest dobrym rozwiązaniem

Przykład z programu pokazuje złą decyzję adapterową w takim kontekście:

1. Obie strony integracji są pod Twoją kontrolą.
2. Integracja ma charakter długoterminowy (12+ miesięcy).
3. Mapowanie danych nie jest trywialne i niesie ryzyko semantyczne.

W takim układzie Adapter staje się warstwą stałego kosztu i ryzyka, a lepszym wyborem jest refaktoryzacja kontraktu.

Uruchomienie programu (opcjonalnie, aby odtworzyć wyniki):

```bash
cd src/06-adapter/05-kiedy-nie-i-alternatywy/Examples
dotnet run -c Release
```

package korszun.kacper

import java.text.SimpleDateFormat
import java.util.Date

import korszun.kacper.CarDealerApp.CarType

/*
 Metoda wytwórcza:
Zalety:
- rozdzielenie miejsca tworzenia obiektu z procesem tworzenia (interfejs Creator)
- luźne powiązanie pomiędzy klasami obiektów a aplikacją
- możliwość podmiany klasy na inną spełniającą te same założenia bez zmiany kodu aplikacji
- Struktura wzorca pozwala przesunąć operacje zarządzania wytwarzanymi obiektami poza główny program

Wady:
- Konieczność spełnienia wymagań interfejsu
- Operacje inne niż wytwarzanie nie muszą być pożądane przez klienta
 */


object Main extends App {
  override def main(args: Array[String]): Unit = {
    for(x:Int <- 1 to 10){
      println(CarDealerApp.newCar(CarType.COUPE))
      println(CarDealerApp.newCar(CarType.VAN))
      println(CarDealerApp.newCar(CarType.HATCHBACK))
    }
  }
}

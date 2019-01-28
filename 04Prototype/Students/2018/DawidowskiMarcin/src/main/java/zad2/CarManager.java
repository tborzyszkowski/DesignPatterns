package zad2;

import zad2.brand.BrandName;
import zad2.carType.CarType;
import zad2.carType.Transmission;
import zad2.carType.Type;
import zad2.engine.Engine;
import zad2.engine.EngineType;

public class CarManager {
    public Car createCar() {
        Engine engine = new Engine(EngineType.V10, 500);
        Type type = new Type(CarType.Muscle, Transmission.Manual);
        return new Car(
                BrandName.Ford,
                engine,
                type
        );
    }
}

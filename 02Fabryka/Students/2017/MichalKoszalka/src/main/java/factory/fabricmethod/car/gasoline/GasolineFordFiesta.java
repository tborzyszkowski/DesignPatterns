package factory.fabricmethod.car.gasoline;

import factory.simple.BodyType;
import factory.simple.Ford;

public class GasolineFordFiesta extends Ford {

    public GasolineFordFiesta() {
        this.model = "Fiesta";
        this.bodyType = BodyType.HATCHBACK;
    }

    @Override
    public void refuel() {
        System.out.println("refueling car with gasoline");
    }

}

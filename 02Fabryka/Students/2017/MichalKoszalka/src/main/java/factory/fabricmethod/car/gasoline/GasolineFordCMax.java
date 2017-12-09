package factory.fabricmethod.car.gasoline;

import factory.simple.BodyType;
import factory.simple.Ford;

public class GasolineFordCMax extends Ford {

    public GasolineFordCMax() {
        this.model = "C-Max";
        this.bodyType = BodyType.MINIVAN;
    }

    @Override
    public void refuel() {
        System.out.println("refueling car with gasoline");
    }
}

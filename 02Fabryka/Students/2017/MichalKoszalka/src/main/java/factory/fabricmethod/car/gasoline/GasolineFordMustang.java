package factory.fabricmethod.car.gasoline;

import factory.simple.BodyType;
import factory.simple.Ford;

public class GasolineFordMustang extends Ford {

    public GasolineFordMustang() {
        this.model = "Mustang";
        this.bodyType = BodyType.SEDAN;
    }

    @Override
    public void refuel() {
        System.out.println("refueling car with gasoline");
    }

}

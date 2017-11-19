package factory.fabricmethod.car.oil;

import factory.simple.BodyType;
import factory.simple.Ford;

public class OilFordMustang extends Ford {

    public OilFordMustang() {
        this.model = "Mustang";
        this.bodyType = BodyType.HATCHBACK;
    }

    @Override
    public void refuel() {
        System.out.println("refueling car with oil");
    }

}


package factory.fabricmethod.car.oil;

import factory.simple.BodyType;
import factory.simple.Ford;

public class OilFordCMax extends Ford {

    public OilFordCMax() {
        this.model = "C-Max";
        this.bodyType = BodyType.MINIVAN;
    }

    @Override
    public void refuel() {
        System.out.println("refueling car with oil");
    }
}

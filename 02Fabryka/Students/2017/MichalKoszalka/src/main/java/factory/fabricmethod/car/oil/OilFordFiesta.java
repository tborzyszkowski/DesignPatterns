package factory.fabricmethod.car.oil;

import factory.simple.BodyType;
import factory.simple.Ford;

public class OilFordFiesta extends Ford {

    public OilFordFiesta() {
        this.model = "Fiesta";
        this.bodyType = BodyType.HATCHBACK;
    }

    @Override
    public void refuel() {
        System.out.println("refueling car with oil");
    }

}

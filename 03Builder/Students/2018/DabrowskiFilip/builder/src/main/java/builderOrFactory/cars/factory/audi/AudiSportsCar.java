package builderOrFactory.cars.factory.audi;

import builderOrFactory.cars.Car;

public class AudiSportsCar extends Car {
    public AudiSportsCar() {
        this.name = "audi";
        this.model = "RS7";
        this.productionYear = 2016;
        this.gearBoxType = "manual";
    }
}

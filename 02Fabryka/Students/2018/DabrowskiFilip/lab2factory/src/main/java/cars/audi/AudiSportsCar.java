package cars.audi;

import cars.Car;

public class AudiSportsCar extends Car {
    public AudiSportsCar() {
        this.name = "audi";
        this.model = "RS7";
        this.productionYear = 2016;
        this.gearBoxType = "manual";
    }

    @Override
    public String toString() {
        return "AudiSportsCar{" +
                "name='" + name + '\'' +
                ", productionYear=" + productionYear +
                ", model='" + model + '\'' +
                ", gearBoxType='" + gearBoxType + '\'' +
                '}';
    }
}

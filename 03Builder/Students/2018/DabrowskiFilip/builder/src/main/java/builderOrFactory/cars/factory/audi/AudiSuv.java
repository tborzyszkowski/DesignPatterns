package builderOrFactory.cars.factory.audi;

import builderOrFactory.cars.Car;

public class AudiSuv extends Car {
    public AudiSuv() {
        this.name = "audi";
        this.model = "Q7";
        this.productionYear = 2015;
        this.gearBoxType = "automatic";
    }

    @Override
    public String toString() {
        return "AudiSuv{" +
                "name='" + name + '\'' +
                ", productionYear=" + productionYear +
                ", model='" + model + '\'' +
                ", gearBoxType='" + gearBoxType + '\'' +
                '}';
    }
}

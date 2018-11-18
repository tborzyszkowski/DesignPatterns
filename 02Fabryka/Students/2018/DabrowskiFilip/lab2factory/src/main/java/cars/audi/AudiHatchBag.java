package cars.audi;

import cars.Car;

public class AudiHatchBag extends Car {
    public AudiHatchBag() {
        this.name = "audi";
        this.model = "A3";
        this.productionYear = 2018;
        this.gearBoxType = "automatic";
    }

    @Override
    public String toString() {
        return "AudiHatchBag{" +
                "name='" + name + '\'' +
                ", productionYear=" + productionYear +
                ", model='" + model + '\'' +
                ", gearBoxType='" + gearBoxType + '\'' +
                '}';
    }
}

package cars.audi;

import cars.Car;

public class AudiLimo extends Car {
    public AudiLimo() {
        this.name = "audi";
        this.model = "A8";
        this.productionYear = 2015;
        this.gearBoxType = "automatic";
    }

    @Override
    public String toString() {
        return "AudiLimo{" +
                "name='" + name + '\'' +
                ", productionYear=" + productionYear +
                ", model='" + model + '\'' +
                ", gearBoxType='" + gearBoxType + '\'' +
                '}';
    }
}

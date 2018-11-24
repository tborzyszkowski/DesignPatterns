package builderOrFactory.cars;

public abstract class Car {

    public String name;
    public int productionYear;
    public String model;
    public String gearBoxType;

    @Override
    public String toString() {
        return "Car{" +
                "name='" + name + '\'' +
                ", productionYear=" + productionYear +
                ", model='" + model + '\'' +
                ", gearBoxType='" + gearBoxType + '\'' +
                '}';
    }
}

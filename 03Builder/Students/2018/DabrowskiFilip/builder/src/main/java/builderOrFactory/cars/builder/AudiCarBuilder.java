package builderOrFactory.cars.builder;

public class AudiCarBuilder {

    private AudiCar audiCar;

    public AudiCarBuilder() {
        this.audiCar = new AudiCar();
    }

    public AudiCarBuilder withProductionYear(int productionYear) {
        this.audiCar.productionYear = productionYear;
        return this;
    }

    public AudiCarBuilder withName(String name) {
        this.audiCar.name = name;
        return this;
    }

    public AudiCarBuilder withModel(String model) {
        this.audiCar.model = model;
        return this;
    }

    public AudiCarBuilder withGearboxType(String gearBoxType) {
        this.audiCar.gearBoxType = gearBoxType;
        return this;
    }

    public AudiCar buildAudiCar() {
        return this.audiCar;
    }
}

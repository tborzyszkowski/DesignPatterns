package builderVsFactory.builder;

public class KIABuilder {

    private KIA kia;

    public KIABuilder() {
        this.kia = new KIA();
    }

    public KIABuilder withBrand(String brandName) {
        this.kia.brandName = brandName;
        return this;
    }

    public KIABuilder withModel(String model) {
        this.kia.model = model;
        return this;
    }

    public KIABuilder withType(String type) {
        this.kia.type = type;
        return this;
    }

    public KIABuilder withFuelType(String fuelType) {
        this.kia.fuelType = fuelType;
        return this;
    }

    public KIABuilder withPrice(int price) {
        this.kia.price = price;
        return this;
    }

    public KIA buildKIA() {
        return this.kia;
    }
}

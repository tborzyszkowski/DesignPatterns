package SimpleFactory;

public class KIA extends Car {

    public KIA() {
        this.brandName = "KIA";
        this.model = "Stinger GT Line";
        this.type = "Sedan";
        this.fuelType = "Diesel";
        this.price = 180000;
    }

    @Override
    public String toString() {
        return  "name = " + brandName +
                ", model = " + model +
                ", type = " + type +
                ", fuel type = " + fuelType +
                ", price = " + price ;
    }
}

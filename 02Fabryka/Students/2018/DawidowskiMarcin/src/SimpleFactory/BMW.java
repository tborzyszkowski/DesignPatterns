package SimpleFactory;

public class BMW extends Car {

    public BMW() {
        this.brandName = "BMW";
        this.model = "M3 E93";
        this.type = "Cabrio";
        this.fuelType = "Gasoline";
        this.price = 135000;
    }

    @Override
    public String toString() {
        return  "name = " + brandName +
                ", model = " + model +
                ", type = " + type +
                ", fuel type = " + fuelType +
                ", price = " + price;
    }
}

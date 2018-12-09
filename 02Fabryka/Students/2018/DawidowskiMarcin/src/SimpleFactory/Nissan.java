package SimpleFactory;

public class Nissan extends Car {
    public Nissan() {
        this.brandName = "Nissan";
        this.model = "GT-R Nismo";
        this.type = "Coupe";
        this.fuelType = "Gasoline";
        this.price = 791500;
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

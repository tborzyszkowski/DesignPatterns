package SimpleFactory;

public class AstonMartin extends Car {

    public AstonMartin() {
        this.brandName = "Aston Martin";
        this.model = "DB11";
        this.type = "Coupe";
        this.fuelType = "Gasoline";
        this.price = 915000;
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
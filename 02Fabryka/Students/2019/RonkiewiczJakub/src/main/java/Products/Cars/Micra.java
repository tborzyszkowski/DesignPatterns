package Products.Cars;

import Products.Body;
import Products.Brand;
import Products.Car;

public class Micra extends Car {
    public Micra() {
        brand = Brand.NISSAN;
        model = "Micra";
        body = Body.HATCHBACK;
        maxSpeed = 150;
        price = 25000;
    }

    public Micra CreateMicra() {
        return new Micra();
    }
}

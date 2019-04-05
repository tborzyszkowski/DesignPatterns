package Products.Cars;

import Products.Body;
import Products.Brand;
import Products.Car;

public class Civic extends Car {
    public Civic() {
        brand = Brand.HONDA;
        model = "Civic";
        body = Body.HATCHBACK;
        maxSpeed = 200;
        price = 70000;
    }

    public Civic CreateCivic() {
        return new Civic();
    }
}

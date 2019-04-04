package Products.Cars;

import Products.Body;
import Products.Brand;
import Products.Car;

public class Carrera extends Car {
    public Carrera(){
        brand = Brand.PORSCHE;
        model = "Carrera GT";
        body = Body.ROADSTER;
        maxSpeed = 354;
        price = 500000;
    }

    public Carrera CreateCarrera(){
        return new Carrera();
    }
}

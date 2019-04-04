package FactorySupplier;

import Products.Car;
import Products.Cars.Carrera;

import java.util.function.Supplier;

public class CarreraSupplier implements Supplier<Car> {
    @Override
    public Carrera get() {
        return new Carrera();
    }
}

package FactorySupplier;

import Products.Car;

import java.util.HashMap;
import java.util.Map;
import java.util.function.Supplier;

public class RegistartionCarFactory {
    private static RegistartionCarFactory instance;
    private Map<String, Supplier<? extends Car>> registeredSuppliers = new HashMap<>();

    private RegistartionCarFactory() {}

    public static RegistartionCarFactory getInstance() {
        if (instance == null)
            instance = new RegistartionCarFactory();
        return instance;
    }

    public void registerSupplier(String type, Supplier<? extends  Car> supplier) {
        registeredSuppliers.put(type, supplier);
    }

    public Car getCar(String type) {
        Supplier<? extends Car> supplier = registeredSuppliers.get(type);
        return supplier != null ? supplier.get() : null;
    }
}

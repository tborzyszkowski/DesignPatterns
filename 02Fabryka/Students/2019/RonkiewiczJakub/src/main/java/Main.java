import AbstractFactory.HondaFactory;
import AbstractFactory.Store;
import FactoryMethod.CarStore;
import FactoryReflection.ReflectionCarFactory;
import FactorySupplier.RegistartionCarFactory;
import Products.Cars.Civic;
import Products.Vehicle;
import SimpleFactory.VehicleStore;

import java.lang.reflect.InvocationTargetException;
import java.time.Duration;
import java.time.Instant;
import java.util.LinkedHashMap;
import java.util.Map;

public class Main {
    @SuppressWarnings({"Duplicates"})
    public static void main(String[] args) throws InvocationTargetException, NoSuchMethodException, InstantiationException, IllegalAccessException {

        // Variables for time storage
        Instant start;
        Instant finish;
        long elapsed;
        Map<String, Long> times = new LinkedHashMap<>();

        // Prepare all factories
        // I will be creating only cars

        var simple = new VehicleStore(); // Simple Factory
        var factoryMethod = CarStore.getInstance(); // Factory Method
        var abstractFactory = new Store(HondaFactory.getInstance()); // AbstractFactory
        var reflectionFactory = ReflectionCarFactory.getInstance(); // Registration with reflection
            reflectionFactory.registerType("civic", Civic.class);
        var noRefectionFactory = RegistartionCarFactory.getInstance(); // Registration without reflection
            noRefectionFactory.registerSupplier("civic", Civic::new);

        int n = 10_000_000;
        Vehicle car;


        // SIMPLE FACTORY ===================================
        start = Instant.now();
        for(int i = 0; i < n; i++){
            car = simple.OrderCar("civic");
        }
        finish = Instant.now();
        elapsed = Duration.between(start,finish).toMillis();
        times.put("Simple Factory", elapsed);

        // FACTORY METHOD ===================================
        start = Instant.now();
        for(int i = 0; i < n; i++){
            car = factoryMethod.Build("civic");
        }
        finish = Instant.now();
        elapsed = Duration.between(start,finish).toMillis();
        times.put("Factory Method", elapsed);

        // ABSTRACT FACTORY ===================================
        start = Instant.now();
        for(int i = 0; i < n; i++){
            car = abstractFactory.BuildCar();
        }
        finish = Instant.now();
        elapsed = Duration.between(start,finish).toMillis();
        times.put("Abstract Factory", elapsed);

        // REFLECTION FACTORY ===================================
        start = Instant.now();
        for(int i = 0; i < n; i++){
            car = reflectionFactory.getCar("civic");
        }
        finish = Instant.now();
        elapsed = Duration.between(start,finish).toMillis();
        times.put("Reflection Factory", elapsed);

        // NO REFLECTION FACTORY ===================================
        start = Instant.now();
        for(int i = 0; i < n; i++){
            car = noRefectionFactory.getCar("civic");
        }
        finish = Instant.now();
        elapsed = Duration.between(start,finish).toMillis();
        times.put("No Reflection Factory", elapsed);

        times.forEach((k,v)->System.out.format("%-30s: %5d ms\n",k,v));

    }
}

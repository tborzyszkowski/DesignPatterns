package fabryka;

import java.util.HashMap;
import java.util.Map;
import java.util.function.Supplier;

// Dopisz opis i wyślij
public class CarFactory {
    private final Map<String, Supplier<Car>> suppliers;

    public CarFactory() {
        suppliers = new HashMap<>();
    }

    public void register(String id, Supplier<Car> supplier) {
        suppliers.put(id, supplier);
    }

    public Car createCar(String id) {
        Supplier<Car> s = suppliers.get(id);
        if (s != null)
            return s.get();

        return null;
    }
}

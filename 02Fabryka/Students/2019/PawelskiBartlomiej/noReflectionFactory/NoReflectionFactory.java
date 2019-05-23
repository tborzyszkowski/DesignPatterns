package noReflectionFactory;

import computers.*;
import java.util.HashMap;
import java.util.function.Supplier;

public enum NoReflectionFactory {
    INSTANCE;
    private HashMap<String, Supplier<? extends Computer>> registeredSuppliers = new HashMap<>();

    public void registerSupplier(String hash, Supplier<? extends Computer> supplier) {
        registeredSuppliers.put(hash, supplier);
    }

    public Computer getComputer(String hash) {
        Supplier<? extends Computer> supplier = registeredSuppliers.get(hash);
        return supplier.get();
    }
}


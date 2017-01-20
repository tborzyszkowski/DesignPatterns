package engine.registry.decorators;

import engine.registry.RegistryPrinter;
import lombok.AllArgsConstructor;

/**
 * Created by jakub on 1/20/17.
 */
@AllArgsConstructor
public class RegistryDecorator implements RegistryPrinter {

    RegistryPrinter decorated;

    @Override
    public void printRegistry() {
        decorated.printRegistry();
    }
}

package engine.registry.decorators;

import engine.registry.RegistryPrinter;

/**
 * Created by jakub on 1/20/17.
 */
public class DottedRegistryDecorator extends RegistryDecorator {

    public DottedRegistryDecorator(RegistryPrinter decorated) {
        super(decorated);
    }

    @Override
    public void printRegistry() {
        System.out.println(".................................");
        decorated.printRegistry();
        System.out.println(".................................");
    }
}

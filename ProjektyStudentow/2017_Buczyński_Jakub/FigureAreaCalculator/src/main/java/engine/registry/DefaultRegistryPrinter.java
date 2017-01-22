package engine.registry;

import engine.registry.RegistryPrinter;
import lombok.AllArgsConstructor;

import java.util.List;

/**
 * Created by jakub on 1/20/17.
 */
@AllArgsConstructor
public class DefaultRegistryPrinter implements RegistryPrinter {

    private List<String> registryTextLines;

    @Override
    public void printRegistry() {
        System.out.println();
        registryTextLines.forEach(System.out::println);
        System.out.println();
    }
}

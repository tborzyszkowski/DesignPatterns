package commands;

import engine.registry.Registry;
import engine.registry.RegistryPrinter;
import engine.registry.decorators.DecoratorRegistry;
import lombok.NoArgsConstructor;
import lombok.extern.log4j.Log4j;

import java.util.Optional;

/**
 * Created by jakub on 1/18/17.
 */
@NoArgsConstructor
@Log4j
public class ShowAllCommand extends ActionCommand {
    private String decoration;
    private RegistryPrinter decorator;

    public ShowAllCommand(String decoration) {
        this.decoration = decoration;
    }

    @Override
    public void execute() {
        if (checkForDecorator()) {
            decorator.printRegistry();
            return;
        }
        Registry.INSTANCE.getRegistryPrinter().printRegistry();

    }

    private boolean checkForDecorator() {
        Optional<String> decoration = Optional.ofNullable(this.decoration);
        if (decoration.isPresent()) {
            Optional<RegistryPrinter> decoratorOpt = Optional.ofNullable(tryCreateDecorator(decoration));
            if (decoratorOpt.isPresent()) {
                this.decorator = decoratorOpt.get();
                return true;
            }
        }
        return false;
    }

    private RegistryPrinter tryCreateDecorator(Optional<String> decoration) {
        try {
            return DecoratorRegistry.INSTANCE.createRegistryDecorator(decoration.get(), Registry.INSTANCE.getRegistryPrinter());
        } catch (Exception e) {
            log.debug(e);
            return null;
        }
    }
}

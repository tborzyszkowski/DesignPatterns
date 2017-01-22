package engine.intializer;

import commands.factory.conrete.HelpCommandFactory;
import engine.AreaResult;
import commands.factory.CommandRegistry;
import commands.factory.conrete.AreaCommandFactory;
import commands.factory.conrete.ExitCommandFactory;
import commands.factory.conrete.ShowAllCommandFactory;
import engine.registry.Registry;
import engine.registry.decorators.DashedRegistryDecorator;
import engine.registry.decorators.DecoratorRegistry;
import engine.registry.decorators.DottedRegistryDecorator;
import figure.factory.FigureRegistry;
import figure.factory.FigureTypes;
import figure.factory.concrete.CircleFactory;
import figure.factory.concrete.RectangleFactory;
import figure.factory.concrete.TriangleFactory;
import lombok.extern.log4j.Log4j;
import rx.subjects.BehaviorSubject;

/**
 * Created by jakub on 1/18/17.
 */
@Log4j
public class EngineInitializer {
    public void initialize() {
        initializeRegistryDecorators();
        initializeCommandFactories();
        initializeFigureFactories();
    }

    private void initializeRegistryDecorators() {
        log.info("initializing registry decorators...");
        DecoratorRegistry.INSTANCE.registerRegistryDecorator("dotted", DottedRegistryDecorator.class);
        DecoratorRegistry.INSTANCE.registerRegistryDecorator("dashed", DashedRegistryDecorator.class);
    }

    private void initializeFigureFactories() {
        log.info("initializing figure factories...");
        FigureRegistry.INSTANCE.registerFactory(FigureTypes.CIRCLE, new CircleFactory());
        FigureRegistry.INSTANCE.registerFactory(FigureTypes.RECTANGLE, new RectangleFactory());
        FigureRegistry.INSTANCE.registerFactory(FigureTypes.TRIANGLE, new TriangleFactory());
    }

    private void initializeCommandFactories() {
        log.info("initializing command factories...");

        initializeAreaFactory();
        CommandRegistry.INSTANCE.registerCommand("exit", new ExitCommandFactory());
        CommandRegistry.INSTANCE.registerCommand("showall", new ShowAllCommandFactory());
        CommandRegistry.INSTANCE.registerCommand("help", new HelpCommandFactory());
    }

    private void subscribeToAreaResults(BehaviorSubject<AreaResult> areaCommandObserver) {
        areaCommandObserver.subscribe(result -> {
            System.out.println("pole figury wynosi : " + result.getResult());
            Registry.INSTANCE.addRegistryEntry(result);
        });
    }

    private void initializeAreaFactory() {
        BehaviorSubject<AreaResult> areaCommandObserver = BehaviorSubject.create();
        subscribeToAreaResults(areaCommandObserver);
        CommandRegistry.INSTANCE.registerCommand("area", new AreaCommandFactory(areaCommandObserver));
    }
}

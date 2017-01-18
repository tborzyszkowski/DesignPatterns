package engine.intializer;

import engine.AreaResult;
import engine.commands.factory.CommandRegistry;
import engine.commands.factory.conrete.AreaCommandFactory;
import engine.commands.factory.conrete.ExitCommandFactory;
import engine.commands.factory.conrete.ShowAllCommandFactory;
import engine.registry.Registry;
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
        initializeCommandFactories();
        initializeFigureFactories();
    }

    private void initializeFigureFactories() {
        FigureRegistry.INSTANCE.registerFactory(FigureTypes.CIRCLE, new CircleFactory());
        FigureRegistry.INSTANCE.registerFactory(FigureTypes.RECTANGLE, new RectangleFactory());
        FigureRegistry.INSTANCE.registerFactory(FigureTypes.TRIANGLE, new TriangleFactory());
    }

    private void initializeCommandFactories() {
        BehaviorSubject<AreaResult> areaCommandObserver = BehaviorSubject.create();
        subcribeToAreaResults(areaCommandObserver);
        CommandRegistry.INSTANCE.registerCommand("area", new AreaCommandFactory(areaCommandObserver));

        CommandRegistry.INSTANCE.registerCommand("exit", new ExitCommandFactory());

        CommandRegistry.INSTANCE.registerCommand("showall", new ShowAllCommandFactory());
    }

    private void subcribeToAreaResults(BehaviorSubject<AreaResult> areaCommandObserver) {
        areaCommandObserver.subscribe(result -> {
            Registry.INSTANCE.addRegistryEntry(result);
        });
    }
}

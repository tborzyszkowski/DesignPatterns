package figure.factory;

import figure.Figure;
import figure.stub.FigureStub;
import lombok.extern.log4j.Log4j;

import java.util.*;

/**
 * Created by jakub on 1/18/17.
 */
@Log4j
public enum FigureRegistry {

    INSTANCE;

    private Map<String, FigureFactory> factories = new HashMap<>();

    public void registerFactory(String figureType, FigureFactory factory) {
        factories.put(figureType, factory);
    }

    public Optional<Figure> createFigure(FigureStub figureStub) throws Exception {
        if (!Optional.ofNullable(figureStub).isPresent()) {
            return Optional.empty();
        }
        Optional<FigureFactory> figureFactory = Optional.ofNullable(factories.get(figureStub.getFigureName()));
        if(figureFactory.isPresent()) {
            return Optional.ofNullable(figureFactory.get().createFigure(figureStub));
        }

        return Optional.empty();
    }

}

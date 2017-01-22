package figure.factory;

import figure.Figure;
import figure.stub.FigureStub;

/**
 * Created by jakub on 1/18/17.
 */
public interface FigureFactory {
    Figure createFigure(FigureStub figureStub) throws Exception;
}

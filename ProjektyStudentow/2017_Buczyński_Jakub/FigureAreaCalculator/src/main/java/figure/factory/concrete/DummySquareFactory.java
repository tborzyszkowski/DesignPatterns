package figure.factory.concrete;

import figure.Figure;
import figure.factory.FigureFactory;
import figure.stub.FigureStub;

/**
 * Created by jakub on 1/18/17.
 */
public class DummySquareFactory implements FigureFactory {
    @Override
    public Figure createFigure(FigureStub figureStub) {
        return null;
    }
}

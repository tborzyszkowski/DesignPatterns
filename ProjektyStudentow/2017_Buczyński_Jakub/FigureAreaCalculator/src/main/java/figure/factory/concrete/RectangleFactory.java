package figure.factory.concrete;

import figure.Circle;
import figure.Figure;
import figure.Rectangle;
import figure.factory.FigureFactory;
import figure.factory.FigureTypes;
import figure.stub.FigureStub;

import java.util.List;

/**
 * Created by jakub on 1/18/17.
 */
public class RectangleFactory implements FigureFactory {
    @Override
    public Figure createFigure(FigureStub figureStub) throws Exception {
        if (figureStub.getFigureName().equals(FigureTypes.RECTANGLE)) {
            return buildRectangleWithParams(figureStub.getFigureParams());
        } else {
            throw new Exception("invalid figure");
        }
    }

    private Figure buildRectangleWithParams(List<String> params) throws Exception {
        if (params.size() >= 2) {
            return Rectangle.builder()
                    .sideA(Double.parseDouble(params.get(0)))
                    .sideB(Double.parseDouble(params.get(1)))
                    .build();

        }
        throw new Exception("wrong rectangle parameters number");
    }
}

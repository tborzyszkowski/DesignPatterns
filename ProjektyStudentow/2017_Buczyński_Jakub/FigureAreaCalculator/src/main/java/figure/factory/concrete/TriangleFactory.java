package figure.factory.concrete;

import figure.Figure;
import figure.Rectangle;
import figure.Triangle;
import figure.factory.FigureFactory;
import figure.factory.FigureTypes;
import figure.stub.FigureStub;

import java.util.List;

/**
 * Created by jakub on 1/18/17.
 */
public class TriangleFactory implements FigureFactory {
    @Override
    public Figure createFigure(FigureStub figureStub) throws Exception {
        if (figureStub.getFigureName().equals(FigureTypes.TRIANGLE)) {
            return buildtriangleWithParams(figureStub.getFigureParams());
        } else {
            throw new Exception("invalid figure");
        }
    }

    private Figure buildtriangleWithParams(List<String> params) throws Exception {
        if (params.size() == 2) {
            return Triangle.builder()
                    .sideA(Double.parseDouble(params.get(0)))
                    .height(Double.parseDouble(params.get(1)))
                    .build();

        } else if (params.size() > 2) {
            return Triangle.builder()
                    .sideA(Double.parseDouble(params.get(0)))
                    .sideB(Double.parseDouble(params.get(1)))
                    .sideC(Double.parseDouble(params.get(2)))
                    .build();
        }
        throw new Exception("wrong triangle parameters number");
    }
}

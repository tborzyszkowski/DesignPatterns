package figure.factory.concrete;

import figure.Circle;
import figure.Figure;
import figure.factory.FigureFactory;
import figure.factory.FigureTypes;
import figure.stub.FigureStub;

import java.util.List;

/**
 * Created by jakub on 1/18/17.
 */
public class CircleFactory implements FigureFactory {
    @Override
    public Figure createFigure(FigureStub figureStub) throws Exception {
        if (figureStub.getFigureName().equals(FigureTypes.CIRCLE)) {
            return buildCircleWithParams(figureStub.getFigureParams());
        } else {
            throw new Exception(" invalid figure ");
        }
    }

    private Figure buildCircleWithParams(List<String> params) throws Exception {
        if (params.size() > 0) {
            return Circle.builder()
                    .radius(Double.parseDouble(params.get(0)))
                    .build();

        }
        throw new Exception("wrong circle parameters number");
    }
}

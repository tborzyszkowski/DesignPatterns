package commands.factory.conrete;

import engine.AreaResult;
import commands.ActionCommand;
import commands.AreaCommand;
import commands.factory.CommandFactory;
import figure.Figure;
import figure.factory.FigureRegistry;
import figure.stub.FigureStub;
import lombok.AllArgsConstructor;
import lombok.NoArgsConstructor;
import rx.subjects.BehaviorSubject;

import java.util.List;
import java.util.Optional;

/**
 * Created by jakub on 1/18/17.
 */
@AllArgsConstructor
@NoArgsConstructor
public class AreaCommandFactory implements CommandFactory {
    BehaviorSubject<AreaResult> subject;

    @Override
    public ActionCommand createCommand(List<String> params) throws Exception {
        return new AreaCommand(createFigure(params), subject);
    }

    private Figure createFigure(List<String> params) throws Exception {
        if(params.size() <=0) {
            throw new Exception("not sufficient params number \n" +
                    "valid usage: area figureName param1 param2 ...");
        }
        String figureName = params.get(0);
        params = params.subList(1, params.size());
        Optional<Figure> figure = FigureRegistry.INSTANCE.createFigure(FigureStub.builder()
                .figureName(figureName)
                .figureParams(params)
                .build());
        if (figure.isPresent()) {
            return figure.get();
        }
        throw new Exception("cannot instantiate figure");
    }
}

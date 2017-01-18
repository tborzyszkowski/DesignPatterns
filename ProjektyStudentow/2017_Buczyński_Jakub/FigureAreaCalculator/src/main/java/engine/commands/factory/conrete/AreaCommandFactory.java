package engine.commands.factory.conrete;

import engine.AreaResult;
import engine.commands.ActionCommand;
import engine.commands.AreaCommand;
import engine.commands.factory.CommandFactory;
import engine.commands.stub.CommandStub;
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
    public ActionCommand createCommand(CommandStub commandStub) throws Exception {
        return new AreaCommand(createFigure(commandStub), subject);
    }

    private Figure createFigure(CommandStub commandStub) throws Exception {
        List<String> params = commandStub.getCommandParams();
        String figureName = params.get(0);
        params = commandStub.getCommandParams().subList(1, commandStub.getCommandParams().size());
        Optional<Figure> figure = FigureRegistry.INSTANCE.createFigure(FigureStub.builder()
                .figureName(figureName)
                .figureParams(params)
                .build());
        if (figure.isPresent()) {
            return figure.get();
        }
        throw new Exception("cannot instantioate figure");
    }
}

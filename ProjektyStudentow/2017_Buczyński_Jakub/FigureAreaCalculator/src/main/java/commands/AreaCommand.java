package commands;

import engine.AreaResult;
import figure.Figure;
import lombok.extern.log4j.Log4j;
import rx.subjects.BehaviorSubject;

/**
 * Created by jakub on 1/16/17.
 */
@Log4j
public class AreaCommand extends ActionCommand {

    private Figure figure;
    BehaviorSubject<AreaResult> subject;

    public AreaCommand(Figure figure, BehaviorSubject<AreaResult> subject) {
        this.figure = figure;
        this.subject = subject;
    }

    @Override
    public void execute() {
        notifySubject(figure.computeArea());
    }

    @Override
    public String toString() {
        return "COMMAND: area on figure " + figure + " ";
    }

    private void notifySubject(double result) {
        AreaResult areaResult = AreaResult.builder()
                .result(result)
                .figure(figure)
                .build();
        subject.onNext(areaResult);
    }
}

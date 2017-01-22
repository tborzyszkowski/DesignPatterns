package input.marshaller;

import commands.stub.CommandStub;
import rx.Observer;
import rx.Subscription;
import rx.subjects.BehaviorSubject;

import java.util.Arrays;
import java.util.List;

/**
 * Created by jakub on 1/18/17.
 */
public class DefaultInputMarshaler implements InputMarshaler {

    BehaviorSubject<CommandStub> subject = BehaviorSubject.create();

    @Override
    public void parseInput(String inputLine) {
        parse(inputLine.split("\\s+"));

    }

    @Override
    public Subscription subscribeInput(Observer observer) {
        return subject.subscribe(observer);
    }

    private void parse(String[] commandTokens) {

        String commandName = parseCommand(commandTokens);

        List<String> arguments = parseArguments(commandTokens);

        notifySubject(commandName, arguments);

    }

    private String parseCommand(String[] commandTokens) {
        return commandTokens[0];
    }

    private List<String> parseArguments(String[] commandTokens) {
        return Arrays.asList(commandTokens).subList(1, commandTokens.length);
    }

    private void notifySubject(String commandName, List<String> arguments) {
        CommandStub commandStub = CommandStub.builder()
                .commandName(commandName)
                .commandParams(arguments)
                .build();
        subject.onNext(commandStub);
    }
}

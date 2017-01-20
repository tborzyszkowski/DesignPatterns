package input;

import engine.CommandStubObserver;
import commands.stub.CommandStub;
import input.marshaller.InputMarshaller;
import lombok.extern.log4j.Log4j;
import rx.subjects.BehaviorSubject;

import java.util.Scanner;

/**
 * Created by jakub on 1/18/17.
 */
@Log4j
public class CommandLineInput {
    public void startCommandLine() {
        System.out.println("Welcome to area calculator!");
        System.out.println("enter command... ");
        Scanner scanner = new Scanner(System.in);
        InputMarshaller inputMarshaller = new InputMarshaller(createMarshallerSubjectAndObserver());
        while (true) {
            String line = scanner.nextLine();
            inputMarshaller.parseInput(line);
            System.out.println("enter command... ");
        }
    }

    private BehaviorSubject<CommandStub> createMarshallerSubjectAndObserver() {
        BehaviorSubject<CommandStub> marshallerSubject = BehaviorSubject.create();
        marshallerSubject.subscribe(new CommandStubObserver());
        return marshallerSubject;
    }
}

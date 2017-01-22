package input;

import engine.CommandStubObserver;
import commands.stub.CommandStub;
import input.marshaller.DefaultInputMarshaler;
import input.marshaller.InputMarshaler;
import lombok.AllArgsConstructor;
import lombok.extern.log4j.Log4j;
import rx.subjects.BehaviorSubject;

import java.util.Scanner;

/**
 * Created by jakub on 1/18/17.
 */
@Log4j
@AllArgsConstructor
public class CommandLineInput {
    InputMarshaler inputMarshaller;

    public void startCommandLine() {
        System.out.println("Welcome to area calculator!");
        System.out.println("enter command... ");
        Scanner scanner = new Scanner(System.in);
        while (true) {
            String line = scanner.nextLine();
            inputMarshaller.parseInput(line);
            System.out.println("enter command... ");
        }
    }
}

package input;

import commands.stub.CommandStub;
import engine.CommandStubObserver;
import engine.intializer.EngineInitializer;
import input.marshaller.DefaultInputMarshaler;
import input.marshaller.InputMarshaler;
import org.apache.log4j.BasicConfigurator;
import rx.subjects.BehaviorSubject;

/**
 * Created by jakub on 1/16/17.
 */
public class Test {
    public static void main(String[] args) {
        BasicConfigurator.configure();
        new EngineInitializer().initialize();
        new CommandLineInput(getInitializedMarshaller())
                .startCommandLine();
    }

    private static InputMarshaler getInitializedMarshaller() {
        InputMarshaler inputMarshaller = new DefaultInputMarshaler();
        inputMarshaller.subscribeInput(new CommandStubObserver());
        return inputMarshaller;
    }
}

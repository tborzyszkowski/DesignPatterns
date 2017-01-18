package input;

import engine.intializer.EngineInitializer;
import lombok.extern.log4j.Log4j;
import org.apache.log4j.BasicConfigurator;

/**
 * Created by jakub on 1/16/17.
 */
public class Test {
    public static void main(String[] args) {
        BasicConfigurator.configure();
        new EngineInitializer().initialize();
        new CommandLineInput().startCommandLine();

    }


}

package engine.commands.factory.conrete;

import engine.commands.ActionCommand;
import engine.commands.ExitCommand;
import engine.commands.factory.CommandFactory;
import engine.commands.stub.CommandStub;

/**
 * Created by jakub on 1/18/17.
 */
public class ExitCommandFactory implements CommandFactory {

    @Override
    public ActionCommand createCommand(CommandStub commandStub) throws Exception {
        return new ExitCommand();
    }
}

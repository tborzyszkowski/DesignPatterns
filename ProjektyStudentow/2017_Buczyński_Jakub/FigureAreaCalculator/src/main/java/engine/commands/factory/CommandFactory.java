package engine.commands.factory;

import engine.commands.ActionCommand;
import engine.commands.stub.CommandStub;

/**
 * Created by jakub on 1/18/17.
 */
public interface CommandFactory {
    ActionCommand createCommand(CommandStub commandStub) throws Exception;
}

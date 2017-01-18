package engine.commands.factory.conrete;

import engine.commands.ActionCommand;
import engine.commands.ShowAllCommand;
import engine.commands.factory.CommandFactory;
import engine.commands.stub.CommandStub;

/**
 * Created by jakub on 1/18/17.
 */
public class ShowAllCommandFactory implements CommandFactory {

    @Override
    public ActionCommand createCommand(CommandStub commandStub) throws Exception {
        {
            return new ShowAllCommand();
        }
    }
}
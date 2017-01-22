package commands.factory.conrete;

import commands.ActionCommand;
import commands.ExitCommand;
import commands.factory.CommandFactory;

import java.util.List;

/**
 * Created by jakub on 1/18/17.
 */
public class ExitCommandFactory implements CommandFactory {

    @Override
    public ActionCommand createCommand(List<String> params) throws Exception {
        return new ExitCommand();
    }
}

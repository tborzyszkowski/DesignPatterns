package commands.factory.conrete;

import commands.ActionCommand;
import commands.HelpCommand;
import commands.factory.CommandFactory;

import java.util.List;

/**
 * Created by jakub on 1/22/17.
 */
public class HelpCommandFactory implements CommandFactory {
    @Override
    public ActionCommand createCommand(List<String> parameters) throws Exception {
        return new HelpCommand();
    }
}

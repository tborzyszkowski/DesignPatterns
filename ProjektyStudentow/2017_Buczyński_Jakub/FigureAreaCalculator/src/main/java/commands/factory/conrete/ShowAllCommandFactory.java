package commands.factory.conrete;

import commands.ActionCommand;
import commands.ShowAllCommand;
import commands.factory.CommandFactory;

import java.util.List;

/**
 * Created by jakub on 1/18/17.
 */
public class ShowAllCommandFactory implements CommandFactory {

    @Override
    public ActionCommand createCommand(List<String> params) throws Exception {
        {
            if (params.size() <= 0) {
                return new ShowAllCommand();
            } else {
                String decoration = params.get(0);
                return new ShowAllCommand(decoration);
            }
        }
    }
}
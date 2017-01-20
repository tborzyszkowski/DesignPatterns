package commands.factory;

import commands.ActionCommand;

import java.util.List;

/**
 * Created by jakub on 1/18/17.
 */
public interface CommandFactory {
    ActionCommand createCommand(List<String> parameters) throws Exception;
}

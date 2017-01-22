package commands.factory;

import commands.ActionCommand;
import commands.stub.CommandStub;
import lombok.extern.log4j.Log4j;

import java.util.HashMap;
import java.util.Map;
import java.util.Optional;

/**
 * Created by jakub on 1/18/17.
 */
@Log4j
public enum CommandRegistry {
    INSTANCE;

    private Map<String, CommandFactory> commands = new HashMap<>();

    public void registerCommand(String command, CommandFactory factory) {
        commands.put(command, factory);
    }

    public Optional<ActionCommand> createCommand(CommandStub commandStub) throws Exception {
        if (!Optional.ofNullable(commandStub).isPresent()) {
            return Optional.empty();
        }
        Optional<CommandFactory> commandFactory = Optional.ofNullable(commands.get(commandStub.getCommandName()));
        if(commandFactory.isPresent()) {
            return Optional.ofNullable(commandFactory.get().createCommand(commandStub.getCommandParams()));
        }
        return Optional.empty();
    }
}

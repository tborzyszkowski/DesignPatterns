package engine;

import commands.ActionCommand;
import commands.factory.CommandRegistry;
import commands.stub.CommandStub;
import lombok.extern.log4j.Log4j;
import rx.Observer;

import java.util.Optional;

/**
 * Created by jakub on 1/17/17.
 */
@Log4j
public class CommandStubObserver implements Observer<CommandStub> {
    public void onCompleted() {
        log.warn("area command observer completed");
    }

    @Override
    public void onError(Throwable throwable) {
        log.error("area command observer error");
    }

    @Override
    public void onNext(CommandStub commandStub) {
        doOnNex(commandStub);
    }

    private void doOnNex(CommandStub commandStub) {
        if (commandStub.getCommandName() == null) {
            log.info("please enter valid command");
        }
        try {
            Optional<ActionCommand> command = CommandRegistry.INSTANCE.createCommand(commandStub);

            if (command.isPresent()) {
                CommandRegistry.INSTANCE.createCommand(commandStub);
                command.get().execute();
            } else {
                log.error("unknown command");
            }
            return;
        } catch (Exception e) {
            log.error("failure while creating command: " + e.getMessage());
        }
    }
}
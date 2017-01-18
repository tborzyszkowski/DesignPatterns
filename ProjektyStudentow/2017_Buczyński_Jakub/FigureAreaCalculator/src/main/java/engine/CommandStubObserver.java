package engine;

import engine.commands.ActionCommand;
import engine.commands.factory.CommandRegistry;
import engine.commands.stub.CommandStub;
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
        log.info(commandStub);
        doOnNex(commandStub);
    }

    private void doOnNex(CommandStub commandStub) {
        try {
            Optional<ActionCommand> command = CommandRegistry.INSTANCE.createCommand(commandStub);

            if (command.isPresent()) {
                CommandRegistry.INSTANCE.createCommand(commandStub);
                command.get().execute();
            }
            return;
        } catch (Exception e) {
            log.error("failure while creating command " + e);
        }
        log.error("failure while creating command");
    }
}
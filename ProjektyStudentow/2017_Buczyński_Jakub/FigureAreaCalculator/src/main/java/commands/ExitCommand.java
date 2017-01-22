package commands;

import lombok.extern.log4j.Log4j;

/**
 * Created by jakub on 1/18/17.
 */
@Log4j
public class ExitCommand extends ActionCommand {

    @Override
    public void execute() {
        log.info("shutting down...");
        try {
            Thread.sleep(1000);
        } catch (InterruptedException e) {
            log.error(e.getMessage());
        }
        System.exit(0);
    }

}

package engine.commands;

import engine.registry.Registry;
import lombok.Builder;

import java.util.LinkedList;
import java.util.List;

/**
 * Created by jakub on 1/18/17.
 */

public class ShowAllCommand extends ActionCommand {

    @Override
    public void execute() {
        Registry.INSTANCE.printRegistry();
    }
}

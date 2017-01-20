package commands.stub;

import lombok.Builder;
import lombok.Getter;

import java.util.List;

/**
 * Created by jakub on 1/18/17.
 */
@Builder
@Getter
public class CommandStub {
    private String commandName;
    List<String> commandParams;
}

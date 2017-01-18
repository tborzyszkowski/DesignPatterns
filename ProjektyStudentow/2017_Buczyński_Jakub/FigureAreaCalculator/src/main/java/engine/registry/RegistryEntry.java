package engine.registry;

import engine.AreaResult;
import lombok.Builder;
import lombok.Getter;

import java.util.Date;

/**
 * Created by jakub on 1/18/17.
 */
@Builder
@Getter
public class RegistryEntry {
    private Date date;
    private AreaResult result;
}

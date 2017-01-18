package engine.registry;

import engine.AreaResult;
import lombok.extern.log4j.Log4j;

import java.util.Date;
import java.util.LinkedList;
import java.util.List;

/**
 * Created by jakub on 1/18/17.
 */
@Log4j
public enum Registry {
    INSTANCE;

    private List<RegistryEntry> registryEntries = new LinkedList<>();

    public void addRegistryEntry(AreaResult result) {
        RegistryEntry entry = RegistryEntry.builder()
                .date(new Date())
                .result(result)
                .build();
        registryEntries.add(entry);
        log.info("dodano do rejestru " + result);
    }

    public void printRegistry() {
        log.info("");
        log.info("ZAWARTOSĆ REJESTRU: ");
        registryEntries.forEach(entry -> log.info(entry));
        log.info("");
    }
}

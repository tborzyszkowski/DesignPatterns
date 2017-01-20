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
        log.debug("entry added to registry");
    }

    public RegistryPrinter getRegistryPrinter() {
        List<String> lines = new LinkedList<>();
        lines.add("ZAWARTOSĆ REJESTRU: ");
        registryEntries.forEach(entry -> lines.add(entry.toString()));
        return new DefaultRegistryPrinter(lines);
    }
}

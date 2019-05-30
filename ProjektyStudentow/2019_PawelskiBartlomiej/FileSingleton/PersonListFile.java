package FileSingleton;

import java.io.FileNotFoundException;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;

public enum PersonListFile implements iFileSingleton {
    INSTANCE;
    public String text;


    @Override
    public void fileToString(String filename) throws Exception {
        try {
            text = new String(Files.readAllBytes(Paths.get(filename)), StandardCharsets.UTF_8);
        } catch (FileNotFoundException e) {
            e.printStackTrace();
        }
    }
}

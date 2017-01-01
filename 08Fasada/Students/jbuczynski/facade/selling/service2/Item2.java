package facade.selling.service2;

import java.util.UUID;

/**
 * Created by jakub on 1/1/17.
 */
public class Item2 {
    private String name = UUID.randomUUID().toString();

    public Item2() {
    }

    public Item2(String name) {
        this.name = name;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }
}

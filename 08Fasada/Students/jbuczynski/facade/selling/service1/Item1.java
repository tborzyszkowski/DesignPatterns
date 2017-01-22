package facade.selling.service1;

import java.util.UUID;

/**
 * Created by jakub on 1/1/17.
 */
public class Item1 {
    private String name = UUID.randomUUID().toString();

    public Item1() {
    }

    public Item1(String name) {
        this.name = name;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }
}

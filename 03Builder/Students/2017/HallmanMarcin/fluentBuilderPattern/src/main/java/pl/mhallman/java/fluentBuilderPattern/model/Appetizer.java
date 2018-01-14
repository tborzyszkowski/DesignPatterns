package pl.mhallman.java.fluentBuilderPattern.model;

import lombok.AllArgsConstructor;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;

@Getter
@Setter
public class Appetizer {

    private String name;
    private int quantity;

    public Appetizer(String name, int quantity) {
        this.name = name;
        this.quantity = quantity;
    }

    @Override
    public String toString() {
        return "Appetizer{" +
                "name='" + name + '\'' +
                ", quantity=" + quantity +
                '}';
    }
}

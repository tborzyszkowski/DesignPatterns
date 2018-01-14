package pl.mhallman.java.fluentBuilderPattern.model;

import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;

@Getter
@Setter
@NoArgsConstructor
public class Dessert {

    private String name;
    private int quantity;

    public Dessert(String name, int quantity) {
        this.name = name;
        this.quantity = quantity;
    }

    @Override
    public String toString() {
        return "Dessert{" +
                "name='" + name + '\'' +
                ", quantity=" + quantity +
                '}';
    }
}

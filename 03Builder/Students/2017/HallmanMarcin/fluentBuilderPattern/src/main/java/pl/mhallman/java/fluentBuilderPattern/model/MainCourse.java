package pl.mhallman.java.fluentBuilderPattern.model;

import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;

@Getter
@Setter
@NoArgsConstructor
public class MainCourse {

    private String name;
    private int quantity;

    public MainCourse(String name, int quantity) {
        this.name = name;
        this.quantity = quantity;
    }

    @Override
    public String toString() {
        return "MainCourse{" +
                "name='" + name + '\'' +
                ", quantity=" + quantity +
                '}';
    }
}

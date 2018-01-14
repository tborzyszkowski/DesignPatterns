package pl.mhallman.java.builderPattern.model;

import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;

@Setter
@Getter
@NoArgsConstructor
public class Meal {

    private String appetizer;

    private String mainCourse;

    private String dessert;

    @Override
    public String toString() {
        return "Meal{" +
                "appetizer='" + appetizer + '\'' +
                ", mainCourse='" + mainCourse + '\'' +
                ", dessert='" + dessert + '\'' +
                '}';
    }
}

package pl.mhallman.java.fluentBuilderPattern.model;

import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;

@Setter
@Getter
@NoArgsConstructor
public class Meal {

    private String mealName;

    private Appetizer appetizer;

    private MainCourse mainCourse;

    private Dessert dessert;

    private double price;

    private Meal(final Builder builder) {
        this.mealName = builder.mealName;
        this.appetizer = builder.appetizer;
        this.mainCourse = builder.mainCourse;
        this.dessert = builder.dessert;
        this.price = builder.price;
    }

    @Override
    public String toString() {
        return "Meal{" +
                "mealName='" + mealName + '\'' +
                ", appetizer=" + appetizer +
                ", mainCourse=" + mainCourse +
                ", dessert=" + dessert +
                ", price=" + price +
                '}';
    }

    public static class Builder {

        private final String mealName;
        private Appetizer appetizer;
        private MainCourse mainCourse;
        private Dessert dessert;
        private double price;

        public Builder(final String mealName)
        {
            this.mealName = mealName;
        }

        public Builder appetizer(final String appetizerName, final int quantity)
        {
            this.appetizer = new Appetizer(appetizerName,quantity);
            return this;
        }

        public Builder mainCourse(final String appetizerName, final int quantity)
        {
            this.mainCourse = new MainCourse(appetizerName,quantity);
            return this;
        }

        public Builder dessert(final String appetizerName, final int quantity)
        {
            this.dessert = new Dessert(appetizerName,quantity);
            return this;
        }

        public Builder price(final double price)
        {
            this.price = price;
            return this;
        }

        public Meal build() {
            return new Meal(this);
        }
    }
}

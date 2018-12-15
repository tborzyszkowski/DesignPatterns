package simplePrototype;

import java.util.ArrayList;
import java.util.List;

public class PizzaOrder implements Cloneable{

    public List<String> availablePizzas;

    public PizzaOrder(List availablePizzas) {
        this.availablePizzas = availablePizzas;
    }

    public PizzaOrder clone() {
        List tempList = new ArrayList();

        for (String item : availablePizzas) {
            tempList.add(item);
        }

        return new PizzaOrder(tempList);
    }


}

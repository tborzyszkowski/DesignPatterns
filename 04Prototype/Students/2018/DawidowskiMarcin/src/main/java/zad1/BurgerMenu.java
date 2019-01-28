package zad1;

import java.util.ArrayList;
import java.util.List;

public class BurgerMenu implements Cloneable{

    public List<String> burgers;

    public BurgerMenu(List burgers) {
        this.burgers = burgers;
    }

    public BurgerMenu clone() {
        List clonedList = new ArrayList();

        for (String item : burgers) {
            clonedList.add(item);
        }
        return new BurgerMenu(clonedList);
    }
}

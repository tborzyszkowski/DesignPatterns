package zad1;

import java.util.ArrayList;
import java.util.List;

public class OrderManager {
    public BurgerMenu prepareOrder() {
        List burgers = new ArrayList();
        burgers.add("Chicken Burger");
        burgers.add("Cheese Burger");
        burgers.add("Fish Burger");
        burgers.add("Veggie Burger");
        return new BurgerMenu(burgers);
    }
}

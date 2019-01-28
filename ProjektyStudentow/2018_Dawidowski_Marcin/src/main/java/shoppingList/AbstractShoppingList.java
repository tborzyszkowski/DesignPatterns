package shoppingList;

import java.util.ArrayList;
import java.util.stream.Stream;

public abstract class AbstractShoppingList extends ArrayList<AbstractShoppingList> {
    protected String description;

    public String getDescription(){
        return description;
    }

    public abstract double price();

    @Override
    public String toString(){
        return getDescription() + " - " + price();
    }

    @Override
    public Stream<AbstractShoppingList> stream() {
        return null;
    }
}

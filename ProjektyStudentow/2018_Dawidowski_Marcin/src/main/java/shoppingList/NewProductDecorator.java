package shoppingList;

import tools.Tool;

import java.util.ArrayList;

public class NewProductDecorator extends AbstractShoppingListDecorator{
    private Tool tool;

    public NewProductDecorator(AbstractShoppingList shoppingList, Tool tool) {
        super(shoppingList);
        this.tool = tool;
    }

    @Override
    public String getDescription() {
        return shoppingList.getDescription() + this.tool.brand + ", ";
    }

    @Override
    public double price() {
        return shoppingList.price() + this.tool.price;
    }
}

package shoppingList;

abstract class AbstractShoppingListDecorator extends AbstractShoppingList {
    protected AbstractShoppingList shoppingList;

    public AbstractShoppingListDecorator(AbstractShoppingList shoppingList){
        this.shoppingList = shoppingList;
    }

    @Override
    public abstract String getDescription();
}

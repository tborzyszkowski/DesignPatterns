package shoppingList;

import java.math.BigDecimal;
import java.math.MathContext;
import java.math.RoundingMode;

public class DiscountDecorator extends AbstractShoppingListDecorator {
    private final int rebatePercent;

    public DiscountDecorator(AbstractShoppingList shoppingList, int rebatePercent){
        super(shoppingList);
        this.rebatePercent = rebatePercent;
    }

    @Override
    public String getDescription() {
        return shoppingList.getDescription() + " po rabacie";
    }

    @Override
    public double price(){
        BigDecimal price = BigDecimal.valueOf(shoppingList.price()).setScale(2);
        BigDecimal discount = BigDecimal.valueOf(rebatePercent / 100.0).setScale(2);
        discount = discount.multiply(price);
        price = price.subtract(discount).round(new MathContext(3, RoundingMode.HALF_UP)).setScale(2);

        return price.doubleValue();
    }
}

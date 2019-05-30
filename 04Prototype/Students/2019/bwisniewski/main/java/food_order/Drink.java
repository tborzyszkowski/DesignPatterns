package food_order;

public class Drink implements Cloneable{
    private String drinkType;

    public Drink(String drinkType) {
        this.drinkType = drinkType;
    }

    public String getDrinkType() {
        return drinkType;
    }

    public void setDrinkType(String drinkType) {
        this.drinkType = drinkType;
    }

    @Override
    public Object clone() throws CloneNotSupportedException{
    	Drink copyDrink = (Drink) super.clone();
        return copyDrink;
    }
}

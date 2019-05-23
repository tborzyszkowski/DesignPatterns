package food_order;

public class MainDish implements Cloneable{
	private String mainDish;
	private Drink drink;

	public MainDish(String mainDish, Drink drink) {
		this.mainDish = mainDish;
		this.drink = drink;
	}

	public String getMainDish() {
		return mainDish;
	}

	public void setMainDish(String mainDish) {
		this.mainDish = mainDish;
	}

	public Drink getDrink() {
		return drink;
	}

	public void setDrink(Drink drink) {
		this.drink = drink;
	}
	@Override
    public Object clone() throws CloneNotSupportedException{
		MainDish copyMainDish = (MainDish) super.clone();
        copyMainDish.drink = (Drink) drink.clone();
        return copyMainDish;
}
	
}

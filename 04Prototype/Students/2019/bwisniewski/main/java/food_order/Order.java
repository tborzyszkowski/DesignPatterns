package food_order;

public class Order implements Cloneable {
	private Extra extra;
	private MainDish mainDish;
	private String price;

	public Order(Extra extra, MainDish mainDish, String price) {
		this.extra = extra;
		this.mainDish = mainDish;
		this.price = price;
	}

	public Extra getExtra() {
		return extra;
	}

	public void setExtra(Extra extra) {
		this.extra = extra;
	}

	public MainDish getMainDish() {
		return mainDish;
	}

	public void setMainDish(MainDish mainDish) {
		this.mainDish = mainDish;
	}

	public String getPrice() {
		return price;
	}

	public void setPrice(String price) {
		this.price = price;
	}

	@Override
	public Object clone() throws CloneNotSupportedException {
		Order copyOrder = (Order) super.clone();
		copyOrder.extra = (Extra) extra.clone();
		copyOrder.mainDish = (MainDish) mainDish.clone();
		return copyOrder;
	}

	public Object shallowCopy() throws CloneNotSupportedException {
		Order copyOrder = (Order) super.clone();
		return copyOrder;
	}

}

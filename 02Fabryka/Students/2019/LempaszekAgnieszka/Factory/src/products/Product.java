package products;

public abstract class Product {
	
	protected Size size;
	protected Taste taste;
	protected int price;
	protected String name;

	public abstract void make();
	public abstract void taste();
	
	public int getPrice() {
		return price;
	}
	
	public Size getSize() {
		return size;
	}

	public String toString() {
		return "Size: " + size + ", Price: " + price + ", Taste: " +  taste;
	}
	
}

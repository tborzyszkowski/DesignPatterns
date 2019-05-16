package products;

public abstract class Coffee extends Product {
	
	public void addMilk() {
		System.out.println("Addig milk to " + name);
	}
	
	public void drink() {
		System.out.println("Drinking coffee " + name);
	}

	
	@Override 
	public void make() {
		System.out.println("Making Coffee: " + this);
	}
	
	@Override
	public void taste() {
		System.out.println("Tasting Coffee " + name);
	}
}

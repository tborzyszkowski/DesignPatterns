package products;

public abstract class Cake extends Product {
	
	public void addGlaze() {
		System.out.println("Adding glaze to " + name);
	}
	
	public void eat() {
		System.out.println("Eating Cake " + name);
	}

	
	@Override 
	public void make() {
		System.out.println("Making Cake: " + this);
	}
	
	@Override
	public void taste() {
		System.out.println("Tasting Cake " + name);
	}
	
}

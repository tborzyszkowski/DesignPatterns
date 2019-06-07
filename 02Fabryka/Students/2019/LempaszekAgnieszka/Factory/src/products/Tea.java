package products;

public abstract class Tea extends Product {
	
	public void addLemon() {
		System.out.println("Adding lemon to " + name);
	}
	
	public void drink() {
		System.out.println("Drinking Tea " + name);
	}

	
	@Override 
	public void make() {
		System.out.println("Making Tea: " + this);
	}
	
	@Override
	public void taste() {
		System.out.println("Tasting Tea " + name);
	}
}

package factoryClassRegistrationReflection;

public class SndProduct extends Product {
	static {
		// TU: powinien byæ Singleton pf !!!!
		ProductFactory pf = new ProductFactory();
				
		pf.registerProduct("ID2",SndProduct.class);
	}
}

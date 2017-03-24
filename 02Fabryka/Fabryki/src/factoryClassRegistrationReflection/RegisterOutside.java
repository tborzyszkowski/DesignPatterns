package factoryClassRegistrationReflection;

public class RegisterOutside {

	public static void main(String[] args) {
		// TU: powinien byæ Singleton pf !!!!
		ProductFactory pf = new ProductFactory();

		pf.registerProduct("ID1", OneProduct.class);
	}

}

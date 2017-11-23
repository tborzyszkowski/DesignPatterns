package factoryMethod;

public class KawiarniaStarbucks extends Kawiarnia {

	Kawa przygotujKawa(String type) {
		if ("esp".equalsIgnoreCase(type)) {
			return new StarbucksEspresso();
		} else if ("cap".equalsIgnoreCase(type)) {				
			return new StarbucksCappuccino();
		} else if ("lat".equalsIgnoreCase(type)) {
			return new StarbucksLatte();
		} else return null;
	}
}

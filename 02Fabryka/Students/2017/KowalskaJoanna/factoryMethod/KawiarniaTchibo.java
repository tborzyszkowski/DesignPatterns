package factoryMethod;

public class KawiarniaTchibo extends Kawiarnia {
		
	Kawa przygotujKawa(String type) {
		if ("esp".equalsIgnoreCase(type)) {
			return new TchiboEspresso();
		} else if ("cap".equalsIgnoreCase(type)) {				
			return new TchiboCappuccino();
		} else if ("lat".equalsIgnoreCase(type)) {
			return new TchiboLatte();
		} else return null;
	}
}

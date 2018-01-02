package factorySimple;

public class KawaFactory {
	
	public KawaFactory() { }
	
	Kawa przygotujKawa(String type) {
		
		Kawa kawa = null;
		
		if("esp".equalsIgnoreCase(type)) {
			kawa = new Espresso();
			System.out.println("\n"+"Tworzymy Espresso");
		} else if("cap".equalsIgnoreCase(type)) {
			kawa = new Cappuccino();
			System.out.println("\n"+"Tworzymy Cappuccino");
		} else if("lat".equalsIgnoreCase(type)) {
			kawa = new Latte();
			System.out.println("\n"+"Tworzymy Latte");
		}
		return kawa;
	}
}

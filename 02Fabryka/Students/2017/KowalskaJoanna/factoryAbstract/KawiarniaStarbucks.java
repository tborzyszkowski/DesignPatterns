package factoryAbstract;

public class KawiarniaStarbucks extends Kawiarnia {

	@Override
	protected Kawa przygotujKawa(String type) {
		Kawa kawa = null;
		KawiarniaFactory factory = new KawiarniaStarbucksFactory();
		
		if ("esp".equalsIgnoreCase(type)) {			  
			kawa = new Espresso(factory);
			System.out.println("Kawa Espresso w stylu Starbucks:");
		} else if ("cap".equalsIgnoreCase(type)) { 
			kawa = new Cappuccino(factory);
			System.out.println("Kawa Cappuccino w stylu Starbucks:");
		} else if ("lat".equalsIgnoreCase(type)) { 
			kawa = new Latte(factory);
			System.out.println("Kawa Latte w stylu Starbucks:");
		} 			
		return kawa;
	}
}

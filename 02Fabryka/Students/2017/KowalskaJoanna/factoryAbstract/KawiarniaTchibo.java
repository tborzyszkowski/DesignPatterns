package factoryAbstract;

public class KawiarniaTchibo extends Kawiarnia {
		
	@Override
	protected Kawa przygotujKawa(String type) {
		Kawa kawa = null;
		KawiarniaFactory factory = new KawiarniaTchiboFactory();
		
		if ("esp".equalsIgnoreCase(type)) {			  
			kawa = new Espresso(factory);
			System.out.println("Kawa Espresso w stylu Tchibo:");  
		} else if ("cap".equalsIgnoreCase(type)) { 
			kawa = new Cappuccino(factory);
			System.out.println("Kawa Cappuccino w stylu Tchibo:"); 
		} else if ("lat".equalsIgnoreCase(type)) { 
			kawa = new Latte(factory);
			System.out.println("Kawa Latte w stylu Tchibo:"); 
		} 				
		return kawa;
	}
}

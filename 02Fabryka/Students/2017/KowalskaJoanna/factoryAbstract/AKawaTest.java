package factoryAbstract;

public class AKawaTest {
	
	public static void main(String[] args) {
		
		Kawiarnia tchibo = new KawiarniaTchibo();	
		Kawiarnia starbucks = new KawiarniaStarbucks();	
		
		Kawa kawa = starbucks.zamowKawa("esp");
		System.out.println("Składniki specjalne kawy Espresso Starbucks: ");
		System.out.println(kawa);
		
		kawa = starbucks.zamowKawa("cap");
		System.out.println("Składniki specjalne kawy Cappuccino Starbucks: ");
		System.out.println(kawa);
		
		kawa = starbucks.zamowKawa("lat");
		System.out.println("Składniki specjalne kawy Latte Starbucks: ");
		System.out.println(kawa);
		
		kawa = tchibo.zamowKawa("esp");
		System.out.println("Składniki specjalne kawy Espresso Tchibo: ");
		System.out.println(kawa);
		
		kawa = tchibo.zamowKawa("cap");
		System.out.println("Składniki specjalne kawy Cappuccino Tchibo: ");
		System.out.println(kawa);
		
		kawa = tchibo.zamowKawa("lat");
		System.out.println("Składniki specjalne kawy Latte Tchibo: ");
		System.out.println(kawa);
	}
}
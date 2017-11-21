package singletonEager;
//eager initialization

public class SingletonEagerTest {
	public static void main(String[] args) {

		System.out.println("Tworzymy instancję.");
		SingletonEager object1 = SingletonEager.pobierzInstancje();
		System.out.println("Próbujemy stworzyć kolejną instancję.");
		SingletonEager object2 = SingletonEager.pobierzInstancje();
		
		if (object1 == object2) {
			System.out.println("object1 i object2 to ta sama instancja!");
		}
		
		System.out.println(object1.hashCode());
		System.out.println(object2.hashCode());
	}
}

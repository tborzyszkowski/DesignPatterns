package singletonLazy;
//lazy initialization

public class SingletonLazyTest {
	public static void main(String[] args) {

		System.out.println("Tworzymy instancję.");
		SingletonLazy object1 = SingletonLazy.pobierzInstancje();
		System.out.println("Próbujemy stworzyć kolejną instancję.");
		SingletonLazy object2 = SingletonLazy.pobierzInstancje();
		
		if (object1 == object2) {
			System.out.println("object1 i object2 to ta sama instancja!");
		} else {
			System.out.println("object1 i object2 to inne instancje!");
		}
		
		System.out.println(object1.hashCode());
		System.out.println(object2.hashCode());
	}
}

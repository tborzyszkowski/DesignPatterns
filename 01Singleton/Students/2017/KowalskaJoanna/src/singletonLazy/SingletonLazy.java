package singletonLazy;
//lazy initialization

public class SingletonLazy {

	private static SingletonLazy instancja;
			
	private SingletonLazy() { } 
	
	public static SingletonLazy pobierzInstancje() {
		
		if (instancja == null) {
			instancja = new SingletonLazy(); 
			System.out.println("Instancja utworzona.");
		} else {
			System.out.println("Już istnieje instancja!");
		}
		
		//instancja = new SingletonLazy(); 
		return instancja;		
	}
}

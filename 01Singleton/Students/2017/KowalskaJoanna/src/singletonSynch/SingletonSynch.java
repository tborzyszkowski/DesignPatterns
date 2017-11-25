package singletonSynch;
//synchronized/multithreaded

public class SingletonSynch {
		
	private static SingletonSynch instancja;
	
	private SingletonSynch() { } 
	
	public static synchronized SingletonSynch pobierzInstancje() {					
		if (instancja == null) {
			instancja = new SingletonSynch(); 
			System.out.println("Instancja utworzona.");
		} else {
			System.out.println("Już istnieje instancja!");
		}		
		return instancja;		
	}
}

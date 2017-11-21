package singletonDouble;
//double checked locking

public class SingletonDouble {
		
	private static SingletonDouble instancja;
	
	private SingletonDouble() { } 
	
	public static SingletonDouble pobierzInstancje() {					
		if (instancja == null) {
			synchronized(SingletonDouble.class) {
				if(instancja == null) {
					instancja = new SingletonDouble();
					System.out.println("Instancja utworzona.");
				}
			}			
		} else {
			System.out.println("Już istnieje instancja!");
		}		
		return instancja;		
	}
}

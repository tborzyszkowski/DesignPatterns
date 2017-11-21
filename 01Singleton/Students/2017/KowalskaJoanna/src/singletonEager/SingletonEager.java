package singletonEager;
//eager initialization

public class SingletonEager {

	private static SingletonEager instancja = new SingletonEager();
			
	private SingletonEager() {
		System.out.println("Instancja utworzona");
	} 
	
	public static SingletonEager pobierzInstancje() {
		return instancja;		
	}
}

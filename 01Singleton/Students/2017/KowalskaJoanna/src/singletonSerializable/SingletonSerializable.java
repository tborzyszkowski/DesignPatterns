package singletonSerializable;
//Serializable

import java.io.Serializable;

public class SingletonSerializable implements Serializable {

	/**
	 * 
	 */
	private static final long serialVersionUID = 9209682094854104478L;
	
	private static SingletonSerializable instancja = new SingletonSerializable();
	
	private SingletonSerializable() {
		System.out.println("Tworzę instancję.");
	} 
	
	public static SingletonSerializable pobierzInstancje() {
		return instancja;		
	}
	
	private Object readResolve() {
		System.out.println("Korzystam z readResolve():");
		return instancja;
	}
}

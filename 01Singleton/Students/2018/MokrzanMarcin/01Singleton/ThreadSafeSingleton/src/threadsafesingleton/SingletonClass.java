/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package threadsafesingleton;

/**
 *
 * @author Marcin
 */
public class SingletonClass {
    private static volatile SingletonClass instance;
	private static Object mutex = new Object();

	private SingletonClass() {
	}

	public static SingletonClass getInstance() {
		SingletonClass result = instance;
		if (result == null) {
			synchronized (mutex) {
				result = instance;
				if (result == null)
					instance = result = new SingletonClass();
			}
		}
		return result;
	}
}

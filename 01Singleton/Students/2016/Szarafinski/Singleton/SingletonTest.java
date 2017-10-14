/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Singleton;

/**
 *
 * @author KrzysieK
 */
public class SingletonTest {

    private static SingletonTest singleton = null;
    private static int id = 1;

    private SingletonTest() {};
    
    
    public static SingletonTest instancja(String watekID) {
        if (singleton == null) {
            System.out.println("Singleton Test zainicjowany po raz " + id++ + " przez wątek " + watekID);
            singleton = new SingletonTest();
        }
        
        return singleton;
    }
}

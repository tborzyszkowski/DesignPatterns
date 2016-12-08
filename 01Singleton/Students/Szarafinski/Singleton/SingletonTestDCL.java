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
public class SingletonTestDCL {
    private volatile static SingletonTestDCL singleton = null;
    private static int id = 1;
    private SingletonTestDCL() {};

    public static SingletonTestDCL instancja(String watekID) {
        if (singleton == null) {
            synchronized (Singleton.class) {
                if (singleton == null) {
                    System.out.println("Singleton DCL zainicjowany po raz " + id++ + " przez wątek " + watekID);
                    singleton = new SingletonTestDCL();
                }
            }
        }
        return singleton;
    }
}

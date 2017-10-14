/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Singleton;

import java.io.Serializable;

/**
 *
 * @author KrzysieK
 */
public class SingletonDoubleCheckLocking implements Serializable{

    private volatile static SingletonDoubleCheckLocking singleton = null;
    private static int id = 1;
    private SingletonDoubleCheckLocking() {};

    public static SingletonDoubleCheckLocking instancja() {
        if (singleton == null) {
            synchronized (Singleton.class) {
                if (singleton == null) {
                    System.out.println("Singleton DCL zainicjowany po raz " + id++);
                    singleton = new SingletonDoubleCheckLocking();
                }
            }
        }
        return singleton;
    }
}

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
public class Singleton  implements Serializable {

    private static Singleton singleton = null;
    private static int id = 1;
    private Singleton() {};
    
    
    public static Singleton instancja() {
        if (singleton == null) {
            System.out.println("Singleton zainicjowany po raz " + id++);
            singleton = new Singleton();
        }
         id++;
        return singleton;
    }
}

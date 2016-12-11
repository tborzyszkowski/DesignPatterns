/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package SingletonDziedziczenie;

/**
 *
 * @author KrzysieK
 */
public class Singleton {
    private String name = "obiekt MATKA";

    protected Singleton() {};
    private static Singleton obiekt = null;

    public synchronized static Singleton getInstance() {
        if (obiekt == null){
             obiekt = new Singleton(); 
             System.out.println("Obiekt singleton MATKA został zainicjowany");
        }
        return obiekt;
    }

    public String getName() {
        return name;
    }

    
   
}

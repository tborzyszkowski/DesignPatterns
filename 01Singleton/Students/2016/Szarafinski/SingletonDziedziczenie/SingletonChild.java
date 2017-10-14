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
public class SingletonChild extends Singleton {
    private SingletonChild(){};
    private static SingletonChild obiekt = null;
    private String name = "obiekt DZIECKO";
    
    public synchronized static SingletonChild getInstance(){
        if (obiekt == null){
             obiekt = new SingletonChild(); 
             System.out.println("Obiekt singleton DZIECKO został zainicjowany");
        }
        return obiekt;
    }

    @Override
    public String getName() {
        return name;
    }
    
    
}

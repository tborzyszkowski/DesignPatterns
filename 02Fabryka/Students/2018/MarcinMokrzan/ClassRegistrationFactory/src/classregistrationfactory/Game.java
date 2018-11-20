/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package classregistrationfactory;

/**
 *
 * @author Marcin
 */
public abstract class Game {
    public String productName;
    public String type;
    public String time;
    public String players;
    public String age;
    
    public String getProductName() {
        return productName;
    }

    public String getType() {
        return type;
    }

    public String getTime() {
        return time;
    }

    public String getPlayers() {
        return players;
    }

    public String getAge() {
        return age;
    }

    @Override
    public String toString() {
        return "Game:" + "\n" 
                + "productName = " + productName + "\n"  
                + "type = " + type + "\n" 
                + "time = " + time + "\n" 
                + "players = " + players + "\n" 
                + "age = " + age;
    }  
}

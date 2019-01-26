/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package factorybetterthenbuilder.builder;

/**
 *
 * @author Marcin
 */
public class Game {
    public String productName;
    public String type;
    public String time;
    public String players;
    public String age;

    public void setProductName(String productName) {
        this.productName = productName;
    }

    public void setType(String type) {
        this.type = type;
    }

    public void setTime(String time) {
        this.time = time;
    }

    public void setPlayers(String players) {
        this.players = players;
    }

    public void setAge(String age) {
        this.age = age;
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

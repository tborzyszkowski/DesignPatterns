/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package simplefactory;

/**
 *
 * @author Marcin
 */
public abstract class Game{
    public abstract String getProductName();
    public abstract String getType();
    public abstract String getTime();
    public abstract String getPlayers();
    public abstract String getAge();
    
    @Override // nadpisuje 
    public String toString(){
        return "Product name: " + this.getProductName() + "\n" +
                "Type: " + this.getType() + "\n" +
                "Time: " + this.getTime() + "\n" +
                "Players: " + this.getPlayers() + "\n" +
                "Age: " + this.getAge() + "\n";
    }
}

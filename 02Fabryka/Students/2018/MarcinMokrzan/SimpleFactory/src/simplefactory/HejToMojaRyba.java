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
public class HejToMojaRyba extends Game {
    
    private String productName;
    private String type;
    private String time;
    private String players;
    private String age;
    
    public HejToMojaRyba(String productName, String type, String time, String players, String age){ 
        this.productName=productName; 
        this.type=type;
        this.time=time;
        this.players=players;
        this.age=age;
    }

    @Override
    public String getProductName() {
        return this.productName;
    }

    @Override
    public String getType() {
        return this.type;
    }

    @Override
    public String getTime() {
        return this.time;
    }

    @Override
    public String getPlayers() {
        return this.players;
    }

    @Override
    public String getAge() {
        return this.age;
    }
    
}

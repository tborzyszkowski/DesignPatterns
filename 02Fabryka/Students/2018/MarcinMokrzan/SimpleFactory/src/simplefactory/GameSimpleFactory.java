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
public class GameSimpleFactory {
    
    public static Game getGame(String productName, String type, String time, String players, String age){
        if("HejToMojaRyba".equals(productName)) 
            return new HejToMojaRyba(productName, type, time, players, age);
        else if("JungleSpeed".equals(productName))
            return new JungleSpeed(productName, type, time, players, age);
        else if("SmallWorld".equals(productName)) 
            return new SmallWorld (productName, type, time, players, age);
        else if("Zlodzieje".equals(productName)) 
            return new Zlodzieje(productName, type, time, players, age);
        else 
            return null;
    }
    
}

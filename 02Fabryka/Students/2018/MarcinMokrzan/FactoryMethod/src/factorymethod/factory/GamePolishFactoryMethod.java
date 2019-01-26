/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package factorymethod.factory;

import factorymethod.game.Game;
import factorymethod.game.polish.GraOTor;
import factorymethod.game.polish.HejToMojaRyba;
import factorymethod.game.polish.Zlodzieje;

/**
 *
 * @author Marcin
 */
public class GamePolishFactoryMethod extends GameFactoryMethod {
    
    Game getGame(String productName){
        Game game=null;
        if("GraOTor".equals(productName)) 
            game = new GraOTor();
        else if("HejToMojaRyba".equals(productName))
            game = new HejToMojaRyba();
        else if("Zlodzieje".equals(productName)) 
            game = new Zlodzieje();
        else 
            return null;
        
        return game;
    }  
}

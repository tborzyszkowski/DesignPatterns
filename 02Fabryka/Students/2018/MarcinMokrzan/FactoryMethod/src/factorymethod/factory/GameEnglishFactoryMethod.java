/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package factorymethod.factory;

import factorymethod.game.Game;
import factorymethod.game.english.JungleSpeed;
import factorymethod.game.english.LordsOfWar;
import factorymethod.game.english.SmallWorld;

/**
 *
 * @author Marcin
 */
public class GameEnglishFactoryMethod extends GameFactoryMethod {
    
    Game getGame(String productName){
        Game game=null;
        if("LordsOfWar".equals(productName)) 
            game = new LordsOfWar();
        else if("JungleSpeed".equals(productName))
            game = new JungleSpeed();
        else if("SmallWorld".equals(productName)) 
            game = new SmallWorld ();
        else 
            return null;
        
        return game;
    }
}

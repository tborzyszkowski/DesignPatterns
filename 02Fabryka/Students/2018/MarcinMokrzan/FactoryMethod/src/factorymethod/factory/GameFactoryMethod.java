/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package factorymethod.factory;

import factorymethod.game.Game;

/**
 *
 * @author Marcin
 */
public abstract class GameFactoryMethod {
    
    abstract Game getGame(String productName); 
    
    public Game orderGame(String productName) {
        Game game = getGame(productName);
        return game;
    }
    
}

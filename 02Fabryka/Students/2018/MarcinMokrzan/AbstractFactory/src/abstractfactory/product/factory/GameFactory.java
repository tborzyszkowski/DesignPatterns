/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package abstractfactory.product.factory;

import abstractfactory.mainAbstractFactory.AbstractFactory;
import abstractfactory.product.Dlc;
import abstractfactory.product.Game;
import abstractfactory.product.games.GraOTor;
import abstractfactory.product.games.HejToMojaRyba;
import abstractfactory.product.games.Zlodzieje;

/**
 *
 * @author Marcin
 */
public class GameFactory extends AbstractFactory {

    @Override
    public Dlc getDlc(String productName) {
        return null;
    }

    @Override
    public Game getGame(String productName) {
        Game game = null;
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

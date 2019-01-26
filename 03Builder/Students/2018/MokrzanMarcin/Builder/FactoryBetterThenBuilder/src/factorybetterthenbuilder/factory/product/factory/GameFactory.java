/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package factorybetterthenbuilder.factory.product.factory;
import factorybetterthenbuilder.factory.abstractFactory.AbstractFactory;
import factorybetterthenbuilder.factory.product.Dlc;
import factorybetterthenbuilder.factory.product.Game;
import factorybetterthenbuilder.factory.product.games.GraOTor;
import factorybetterthenbuilder.factory.product.games.HejToMojaRyba;
import factorybetterthenbuilder.factory.product.games.Zlodzieje;
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

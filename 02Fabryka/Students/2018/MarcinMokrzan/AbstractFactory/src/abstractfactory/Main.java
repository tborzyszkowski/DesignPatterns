/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package abstractfactory;

import abstractfactory.mainAbstractFactory.FactoryProducer;
import abstractfactory.mainAbstractFactory.AbstractFactory;
import abstractfactory.product.Dlc;
import abstractfactory.product.Game;

/**
 *
 * @author Marcin
 */
public class Main {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        
        AbstractFactory gameFactory = FactoryProducer.getFactory("GAME");
        
        Game game1 = gameFactory.getGame("GraOTor");
        Game game2 = gameFactory.getGame("HejToMojaRyba");
        Game game3 = gameFactory.getGame("Zlodzieje");
        
        AbstractFactory dlcFactory = FactoryProducer.getFactory("DLC");
        
        Dlc dlc1 = dlcFactory.getDlc("Cube");
        Dlc dlc2 = dlcFactory.getDlc("Foil");
        Dlc dlc3 = dlcFactory.getDlc("Sticker");
        
        System.out.println(game1.toString());
        System.out.println(game2.toString());
        System.out.println(game3.toString());
        System.out.println(dlc1.toString());
        System.out.println(dlc2.toString());
        System.out.println(dlc3.toString());
    }
    
}

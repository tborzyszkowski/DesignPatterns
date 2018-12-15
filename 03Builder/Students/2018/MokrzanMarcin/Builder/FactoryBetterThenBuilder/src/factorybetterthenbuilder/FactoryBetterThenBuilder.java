/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package factorybetterthenbuilder;

import factorybetterthenbuilder.builder.GameBuilder;
import factorybetterthenbuilder.builder.GraOTor;
import factorybetterthenbuilder.builder.HejToMojaRyba;
import factorybetterthenbuilder.builder.Seller;
import factorybetterthenbuilder.builder.Zlodzieje;
import factorybetterthenbuilder.factory.abstractFactory.FactoryProducer;
import factorybetterthenbuilder.factory.abstractFactory.AbstractFactory;
import factorybetterthenbuilder.factory.product.Dlc;
import factorybetterthenbuilder.factory.product.Game;


/**
 *
 * @author Marcin
 */
public class FactoryBetterThenBuilder {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        long startTimeFactory = System.nanoTime();
        AbstractFactory gameFactory = FactoryProducer.getFactory("GAME");
        
        Game game1 = gameFactory.getGame("GraOTor");
        Game game2 = gameFactory.getGame("HejToMojaRyba");
        Game game3 = gameFactory.getGame("Zlodzieje");
        long endTimeFactory = System.nanoTime() - startTimeFactory;
        
        AbstractFactory dlcFactory = FactoryProducer.getFactory("DLC");
        
        Dlc dlc1 = dlcFactory.getDlc("Cube");
        Dlc dlc2 = dlcFactory.getDlc("Foil");
        Dlc dlc3 = dlcFactory.getDlc("Sticker");
        
        System.out.println("===== Factory =====" );
        System.out.println(endTimeFactory);
        System.out.println(game1.toString());
        System.out.println(game2.toString());
        System.out.println(game3.toString());
//        System.out.println(dlc1.toString());
//        System.out.println(dlc2.toString());
//        System.out.println(dlc3.toString());
        long startTimeBuilder = System.nanoTime();
        Seller seller = new Seller();
        GameBuilder hejToMojaRyba = new HejToMojaRyba();
        GameBuilder graOTor = new GraOTor();
        GameBuilder zlodzieje = new Zlodzieje();
        
        seller.setgameBuilder(hejToMojaRyba);
        seller.constructGame();
        factorybetterthenbuilder.builder.Game game4 = seller.getGame();
        
        seller.setgameBuilder(graOTor);
        seller.constructGame();
        factorybetterthenbuilder.builder.Game game5 = seller.getGame();
        
        seller.setgameBuilder(zlodzieje);
        seller.constructGame();
        factorybetterthenbuilder.builder.Game game6 = seller.getGame();
        long endTimeBuilder = System.nanoTime() - startTimeBuilder;
        
        System.out.println("===== Builder =====");
        System.out.println(endTimeBuilder);
        System.out.println(game4.toString());
        System.out.println(game5.toString());
        System.out.println(game6.toString());
    }
    
}

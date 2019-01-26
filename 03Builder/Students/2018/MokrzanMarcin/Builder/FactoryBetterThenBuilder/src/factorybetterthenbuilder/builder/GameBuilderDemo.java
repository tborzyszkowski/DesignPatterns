/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package factorybetterthenbuilder.builder;

/**
 *
 * @author Marcin
 */
public class GameBuilderDemo {
    public static void main(String[] args) {
        Seller seller = new Seller();
        GameBuilder hejToMojaRyba = new HejToMojaRyba();
        GameBuilder graOTor = new GraOTor();
        GameBuilder zlodzieje = new Zlodzieje();
        
        seller.setgameBuilder(hejToMojaRyba);
        seller.constructGame();
        Game game1 = seller.getGame();
        
        seller.setgameBuilder(graOTor);
        seller.constructGame();
        Game game2 = seller.getGame();
        
        seller.setgameBuilder(zlodzieje);
        seller.constructGame();
        Game game3 = seller.getGame();
        
        System.out.println(game1.toString());
        System.out.println(game2.toString());
        System.out.println(game3.toString());
    }
}

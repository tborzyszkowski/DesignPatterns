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
public class Seller {
    private GameBuilder gameBuilder;

    public void setgameBuilder(GameBuilder pb) {
        gameBuilder = pb;
    }

    public Game getGame() {
        return gameBuilder.getGame();
    }

    public void constructGame() {
        gameBuilder.createNewGameProduct();
        gameBuilder.buildProductName();
        gameBuilder.buildType();
        gameBuilder.buildTime();
        gameBuilder.buildPlayers();
        gameBuilder.buildAge();
    }
}

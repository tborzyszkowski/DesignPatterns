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
public class GraOTor extends GameBuilder {

    @Override
    public void buildProductName() {
        game.setProductName("GraOTor");
    }

    @Override
    public void buildType() {
        game.setType("Gra karciana");
    }

    @Override
    public void buildTime() {
        game.setTime("ok. 30minut");
    }

    @Override
    public void buildPlayers() {
        game.setPlayers("2-4 osób");
    }

    @Override
    public void buildAge() {
        game.setAge("od 8 lat");
    }
    
}

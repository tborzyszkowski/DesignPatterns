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
public class Zlodzieje extends GameBuilder {
    
    @Override
    public void buildProductName() {
        game.setProductName("Zlodzieje");
    }

    @Override
    public void buildType() {
        game.setType("Gra karciana");
    }

    @Override
    public void buildTime() {
        game.setTime("ok. 20minut");
    }

    @Override
    public void buildPlayers() {
        game.setPlayers("3-6 osób");
    }

    @Override
    public void buildAge() {
        game.setAge("od 8 lat");
    }
    
}

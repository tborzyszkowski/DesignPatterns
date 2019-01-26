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
public abstract class GameBuilder {
    protected Game game;
    
    public Game getGame(){
        return game;
    }
    
    public void createNewGameProduct(){
        game = new Game();
    }
    
    public abstract void buildProductName();
    public abstract void buildType();
    public abstract void buildTime();
    public abstract void buildPlayers();
    public abstract void buildAge();
}

/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package factorymethod;

import factorymethod.factory.GameEnglishFactoryMethod;
import factorymethod.factory.GameFactoryMethod;
import factorymethod.factory.GamePolishFactoryMethod;
import factorymethod.game.Game;

/**
 *
 * @author Marcin
 */
public class Main {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        GameFactoryMethod gameEnglishFactoryMethod = new GameEnglishFactoryMethod();
        GameFactoryMethod gamePolishFactoryMethod = new GamePolishFactoryMethod();
        
        Game gameEnglish1 = gameEnglishFactoryMethod.orderGame("JungleSpeed");
        Game gameEnglish2 = gameEnglishFactoryMethod.orderGame("LordsOfWar");
        Game gameEnglish3 = gameEnglishFactoryMethod.orderGame("SmallWorld");
        
        Game gamePolish1 = gamePolishFactoryMethod.orderGame("GraOTor");
        Game gamePolish2 = gamePolishFactoryMethod.orderGame("HejToMojaRyba");
        Game gamePolish3 = gamePolishFactoryMethod.orderGame("Zlodzieje");
        
        System.out.println(gameEnglish1.toString());
        System.out.println(gameEnglish2.toString());
        System.out.println(gameEnglish3.toString());
        
        System.out.println(gamePolish1.toString());
        System.out.println(gamePolish2.toString());
        System.out.println(gamePolish3.toString());
    
    }
    
}

/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package abstractfactory.product.games;

import abstractfactory.product.Game;

/**
 *
 * @author Marcin
 */
public class Zlodzieje extends Game {
    
    public Zlodzieje () {
        this.productName="Zlodzieje"; 
        this.type="Gra karciana";
        this.time="ok. 20 minut";
        this.players=" 3-6 osoby";
        this.age="od 8 lat";
    }
    
}

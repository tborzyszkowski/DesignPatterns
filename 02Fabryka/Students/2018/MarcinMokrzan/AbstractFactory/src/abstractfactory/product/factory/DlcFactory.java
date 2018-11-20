/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package abstractfactory.product.factory;

import abstractfactory.mainAbstractFactory.AbstractFactory;
import abstractfactory.product.Dlc;
import abstractfactory.product.Game;
import abstractfactory.product.dlcs.Cube;
import abstractfactory.product.dlcs.Foil;
import abstractfactory.product.dlcs.Sticker;

/**
 *
 * @author Marcin
 */
public class DlcFactory extends AbstractFactory {

    @Override
    public Dlc getDlc(String productName) {
        Dlc dlc = null;
        if("Cube".equals(productName)) 
            dlc = new Cube();
        else if("Foil".equals(productName))
            dlc = new Foil();
        else if("Sticker".equals(productName)) 
            dlc = new Sticker();
        else 
            return null;
        return dlc;
    }
    
    @Override
    public Game getGame(String productName) {
        return null;
    }
    
}

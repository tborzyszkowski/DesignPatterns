/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package factorybetterthenbuilder.factory.product.factory;

import factorybetterthenbuilder.factory.abstractFactory.AbstractFactory;
import factorybetterthenbuilder.factory.product.Dlc;
import factorybetterthenbuilder.factory.product.Game;
import factorybetterthenbuilder.factory.product.dlcs.Cube;
import factorybetterthenbuilder.factory.product.dlcs.Foil;
import factorybetterthenbuilder.factory.product.dlcs.Sticker;

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

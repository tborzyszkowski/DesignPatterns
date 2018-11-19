/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package abstractfactory.mainAbstractFactory;

import abstractfactory.product.Dlc;
import abstractfactory.product.Game;

/**
 *
 * @author Marcin
 */
public abstract class AbstractFactory {
    public abstract Dlc getDlc(String productName);
    public abstract Game getGame(String productName);
}

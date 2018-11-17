/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package abstractfactory.product.dlcs;

import abstractfactory.product.Dlc;

/**
 *
 * @author Marcin
 */
public class Cube extends Dlc{
    
    public Cube () {
        this.productName="Cube";
        this.length="12 mm"; 
        this.height="12 mm";
        this.width="12 mm";
        this.limited="No";
    }
    
}

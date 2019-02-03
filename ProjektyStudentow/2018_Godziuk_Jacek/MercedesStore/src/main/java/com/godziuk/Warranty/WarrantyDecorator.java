/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.godziuk.Warranty;

/**
 *
 * @author jgodziuk
 */
public abstract class WarrantyDecorator implements Warranty{
    private final Warranty warranty;
    
    public WarrantyDecorator(Warranty warranty){
        this.warranty = warranty;
    }
    
    public String create(){
        return warranty.create();
    }
}

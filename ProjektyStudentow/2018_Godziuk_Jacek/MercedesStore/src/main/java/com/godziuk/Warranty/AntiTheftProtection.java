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
public class AntiTheftProtection extends WarrantyDecorator{
    
    public AntiTheftProtection(Warranty warranty) {
        super(warranty);
    }

    public String create() {
        return super.create() + " + 1 year of anti-theft protection";
    }
}

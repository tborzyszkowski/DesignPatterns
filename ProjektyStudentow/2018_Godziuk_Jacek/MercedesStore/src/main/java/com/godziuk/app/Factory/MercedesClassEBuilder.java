/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.godziuk.app.Factory;

/**
 *
 * @author jgodziuk
 */
public class MercedesClassEBuilder implements MercedesBuilderInterface{
    
    private Mercedes mercedes;
    
    public MercedesClassEBuilder(){
        this.mercedes = new Mercedes();
    }

    @Override
    public void buildMercedsModel() {
        mercedes.setModel("e-class");
    }

    @Override
    public void buildMercedesType() {
        mercedes.setType("long sedan");
    }

    @Override
    public void buildMercedesEngine() {
        mercedes.setEngine("3.2 240hp");
    }

    @Override
    public void buildMercedesPrice() {
        mercedes.setPrice("240000 PLN");
    }

    @Override
    public Mercedes getMercedes() {
        return this.mercedes;
    }
    
    
}

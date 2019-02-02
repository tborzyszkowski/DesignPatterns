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
public class MercedesClassCBuilder implements MercedesBuilderInterface{

    private Mercedes mercedes;
    
    public MercedesClassCBuilder(){
        this.mercedes = new Mercedes();
    }
    
    @Override
    public void buildMercedsModel() {
        mercedes.setModel("c-class");
    }

    @Override
    public void buildMercedesType() {
        mercedes.setType("sedan");
    }

    @Override
    public void buildMercedesEngine() {
        mercedes.setEngine("2.8 190hp");
    }

    @Override
    public void buildMercedesPrice() {
        mercedes.setPrice("195000 PLN");
    }

    @Override
    public Mercedes getMercedes() {
        return this.mercedes;
    }
    
}

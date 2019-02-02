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
public class MercedesClassABuilder implements MercedesBuilderInterface{

    private Mercedes mercedes;
    
    public MercedesClassABuilder(){
        this.mercedes = new Mercedes();
    }
    
    @Override
    public void buildMercedsModel() {
        mercedes.setModel("a-class");
    }

    @Override
    public void buildMercedesType() {
        mercedes.setType("hatchback");
    }

    @Override
    public void buildMercedesEngine() {
        mercedes.setEngine("2.0 150hp");
    }

    @Override
    public void buildMercedesPrice() {
        mercedes.setPrice("150000 PLN");
    }

    @Override
    public Mercedes getMercedes() {
        return this.mercedes;
    }
       
}

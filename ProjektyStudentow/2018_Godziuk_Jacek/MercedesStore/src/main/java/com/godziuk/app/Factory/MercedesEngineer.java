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
public class MercedesEngineer {
    private MercedesBuilderInterface mercedesBuilderInterface;
    
    public MercedesEngineer(MercedesBuilderInterface mercedesBuilderInterface){
        this.mercedesBuilderInterface = mercedesBuilderInterface;
    }
    
    public Mercedes getMercedes(){
        return this.mercedesBuilderInterface.getMercedes();
    }
    
    public void makeMercedes(){
        this.mercedesBuilderInterface.buildMercedsModel();
        this.mercedesBuilderInterface.buildMercedesType();
        this.mercedesBuilderInterface.buildMercedesEngine();
        this.mercedesBuilderInterface.buildMercedesPrice();
    }
}

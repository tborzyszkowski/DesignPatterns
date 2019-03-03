package com.godziuk.app.Organizm;

/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

/**
 *
 * @author jgodziuk
 */
public class WilkBuilder implements OrganizmBuilderInterface{

    private Organizm organizm;
    
    public WilkBuilder(){
        this.organizm = new Organizm();
    }
    
    @Override
    public void buildOrganizmType() {
        organizm.setOrganizmType("wilk");
    }

    @Override
    public Organizm getOrganizm() {
        return this.organizm;
    }
    
}

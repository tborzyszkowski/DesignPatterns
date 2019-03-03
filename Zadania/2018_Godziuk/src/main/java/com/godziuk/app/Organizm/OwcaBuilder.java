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
public class OwcaBuilder implements OrganizmBuilderInterface{

    private Organizm organizm;
    
    public OwcaBuilder(){
        this.organizm = new Organizm();
    }
    
    @Override
    public void buildOrganizmType() {
        organizm.setOrganizmType("owca");
    }

    @Override
    public Organizm getOrganizm() {
        return this.organizm;
    }
    
}

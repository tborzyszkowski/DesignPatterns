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
public class TrawaBuilder implements OrganizmBuilderInterface{

    private Organizm organizm;
    
    public TrawaBuilder(){
        this.organizm = new Organizm();
    }
    
    @Override
    public void buildOrganizmType() {
        organizm.setOrganizmType("trawa");
    }

    @Override
    public Organizm getOrganizm() {
        return this.organizm;
    }
    
}

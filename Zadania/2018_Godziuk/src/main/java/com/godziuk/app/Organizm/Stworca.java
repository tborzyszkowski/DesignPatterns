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
public class Stworca {
    private OrganizmBuilderInterface organizmBuilderInterface;
    
    public Stworca(OrganizmBuilderInterface organizmBuilderInterface){
        this.organizmBuilderInterface = organizmBuilderInterface;
    }
    
    public Organizm getOrganizm(){
        return this.organizmBuilderInterface.getOrganizm();
    }
    
    public void createOrganizm(){
        this.organizmBuilderInterface.buildOrganizmType();
    }
}

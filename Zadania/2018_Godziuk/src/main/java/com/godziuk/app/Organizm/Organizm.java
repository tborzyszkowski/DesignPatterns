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
public class Organizm implements OrganizmInterface{
    private String type;
    
    @Override
    public void setOrganizmType(String type) {
        this.type = type;
    }

    public String getType() {
        return type;
    }

    @Override
    public String toString() {
        return "Organizm{" + type + "}";
    }
}

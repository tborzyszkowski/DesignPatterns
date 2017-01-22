/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package projekt;

/**
 *
 * @author KrzysieK
 */
public class DanieWczorajsze extends zestawObiadowy {
    
    public DanieWczorajsze(){
        danie = new Danie("Danie Wczorajsze");
    }
    
    @Override
    public zestawObiadowy dodajKotlet() {
        danie.mieso = "kotlet schabowy";
        danie.cena += 6.90;
        return this;
    }

    @Override
    public zestawObiadowy dodajSurowke() {
        danie.surowka ="smażon kapusta";
        danie.cena += 0.80;
        return this;
    }

    @Override
    public zestawObiadowy dodajZiemniaki() {
        danie.baza = "ryż";
        danie.cena += 1.70;
        return this;
    }
    
}
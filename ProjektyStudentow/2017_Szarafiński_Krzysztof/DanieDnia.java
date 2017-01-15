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
public class DanieDnia extends zestawObiadowy {
    
    public DanieDnia(){
        danie = new Danie("Danie Dnia");
    }
    
    @Override
    public zestawObiadowy dodajKotlet() {
        danie.mieso = "kotlet mielony";
        danie.cena += 8.90;
        return this;
    }

    @Override
    public zestawObiadowy dodajSurowke() {
        danie.surowka ="buraczki";
        danie.cena += 1.80;
        return this;
    }

    @Override
    public zestawObiadowy dodajZiemniaki() {
        danie.baza = "ziemniory";
        danie.cena += 1.20;
        return this;
    }
    
}

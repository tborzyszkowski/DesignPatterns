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
public class Paczek extends Deser {

    public Paczek() {
        this.cena = 4.50;
        this.nazwa = "Tłusty pączuś";
    }

    @Override
    public String getNazwa() {
        return nazwa;
    }

    @Override
    public Double getCena() {
        return cena;
    }
}

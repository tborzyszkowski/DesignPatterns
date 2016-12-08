/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Prototyp;

import java.io.Serializable;

/**
 *
 * @author KrzysieK
 */
public class Hobby implements Serializable{

    Plywanie plywanie;
    Rower rower;
    Taniec taniec;
    String nazwa;

    Hobby(String nazwa) {
        this.nazwa = nazwa;
    }

    @Override
    public String toString() {
        if (nazwa.equalsIgnoreCase("plywanie")) {
            plywanie = new Plywanie(nazwa);
            return plywanie.toString();
        } else if (nazwa.equalsIgnoreCase("rower")) {
            rower = new Rower(nazwa);
            return rower.toString();
        } else if (nazwa.equalsIgnoreCase("taniec")){
            taniec = new Taniec(nazwa);
            return taniec.toString();
        } else
            return "Brak hobby";
    }
}

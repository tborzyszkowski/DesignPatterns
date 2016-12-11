/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Fasada;

/**
 *
 * @author KrzysieK
 */
public class Pizza extends Danie {

    Pizza() {
        nazwa = "Pizza";
        domyslneSkladniki();
        cena = 25.99;
    }

    private void domyslneSkladniki() {
        skladniki.add("Peperoni");
        skladniki.add("Czosnek");
        skladniki.add("Oliwki");
        skladniki.add("Cebula");
        skladniki.add("Ser");
    }
}

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
public class Projekt {

    public static void main(String[] args) {
        // prosta fabryka
        Narrator lektor = Narrator.instancja();
        Bajka bajka = lektor.zamowBajke("COOL RESTAURANT");
        bajka.czytaj();        
    }
}

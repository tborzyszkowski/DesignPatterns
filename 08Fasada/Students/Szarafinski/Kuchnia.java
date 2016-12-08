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
public class Kuchnia {
    public void przygotuj(Danie danie){
        System.out.println("Czytam przepis by przygotować " + danie.nazwa);
    }
    
    public void dodajSkladniki(Danie danie){
        System.out.println("Mieszam, miksuję, trę, kroję i dodaję: " + danie.wypiszSkladniki() + " by przygotwać " + danie.nazwa);
    }
    
    public void upiecz(Danie danie){
        System.out.println("Piekę " + danie.nazwa);
    }
}

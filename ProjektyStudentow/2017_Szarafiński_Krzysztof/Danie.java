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
public class Danie {
    String nazwa;
    Double cena;
    String baza;
    String surowka;
    String mieso;
    
    public Danie(String nazwa){
        this.nazwa = nazwa;
        this.cena=0.0;
    }
    
    public void przygotuj(){
        System.out.println("[Kucharz]\n"
                + "Już prawie gotowe, nie poganiajcie mnie!");
    }
    public void wydaj(){
        System.out.println("Uff, gotowe. Można wydawać.");
    }
    
    @Override
    public String toString(){
        return (baza + ", " + surowka + ", " + mieso);
    }
}

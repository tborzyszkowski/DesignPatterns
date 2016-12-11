/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Dekorator;

/**
 *
 * @author KrzysieK
 */
public abstract class Wydruk {
    String nazwa;
    String rodzaj;
    Double cena;
    
    public abstract String pokaz();
    public abstract Double wartosc();
    
}

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
public class Dostawa {
    public void dostarcz(Danie danie, String lokalizacja){
        System.out.println(danie.nazwa + " jest dostarczane do "+ lokalizacja + ". Cena zamówienia to: " + danie.cena);
    }
}

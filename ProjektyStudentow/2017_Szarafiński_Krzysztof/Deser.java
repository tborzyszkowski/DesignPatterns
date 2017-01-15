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
public class Deser {
    protected String nazwa;
    protected Double cena;
    
    public void przygotuj(){
        System.out.println("Przygotowuję deser dla mojego klienta");
    }
    
      public String getNazwa(){
        return nazwa;
    }
    
    public Double getCena(){
        return cena;
    }
}

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
public abstract class Dekorator extends Kawa {
    Kawa kawa;
    
    public Dekorator(Kawa kawa){
        this.kawa = kawa;
    }
    
    @Override
     public String getNazwa() {
        return kawa.nazwa;
    }

    
    @Override
    public Double cena(){
        return kawa.cena();
    }
    
}

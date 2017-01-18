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
public class KawaZCukrem extends Dekorator {    
    
    public KawaZCukrem(Kawa kawa){
    super(kawa);
}

    @Override
    public String getNazwa(){
        return kawa.getNazwa() + " z cukrem";
    }
    @Override
    public Double cena() {
        return super.cena() + 2.5;
    }
    
}

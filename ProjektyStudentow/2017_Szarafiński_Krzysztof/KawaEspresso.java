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
public class KawaEspresso extends Kawa{
    
    public KawaEspresso(){
        this.nazwa = "Espresso";
        this.cena = 10.0;
    }
    
    @Override
    public Double cena() {
        return cena;
    }

    @Override
    public String getNazwa() {
        return nazwa;
    }
    
}

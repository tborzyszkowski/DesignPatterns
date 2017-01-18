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
public class Drozdzowka extends Deser {
    public Drozdzowka (){
        this.cena = 2.50;
        this.nazwa = "Eko Drożdżówka";
    }
    
    @Override
    public String getNazwa(){
        return nazwa;
    }
    
    @Override
    public Double getCena(){
        return cena;
    }
}
    


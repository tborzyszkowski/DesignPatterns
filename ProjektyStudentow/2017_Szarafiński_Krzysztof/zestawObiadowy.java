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
public abstract class zestawObiadowy {
    protected Danie danie;
    
    
    public Danie noweDanie(){
        return this.dodajKotlet().dodajSurowke().dodajZiemniaki().danie;
    }
    
    public abstract zestawObiadowy dodajKotlet();
    public abstract zestawObiadowy dodajSurowke();
    public abstract zestawObiadowy dodajZiemniaki();
    
}

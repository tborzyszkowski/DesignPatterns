/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package AdapterPluggablePrzyklad;

import java.util.ArrayList;

/**
 *
 * @author KrzysieK
 */
public abstract class Kodeki {
    String nazwa;
    ArrayList<String> wspomaganeFormaty = new ArrayList<>();
    Kodeki(){
        dodajFormatyPodstawowe();
    }
    
    abstract void dodajFormatyPodstawowe();
}

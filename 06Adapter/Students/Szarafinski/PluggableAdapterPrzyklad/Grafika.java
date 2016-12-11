/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package AdapterPluggablePrzyklad;

/**
 *
 * @author KrzysieK
 */
public class Grafika extends Kodeki {

    public Grafika() {
    nazwa = "Grafika";
    }


    @Override
    void dodajFormatyPodstawowe() {
        wspomaganeFormaty.add("jpeg");
        wspomaganeFormaty.add("jpg");
        wspomaganeFormaty.add("gif");
    }
    
}

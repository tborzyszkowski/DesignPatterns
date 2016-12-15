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
public class DiviX extends Kodeki {

    public DiviX() {
        nazwa = "DiviX";
    }

    @Override
    void dodajFormatyPodstawowe() {
        wspomaganeFormaty.add("mp4");
        wspomaganeFormaty.add("mpeg");
        wspomaganeFormaty.add("mov");
        wspomaganeFormaty.add("avi");
               
    }
    
}

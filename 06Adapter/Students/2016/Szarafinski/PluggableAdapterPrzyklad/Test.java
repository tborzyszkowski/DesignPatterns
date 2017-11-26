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
public class Test {
    public static void main(String[] args){
        Adapter odtwarzaczMP3 = new Adapter(new OdtwarzaczMP3());
        odtwarzaczMP3.odtwarzajPlik("Die Antwoord - I Fink U Freeky.mp3");
        odtwarzaczMP3.odtwarzajPlik("Deadpool.mpeg");
        
        Adapter odtwarzaczMultimedialny = new Adapter(new OdtwarzaczMultimedialny());
        odtwarzaczMultimedialny.odtwarzajPlik("Interstellar.avi");
        odtwarzaczMultimedialny.odtwarzajPlik("DJ Sava feat. Faydee - Love in DUBAI.mp3");
    }
}

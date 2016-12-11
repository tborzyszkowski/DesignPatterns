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
public class Adapter extends OdtwarzaczMP3 {

    
    private interface Funkcja {

        void odtwarzajPlik(String nazwa);
    }
    private Funkcja funkcja;

    Adapter(OdtwarzaczMP3 player) {
        funkcja = new Funkcja() {
            @Override
            public void odtwarzajPlik(String nazwaPliku) {
                player.Play(nazwa(nazwaPliku), rozszerzenie(nazwaPliku));
            }
        };
                
    }

    Adapter(OdtwarzaczMultimedialny player) {
        funkcja = new Funkcja() {
            @Override
            public void odtwarzajPlik(String nazwa) {
                player.odtworz(nazwa);
            }
        };
    }

    public void odtwarzajPlik(String nazwa) {
        funkcja.odtwarzajPlik(nazwa);
    }

    private String rozszerzenie(String nazwapliku) {
        String tekst = "";
        int i = nazwapliku.lastIndexOf('.');
        if (i > 0) {
            tekst = nazwapliku.substring(i + 1);
        }
        return tekst;
    }

    private String nazwa(String nazwapliku) {
        String tekst = "";
        int i = nazwapliku.lastIndexOf('.');
        if (i > 0) {
            tekst = nazwapliku.substring(0, i);
        }
        return tekst;
    }
}
